using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.EventArgs;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ThreadState = System.Threading.ThreadState;

namespace CryptoMiningManager.Helpers
{
	public partial class MineracaoHelper : IDisposable, IAsyncDisposable
	{
		[GeneratedRegex(@"\x1B\[[0-9;]*[mGKH]", RegexOptions.Compiled)]
		private static partial Regex FiltroOutputMinerador();

		private static Regex EscapedSequences { get; } = FiltroOutputMinerador();

		private bool UtilizadorAtivo { get; set; }

		private IEntidadesHelper<Comando> ComandosHelper { get; }
		private IEntidadesHelper<Moeda> MoedasHelper { get; }
		private IEntidadesHelper<Minerador> MineradoresHelper { get; }

		private CancellationTokenSource CancelarThread_Mineracao { get; set; }
		private CancellationTokenSource CancelarThread_ModoEnergia { get; set; }
		private Dictionary<int, Minerador> MineradoresPorMoeda { get; set; }
		private Minerador MineradorAtivo { get; set; }
		private Comando PreMineracao { get; set; }
		private Comando PosMineracao { get; set; }
		private Thread RentabilidadeThread { get; set; }
		private Thread AtividadeThread { get; set; }

		public Process ProcessoAtivo { get; private set; }

		public string CaminhoCompletoLogMineracao { get; private set; }
		public int TempoEntreVerificacoes_Rentabilidade { get; set; } = 180000; //TODO: Permitir definir o tempo pelo TaskbarIcon //Por agora ficam 30m
		public int TempoEntreVerificacoes_Atividade { get; set; } = 120000; //TODO: Permitir alterar este tempo, provavelmente nas configurações gerais //Por agora ficam 2m

		#region Eventos
		public event EventHandler<AlteracaoEstadoMineracaoEventArgs> AlteracaoEstadoMineracao;
		public event EventHandler<AlteracaoMineradorEventArgs> AlteracaoMinerador;
		public event EventHandler<AlteracaoMoedaMaisRentavelEventArgs> AlteracaoMoedaMaisRentavel;
		public event EventHandler<DataReceivedEventArgs> ErroMinerador;
		public event EventHandler<DataReceivedEventArgs> OutputMinerador;
		public event EventHandler RegistarLogsMineracao;
		public event EventHandler VerificaoRentabilidade;
		#endregion

		public MineracaoHelper(IEntidadesHelper<Comando> comandosHelper, IEntidadesHelper<Moeda> moedasHelper, IEntidadesHelper<Minerador> mineradoresHelper)
		{
			AtividadeThread = null;
			CancelarThread_Mineracao = null;
			CancelarThread_ModoEnergia = null;
			ComandosHelper = comandosHelper;
			MineradorAtivo = null;
			MineradoresHelper = mineradoresHelper;
			MineradoresPorMoeda = [];
			MoedasHelper = moedasHelper;
			PosMineracao = null;
			PreMineracao = null;
			ProcessoAtivo = null;
			RentabilidadeThread = null;
			UtilizadorAtivo = true;
		}

		public async Task Iniciar(Algoritmo algoritmo, Minerador minerador = null)
		{
			//await PararProcessoAtivo();
			//PararThreadRentabilidade();

			string localizacaoLogsMineracao = Global.ConfigGeralAtiva?.LocalizacaoLogsMineracao;
			if (!string.IsNullOrWhiteSpace(localizacaoLogsMineracao))
			{
				if (!Directory.Exists(localizacaoLogsMineracao))
					Directory.CreateDirectory(localizacaoLogsMineracao);

				int i = 1;
				string nomeBase = $"Log_{DateTime.Now:yyyy-MM-dd HH-mm-ss}";
				CaminhoCompletoLogMineracao = Path.Combine(localizacaoLogsMineracao, $"{nomeBase}.txt");
				while (File.Exists(CaminhoCompletoLogMineracao))
				{
					CaminhoCompletoLogMineracao = Path.Combine(localizacaoLogsMineracao, $"{nomeBase}_{i++}.txt");
				}
			}

			switch (algoritmo)
			{
				//case Algoritmo.Moeda:
				//	break;
				case Algoritmo.Rentabilidade:
					CancelarThread_Mineracao = new();

					RentabilidadeThread = new Thread(async () => await MinerarPorRentabilidade(CancelarThread_Mineracao.Token)) { IsBackground = true };
					RentabilidadeThread.Start();
					break;
				case Algoritmo.Minerador:
					ArgumentNullException.ThrowIfNull(minerador);

					await IniciarMinerador(minerador);
					break;
				default:
					throw new ArgumentException("Algoritmo inválido!");
			}
		}

