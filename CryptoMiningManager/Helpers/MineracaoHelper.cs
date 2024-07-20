using DevExpress.XtraEditors;
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
using System.Windows.Forms;

namespace CryptoMiningManager.Helpers
{
	public class MineracaoHelper
	{
		private static Regex EscapedSequences { get; } = new(@"\x1B\[[0-9;]*[mGKH]", RegexOptions.Compiled);

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

		private string LocalizacaoLogsMineracao { get; set; }

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

		public MineracaoHelper(IEntidadesHelper<Comando> comandosHelper, IEntidadesHelper<Moeda> moedasHelper, IEntidadesHelper<Minerador> mineradoresHelper, string localizacaoLogsMineracao)
		{
			AtividadeThread = null;
			CancelarThread_Mineracao = null;
			ComandosHelper = comandosHelper;
			LocalizacaoLogsMineracao = localizacaoLogsMineracao; //Caso apareça mais algum caso como este (dados da configuração que precisem de ser lidos), talvez faça sentido criar algum tipo de classe estática ou algo parecido
			MineradorAtivo = null;
			MineradoresHelper = mineradoresHelper;
			MineradoresPorMoeda = new();
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

			if (!Directory.Exists(LocalizacaoLogsMineracao))
				Directory.CreateDirectory(LocalizacaoLogsMineracao);

			int i = 1;
			string nomeBase = $"Log_{DateTime.Now:yyyy-MM-dd HH-mm-ss}";
			CaminhoCompletoLogMineracao = Path.Combine(LocalizacaoLogsMineracao, $"{nomeBase}.txt");
			while (File.Exists(CaminhoCompletoLogMineracao))
			{
				CaminhoCompletoLogMineracao = Path.Combine(LocalizacaoLogsMineracao, $"{nomeBase}_{i++}.txt");
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
					if (minerador == null)
						throw new ArgumentNullException(nameof(minerador));

					await IniciarMinerador(minerador);
					break;
				default:
					throw new ArgumentException("Algoritmo inválido!");
			}
		}

		public async Task Parar()
		{
			await PararProcessoAtivo();
			PararThreadRentabilidade();

			UtilizadorAtivo = true;
			AlterarModoEnergia();
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

		//MÉTODOS AUXILIARES
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
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show("Erro ao alternar modo de energia.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

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
				mineradores = new();
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

			await PararProcessoAtivo();

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

			if (MineradorAtivo.CPU)
			{
				PararThreadModoEnergia();
			}
			else if (AtividadeThread == null && Global.ConfigGeralAtiva.AlternarModoEnergia)
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

					VerificaoRentabilidade?.Invoke(null, new EventArgs());
					Thread.Sleep(TempoEntreVerificacoes_Rentabilidade);
				}
			}
			catch (ThreadInterruptedException) { }
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao verificar rentabilidade.");
				XtraMessageBox.Show("Erro ao verificar rentabilidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async Task PararProcessoAtivo()
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
				RegistarLogsMineracao?.Invoke(null, new EventArgs());
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao guardar logs de mineração.");
			}

			if (PosMineracao != null)
			{
				using (Process processo = new())
				{
					processo.StartInfo = new("cmd.exe", PosMineracao.ComandosCMD)
					{
						CreateNoWindow = true,
						UseShellExecute = false
					};

					if (processo.Start())
						await processo.WaitForExitAsync();
					else
						LogHelper.EscreveLog(LogLevel.Warning, "Não foi possível iniciar o comando pós-mineração {idComando}", PosMineracao.Id);
				}
			}
			AlteracaoEstadoMineracao?.Invoke(null, new AlteracaoEstadoMineracaoEventArgs(false));
		}

		private void PararThreadModoEnergia()
		{
			if (CancelarThread_ModoEnergia != null)
			{
				CancelarThread_ModoEnergia.Cancel();
				CancelarThread_ModoEnergia = null;
			}
		}

		private void PararThreadRentabilidade()
		{
			if (RentabilidadeThread == null)
				return;

			if (RentabilidadeThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
				RentabilidadeThread.Interrupt();
			else
				CancelarThread_Mineracao.Cancel();

			if (!RentabilidadeThread.Join(10000))
				XtraMessageBox.Show("O processo está a levar mais tempo para parar do que o esperado.", "Possível falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			CancelarThread_Mineracao.Dispose();
			CancelarThread_Mineracao = null;
			RentabilidadeThread = null;
		}

		public static string RemoveEscapeSequences(string str)
		{
			return str == null ? str : EscapedSequences.Replace(str, "");
		}
	}
}
