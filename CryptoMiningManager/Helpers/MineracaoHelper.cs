using DevExpress.XtraEditors;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.EventArgs;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Helpers
{
	public class MineracaoHelper
	{
		private IEntidadesHelper<Moeda> MoedasHelper { get; }

		private CancellationTokenSource CancelarThread { get; set; }
		private Minerador MineradorAtivo { get; set; }
		private Regex EscapedSequences { get; } = new(@"\x1B\[[0-9;]*[mGKH]", RegexOptions.Compiled);
		private Thread RentabilidadeThread { get; set; }

		private string LocalizacaoLogsMineracao { get; set; }

		public BindingList<Minerador> Mineradores { get; set; }
		public Comando PreMineracao { get; set; }
		public Comando PosMineracao { get; set; }
		public Process ProcessoAtivo { get; set; }

		public string CaminhoCompletoLogMineracao { get; set; }
		public int TempoEntreVerificacoes { get; set; }

		#region Events
		public event EventHandler<AlteracaoEstadoMineracaoEventArgs> AlteracaoEstadoMineracao;
		public event EventHandler<AlteracaoMineradorEventArgs> AlteracaoMinerador;
		public event EventHandler<AlteracaoMoedaMaisRentavelEventArgs> AlteracaoMoedaMaisRentavel;
		public event EventHandler<DataReceivedEventArgs> ErroMinerador;
		public event EventHandler<DataReceivedEventArgs> OutputMinerador;
		public event EventHandler RegistarLogsMineracao;
		public event EventHandler VerificaoRentabilidade;
		#endregion

		public MineracaoHelper(IEntidadesHelper<Moeda> moedasHelper, string localizacaoLogsMineracao)
		{
			CancelarThread = null;
			LocalizacaoLogsMineracao = localizacaoLogsMineracao; //Caso apareça mais algum caso como este (dados da configuração que precisem de ser lidos), talvez faça sentido criar algum tipo de classe estática ou algo parecido
			MineradorAtivo = null;
			MoedasHelper = moedasHelper;
			PosMineracao = null;
			PreMineracao = null;
			ProcessoAtivo = null;
			RentabilidadeThread = null;


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
				case Algoritmo.Moeda:

					break;
				case Algoritmo.MaisRentavel:
					CancelarThread = new CancellationTokenSource();
					RentabilidadeThread = new Thread(async () => await MinerarPorRentabilidade(CancelarThread.Token)) { IsBackground = true };
					RentabilidadeThread.Start();
					break;
				case Algoritmo.Selecionado:
					if (minerador == null)
						throw new ArgumentNullException(nameof(minerador));

					await IniciarMinerador(minerador);
					break;
				default:
					throw new ArgumentException("Algoritmo inválido!");
			}
		}

		public async Task PararTudo()
		{
			await PararProcessoAtivo();
			PararThreadRentabilidade();
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

		private Minerador GetMineradorMaisRentavel(List<Moeda> moedas)
		{
			moedas.Sort(Moedas.MaiorRentabilidade_Descendente);

			AlteracaoMoedaMaisRentavel?.Invoke(null, new AlteracaoMoedaMaisRentavelEventArgs(moedas[0]));

			Func<Moeda, bool> IsMoedaAtual = MineradorAtivo == null ? m => false :
				m => m.Id == MineradorAtivo.Moeda.Id;

			Dictionary<int, Minerador> mineradoresPorMoeda = Mineradores.ToDictionary(m => m.Moeda.Id);

			foreach (Moeda moeda in moedas)
			{
				//Se se chegar à moeda do MineradorAtual, então não vale a pena continuar a procurar.
				//Já estamos a minerar a moeda mais rentável para a qual foi configurado um minerador.
				if (IsMoedaAtual(moeda))
					return MineradorAtivo;

				if (mineradoresPorMoeda.TryGetValue(moeda.Id, out Minerador minerador))
					return minerador;
			}

			return null;
		}

		private async Task IniciarMinerador(Minerador minerador)
		{
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

			if (MineradorAtivo?.Id != minerador.Id)
			{
				MineradorAtivo = minerador;
				AlteracaoMinerador?.Invoke(null, new AlteracaoMineradorEventArgs(MineradorAtivo));
			}

			AlteracaoEstadoMineracao?.Invoke(null, new AlteracaoEstadoMineracaoEventArgs(true));
		}

		private async Task MinerarPorRentabilidade(CancellationToken cancelar)
		{
			try
			{
				LogHelper.EscreveLog(LogLevel.Information, "A iniciar mineração por rentabilidade");
				while (!cancelar.IsCancellationRequested)
				{
					List<Moeda> moedas = await MoedasHelper.GravarEntidades();

					Minerador minerador = GetMineradorMaisRentavel(moedas);

					if (minerador != null && MineradorAtivo?.Id != minerador.Id)
						await IniciarMinerador(minerador);

					VerificaoRentabilidade?.Invoke(null, new EventArgs());
					Thread.Sleep(TempoEntreVerificacoes);
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

		private void PararThreadRentabilidade()
		{
			if (RentabilidadeThread == null)
				return;

			if (RentabilidadeThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
				RentabilidadeThread.Interrupt();
			else
				CancelarThread.Cancel();

			if (!RentabilidadeThread.Join(10000))
				XtraMessageBox.Show("O processo está a levar mais tempo para parar do que o esperado.", "Possível falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			CancelarThread.Dispose();
			CancelarThread = null;
			RentabilidadeThread = null;
		}

		public string RemoveEscapeSequences(string str)
		{
			return str == null ? str : EscapedSequences.Replace(str, "");
		}
	}
}