		public void Parar()
		{
			PararProcessoAtivo();
			PararThreadRentabilidade();

			UtilizadorAtivo = true;
			AlterarModoEnergia();
		}

		public async Task Parar_Async()
		{
			await PararProcessoAtivo_Async();
			Parar_Base();
		}

		#region Output ProcessoAtivo
		private void ProcessoAtivo_ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (e.Data == null) //Terminou o processo
			{
				LogHelper.EscreveLog(LogLevel.Information, $"A terminar o minerador {MineradorAtivo}");
				return;
			}

			LogHelper.EscreveLog(LogLevel.Warning, $"Erro no minerador {MineradorAtivo}: {e.Data}");
			ErroMinerador?.Invoke(sender, e);
		}

		private void ProcessoAtivo_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				OutputMinerador?.Invoke(sender, e);
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao tratar output");
				throw;
			}
		}
		#endregion

		public void Dispose()
		{
			Parar();
			GC.SuppressFinalize(this);
		}

		public async ValueTask DisposeAsync()
		{
			await Parar_Async();
			GC.SuppressFinalize(this);
		}

		//MÉTODOS AUXILIARES
		/// <summary>
		/// Alterna o modo de energia conforme o estado do utilizador.
		/// Se <see cref="UtilizadorAtivo"/> == true muda para o modo de Alto Desempenho, caso contrário muda para o modo Poupança de Energia
		/// </summary>
		/// <returns></returns>
		private void AlterarModoEnergia()
		{
			WindowsAPIHelper.MudarPlanoEnergia(UtilizadorAtivo ? WindowsAPIHelper.AltoDesempenho : WindowsAPIHelper.PoupancaEnergia);
		}

		public async Task<Dictionary<int, Minerador>> GetMineradoresAtivosPorMoeda(Dictionary<int, Minerador> mineradores = null)
		{
			if (mineradores == null)
				mineradores = [];
			else
				mineradores.Clear();

			foreach (Minerador minerador in (await MineradoresHelper.GetEntidadesComLista("mi.Ativo = 1", "mi.Nome ASC")).Values)
			{
				if (minerador.Moeda != null)
					mineradores.Add(minerador.Moeda.Id, minerador);
			}
			mineradores.TrimExcess();

			return mineradores;
		}

		private Minerador GetMineradorMaisRentavel(List<Moeda> moedas)
		{
			moedas.Sort(Moedas.MaiorRentabilidade_Descendente);

			AlteracaoMoedaMaisRentavel?.Invoke(null, new AlteracaoMoedaMaisRentavelEventArgs(moedas[0]));

			Func<Moeda, bool> IsMoedaAtual = MineradorAtivo == null ? m => false :
				m => m.Id == MineradorAtivo.Moeda.Id;
			foreach (Moeda moeda in moedas)
			{
				//Se se chegar à moeda do MineradorAtual, então não vale a pena continuar a procurar.
				//Já estamos a minerar a moeda mais rentável para a qual foi configurado um minerador.
				if (IsMoedaAtual(moeda))
					return MineradorAtivo;

				if (MineradoresPorMoeda.TryGetValue(moeda.Id, out Minerador minerador))
					return minerador;
			}

			return null;
		}

		private async Task IniciarMinerador(Minerador minerador)
		{

			PreMineracao = null;
			PosMineracao = null;
			//Atualizar comandos
			foreach (Comando comando in await ComandosHelper.GetEntidades("Ativo = 1"))
			{
				if (comando.PreMineracao)
					PreMineracao = comando;

				if (comando.PosMineracao)
					PosMineracao = comando;
			}

			await PararProcessoAtivo_Async();

			if (PreMineracao != null)
			{
				using (Process processo = new())
				{
					processo.StartInfo = new("cmd.exe", PreMineracao.ComandosCMD)
					{
						CreateNoWindow = true,
						UseShellExecute = false
					};

					if (processo.Start())
						await processo.WaitForExitAsync();
					else
						LogHelper.EscreveLog(LogLevel.Warning, "Não foi possível iniciar o comando pré-mineração {idComando}", PreMineracao.Id);
				}
			}

			ProcessoAtivo = new();

			ProcessoAtivo.StartInfo = new(minerador.Localizacao, minerador.Parametros)
			{
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			};

			if (!ProcessoAtivo.Start())
				throw new Exception($"Não foi possível iniciar o minerador {minerador}");

			ProcessoAtivo.ErrorDataReceived += ProcessoAtivo_ErrorDataReceived;
			ProcessoAtivo.OutputDataReceived += ProcessoAtivo_OutputDataReceived;

			ProcessoAtivo.BeginErrorReadLine();
			ProcessoAtivo.BeginOutputReadLine();

			if (MineradorAtivo != null)
				LogHelper.EscreveLog(LogLevel.Information, $"A mudar do minerador {MineradorAtivo} para o minerador {minerador}. Moedas: Antes: {MineradorAtivo.Moeda} | Depois: {minerador.Moeda}");

			//TODO: Validar esta lógica - Acho que ia entrar sempre dentro do if, portanto não parece ser necessário
			//if (MineradorAtivo?.Id != minerador.Id)
			//{
			MineradorAtivo = minerador;
			AlteracaoMinerador?.Invoke(null, new AlteracaoMineradorEventArgs(MineradorAtivo));
			//}

			if (!MineradorAtivo.CPU && AtividadeThread == null && Global.ConfigGeralAtiva.AlternarModoEnergia)
			{
				CancelarThread_ModoEnergia ??= new();
				AtividadeThread = new Thread(() => VerificarAtividadeEModoEnergia(CancelarThread_ModoEnergia.Token)) { IsBackground = true };
				AtividadeThread.Start();
			}

			AlteracaoEstadoMineracao?.Invoke(null, new AlteracaoEstadoMineracaoEventArgs(true));
		}

		private async Task MinerarPorRentabilidade(CancellationToken cancelar)
		{
			try
			{
				await GetMineradoresAtivosPorMoeda(MineradoresPorMoeda);

				LogHelper.EscreveLog(LogLevel.Information, "A iniciar mineração por rentabilidade");
				while (!cancelar.IsCancellationRequested)
				{
					List<Moeda> moedas = await MoedasHelper.GravarEntidades();

					Minerador minerador = GetMineradorMaisRentavel(moedas);

					if (minerador != null && MineradorAtivo?.Id != minerador.Id)
						await IniciarMinerador(minerador);

					VerificaoRentabilidade?.Invoke(null, EventArgs.Empty);
					Thread.Sleep(TempoEntreVerificacoes_Rentabilidade);
				}
			}
			catch (ThreadInterruptedException) { }
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao verificar rentabilidade.");
				MessageBoxesHelper.MostraErro("Erro ao verificar rentabilidade:", ex: ex);
			}
		}

		private void Parar_Base()
		{
			PararThreadRentabilidade();

			UtilizadorAtivo = true;
			AlterarModoEnergia();
		}

		private void PararProcessoAtivo()
		{
			PararProcessoAtivo_Base();

			ExecutarComandoCMD(PosMineracao);
			AlteracaoEstadoMineracao?.Invoke(null, new AlteracaoEstadoMineracaoEventArgs(false));
		}

		private async Task PararProcessoAtivo_Async()
		{
			PararProcessoAtivo_Base();

			await ExecutarComandoCMD_Async(PosMineracao);
			AlteracaoEstadoMineracao?.Invoke(null, new AlteracaoEstadoMineracaoEventArgs(false));
		}

		private void PararProcessoAtivo_Base()
		{
			if (ProcessoAtivo == null)
				return;

			PararThreadModoEnergia();

			ProcessoAtivo.Kill(true);
			ProcessoAtivo.Dispose();
			ProcessoAtivo = null;
			MineradorAtivo = null;

			try
			{
				if (!string.IsNullOrEmpty(CaminhoCompletoLogMineracao))
					RegistarLogsMineracao?.Invoke(null, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao guardar logs de mineração.");
			}
		}

		private void PararThreadModoEnergia()
		{
			InterromperThread(AtividadeThread, CancelarThread_ModoEnergia);

			CancelarThread_ModoEnergia = null;
			AtividadeThread = null;
		}

		private void PararThreadRentabilidade()
		{
			InterromperThread(RentabilidadeThread, CancelarThread_Mineracao);

			CancelarThread_Mineracao = null;
			RentabilidadeThread = null;
		}

		private void VerificarAtividadeEModoEnergia(CancellationToken cancelar)
		{
			try
			{
				while (!cancelar.IsCancellationRequested)
				{
					if (UtilizadorAtivo)
					{
						if (WindowsAPIHelper.GetTempoInativo() >= 120)
						{
							UtilizadorAtivo = false;
							AlterarModoEnergia();
						}
					}
					else if (WindowsAPIHelper.GetTempoInativo() < 120)
					{
						UtilizadorAtivo = true;
						AlterarModoEnergia();
					}

					Thread.Sleep(TempoEntreVerificacoes_Atividade);
				}
			}
			catch (ThreadInterruptedException) { }
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErro("Erro ao alternar modo de energia.", ex: ex);
			}
		}

		#region Métodos Estáticos
		/// <summary>
		/// Executa um <see cref="Comando"/> sem apresentar a janela do CMD
		/// </summary>
		/// <param name="comando"></param>
		/// <returns></returns>
		private static void ExecutarComandoCMD(Comando comando)
		{
			if (comando == null)
				return;

			using (Process processo = new())
			{
				processo.StartInfo = new("cmd.exe", comando.ComandosCMD)
				{
					CreateNoWindow = true,
					UseShellExecute = false
				};

				if (processo.Start())
					processo.WaitForExit();
				else
					LogHelper.EscreveLog(LogLevel.Warning, "Não foi possível iniciar o comando {Comando}", comando);
			}
		}
		/// <summary>
		/// Executa um <see cref="Comando"/> sem apresentar a janela do CMD
		/// </summary>
		/// <param name="comando"></param>
		/// <returns></returns>
		private static async Task ExecutarComandoCMD_Async(Comando comando)
		{
			if (comando == null)
				return;

			using (Process processo = new())
			{
				processo.StartInfo = new("cmd.exe", comando.ComandosCMD)
				{
					CreateNoWindow = true,
					UseShellExecute = false
				};

				if (processo.Start())
					await processo.WaitForExitAsync();
				else
					LogHelper.EscreveLog(LogLevel.Warning, "Não foi possível iniciar o comando {Comando}", comando);
			}
		}

		/// <summary>
		/// Interrompe a <paramref name="thread"/> usando o método <see cref="Thread.Interrupt"/> caso esta esteja com o estado <see cref="ThreadState.WaitSleepJoin"/> 
		/// ou utilizando o método <see cref="CancellationTokenSource.Cancel"/> caso contrário.
		/// <para><b>NOTA IMPORTANTE:</b> Não usar <paramref name="cancellationToken"/> posteriormente! Será feito o Dispose do mesmo de forma assíncrona.</para>
		/// </summary>
		/// <param name="thread"></param>
		/// <param name="cancellationToken"></param>
		/// <returns><see cref="Task"/> que irá fazer <see cref="Thread.Join"/> e fazer o Dispose do <paramref name="cancellationToken"/></returns>
		private static Task InterromperThread(Thread thread, CancellationTokenSource cancellationToken)
		{
			if (thread == null)
				return null;

			if (thread.ThreadState == ThreadState.WaitSleepJoin)
				thread.Interrupt();
			else
				cancellationToken.Cancel();

			return Task.Run(() =>
			{
				thread.Join(); //TODO: Validar se isto pode causar algum tipo de problema
				cancellationToken.Dispose();
			});

			//if (!thread.Join(10000))
			//	MessageBoxesHelper.MostraAviso("O processo está a levar mais tempo para parar do que o esperado.", "Possível falha");

		}

		public static string RemoveEscapeSequences(string str)
		{
			return str == null ? str : EscapedSequences.Replace(str, "");
		}
		#endregion
	}
}
