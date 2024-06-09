using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Exceptions;
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
using ThreadState = System.Threading.ThreadState;

namespace CryptoMiningManager.Views.UserControls.Funcionalidades
{
	public partial class GestaoAutomaticaMineracaoUserControl : DevExpress.XtraEditors.XtraUserControl
	{
		private int TempoEntreVerificacoes { get; set; }

		private string CaminhoCompletoLogMineracao { get; set; }
		private string LocalizacaoLogsMineracao { get; set; }

		private CancellationTokenSource CancelarThread { get; set; } = null;
		private Comando PreMineracao { get; set; } = null;
		private Comando PosMineracao { get; set; } = null;
		private Minerador MineradorAtivo { get; set; } = null;
		private Process ProcessoAtivo { get; set; } = null;
		private Thread RentabilidadeThread { get; set; } = null;

		private Regex EscapedSequences { get; } = new(@"\x1B\[[0-9;]*[mGKH]", RegexOptions.Compiled);
		private Semaphore SemaforoLogsMineracao { get; } = new(1, 1);

		private IEntidadesHelper<Comando> ComandosHelper { get; }
		private IEntidadesHelper<Minerador> MineradoresHelper { get; }
		private IEntidadesHelper<Moeda> MoedasHelper { get; }

		public GestaoAutomaticaMineracaoUserControl(IEntidadesHelper<Comando> comandosHelper, IEntidadesHelper<Minerador> mineradoresHelper,
			IEntidadesHelper<Moeda> moedasHelper, string localizacaoLogsMineracao)
		{
			InitializeComponent();

			ComandosHelper = comandosHelper;

			//Caso apareça mais algum caso como este (dados da configuração que precisem de ser lidos), talvez faça sentido criar algum tipo de classe estática ou algo parecido
			LocalizacaoLogsMineracao = localizacaoLogsMineracao;

			MineradoresHelper = mineradoresHelper;
			MoedasHelper = moedasHelper;

			//Este método aparentemente vai buscar o DescriptionAttribute sozinho, então já fica com uma Caption decente
			AlgoritmoRIDG.Items.AddEnum<Algoritmo>();
			AlgoritmoBEI.EditValue = Algoritmo.MaisRentavel;

			TempoEntreVerificacoes = 180000; //30 minutos
			TemporizadorBEI.EditValue = DateTime.Today;
		}

		private async void GestaoAutomaticaMineracaoUserControl_Load(object sender, EventArgs e)
		{
			await AtualizarDados();
		}

		#region Operações
		private async void AtualizarBBI_ItemClick(object sender, ItemClickEventArgs e)
		{
			await AtualizarDados();
		}

		private async void IniciarBBI_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this))
				{
					await PararProcessoAtivo();
					PararThreadRentabilidade();

					if (TemporizadorBEI.EditValue is DateTime tempo && tempo.TimeOfDay.Ticks != 0)
					{
						IniciarBBI.Visibility = BarItemVisibility.Never;
						PararBBI.Visibility = BarItemVisibility.Always;
						try
						{
							await Task.Run(() => Thread.Sleep(tempo.TimeOfDay));
						}
						finally
						{
							IniciarBBI.Visibility = BarItemVisibility.Always;
							PararBBI.Visibility = BarItemVisibility.Never;
						}
					}

					int i = 1;
					string nomeBase = $"Log_{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
					CaminhoCompletoLogMineracao = Path.Combine(LocalizacaoLogsMineracao, $"{nomeBase}.txt");
					while (File.Exists(CaminhoCompletoLogMineracao))
					{
						CaminhoCompletoLogMineracao = Path.Combine(LocalizacaoLogsMineracao, $"{nomeBase}_{i++}.txt");
					}

					Minerador minerador;
					switch ((Algoritmo)AlgoritmoBEI.EditValue)
					{
						case Algoritmo.Moeda:

							break;
						case Algoritmo.MaisRentavel:
							CancelarThread = new CancellationTokenSource();
							RentabilidadeThread = new Thread(async () => await MinerarPorRentabilidade(CancelarThread.Token)) { IsBackground = true };
							RentabilidadeThread.Start();
							break;
						case Algoritmo.Selecionado:
							if (MineradoresGV.IsDataRow(MineradoresGV.FocusedRowHandle) && MineradoresGV.FocusedRowObject is Minerador mineradorAux)
								minerador = mineradorAux;
							else
								throw new CustomException("Não há nenhum minerador selecionado!");

							IniciarMinerador(minerador);
							break;
						default:
							throw new ArgumentException("Algoritmo inválido!");
					}
				}
			}
			catch (CustomException ce)
			{
				XtraMessageBox.Show(ce.Message, ce.Detalhes ?? "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro a ler dados.");
				XtraMessageBox.Show("Erro a ler dados: " + ex.Message, "Erro a tentar ler dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void PararBBI_ItemClick(object sender, ItemClickEventArgs e)
		{
			using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this))
			{
				try
				{
					await PararTudo();
				}
				catch (Exception ex)
				{
					LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao parar minerador.");
					XtraMessageBox.Show("Erro ao parar minerador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		#endregion

		private void IntervaloVerificacaoRentabilidadeBEI_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				int intervaloVerificacaoRentabilidade = decimal.ToInt32((decimal)IntervaloVerificacaoRentabilidadeBEI.EditValue);
				TempoEntreVerificacoes = intervaloVerificacaoRentabilidade * 60000; //*1000 por serem milisegundos e *60 para passar a minutos
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao alterar intervalo de verificação de rentabilidade.");
				XtraMessageBox.Show("Erro ao alterar intervalo de verificação de rentabilidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#region Output ProcessoAtivo
		private void ProcessoAtivo_ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (e.Data == null) //Terminou o processo
			{
				LogHelper.EscreveLog(LogLevel.Information, $"A terminar o minerador {MineradorAtivo}");
				return;
			}

			ExecucaoME.AppendLine("ERRO: " + RemoveEscapeSequences(e.Data));
			LogHelper.EscreveLog(LogLevel.Warning, $"Erro no minerador {MineradorAtivo}: {e.Data}");

			ScrollFim();
		}

		private void ProcessoAtivo_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				//Prevenir textos infinitos e excesso de utilização de memória com strings infinitas
				if (ExecucaoME.Text.Length > 50000)
					EscreverLogsMineracao();

				ExecucaoME.AppendLine(RemoveEscapeSequences(e.Data));
				ScrollFim();
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao tratar output");
			}
		}
		#endregion

		//MÉTODOS AUXILIARES
		private async Task AtualizarDados()
		{
			IOverlaySplashScreenHandle splashScreenHandler = null;
			try
			{
				splashScreenHandler = SplashScreenManager.ShowOverlayForm(MineradoresGC);
				MineradoresGV.BeginDataUpdate();

				//Atualizar mineradores
				await MoedasHelper.GravarEntidades();

				MineradoresBindingSource.Clear();
				foreach (KeyValuePair<int, Minerador> registo in await MineradoresHelper.GetEntidadesComLista("mi.Ativo = 1", "mi.Nome ASC"))
				{
					if (registo.Value.Moeda != null)
						MineradoresBindingSource.Add(registo.Value);
				}

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
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao atualizar lista de mineradores.");
				XtraMessageBox.Show("Erro ao atualizar lista de mineradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				MineradoresGV.EndDataUpdate();
				splashScreenHandler?.Dispose();
			}
		}

		private void EscreverLogsMineracao()
		{
			//O semáforo garante que nunca se vai tentar escrever no ficheiro 2 vezes (ou mais) em simultâneo
			SemaforoLogsMineracao.WaitOne();
			using (StreamWriter streamWriter = new(CaminhoCompletoLogMineracao, true))
			{
				streamWriter.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}{Environment.NewLine}{ExecucaoME.Text}");
				streamWriter.Flush();
				streamWriter.Close();
			}

			Invoke(() => ExecucaoME.Clear());
			SemaforoLogsMineracao.Release();
		}

		private Minerador GetMineradorMaisRentavel(List<Moeda> moedas)
		{
			moedas.Sort(Moedas.MaiorRentabilidade_Descendente);

			Invoke(() => MoedaMaisRentavelTE.Text = string.IsNullOrWhiteSpace(moedas[0].Nome) ? moedas[0].NomeExterno : moedas[0].Nome);

			Func<Moeda, bool> IsMoedaAtual = MineradorAtivo == null ? m => false :
				m => m.Id == MineradorAtivo.Moeda.Id;

			Dictionary<int, Minerador> mineradoresPorMoeda = ((BindingList<Minerador>)MineradoresBindingSource.List).ToDictionary(m => m.Moeda.Id);

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

		private async void IniciarMinerador(Minerador minerador)
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
						Invoke(() => LogHelper.EscreveLog(LogLevel.Warning, "Não foi possível iniciar o comando pré-mineração {idComando}", PreMineracao.Id));
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
				Invoke(() => LogHelper.EscreveLog(LogLevel.Information, $"A mudar do minerador {MineradorAtivo} para o minerador {minerador}." +
					$"Moedas: Antes: {MineradorAtivo.Moeda} | Depois: {minerador.Moeda}"));

			if (MineradorAtivo?.Id != minerador.Id)
			{
				MineradorAtivo = minerador;
				BeginInvoke(() =>
				{
					UltimaAlteracaoMineradorDE.DateTime = DateTime.Now;
					MineradorAtivoTE.Text = MineradorAtivo.Nome;
					MoedaAtualTE.Text = MineradorAtivo.Moeda.Nome;
				});
			}

			BeginInvoke(() =>
			{
				IniciarBBI.Visibility = BarItemVisibility.Never;
				PararBBI.Visibility = BarItemVisibility.Always;
			});
		}

		private async Task MinerarPorRentabilidade(CancellationToken cancelar)
		{
			try
			{
				Invoke(() => LogHelper.EscreveLog(LogLevel.Information, "A iniciar mineração por rentabilidade"));
				while (!cancelar.IsCancellationRequested)
				{
					List<Moeda> moedas = await MoedasHelper.GravarEntidades();

					Minerador minerador = GetMineradorMaisRentavel(moedas);

					if (minerador != null && MineradorAtivo?.Id != minerador.Id)
						IniciarMinerador(minerador);

					BeginInvoke(() => UltimaVerificacaoRentabilidadeDE.DateTime = DateTime.Now);
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
				EscreverLogsMineracao();
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
						Invoke(() => LogHelper.EscreveLog(LogLevel.Warning, "Não foi possível iniciar o comando pós-mineração {idComando}", PosMineracao.Id));
				}
			}

			Invoke(() =>
			{
				IniciarBBI.Visibility = BarItemVisibility.Always;
				PararBBI.Visibility = BarItemVisibility.Never;
			});
		}

		private void PararThreadRentabilidade()
		{
			if (RentabilidadeThread == null)
				return;

			if (RentabilidadeThread.ThreadState == ThreadState.WaitSleepJoin)
				RentabilidadeThread.Interrupt();
			else
				CancelarThread.Cancel();

			if (!RentabilidadeThread.Join(10000))
				XtraMessageBox.Show("O processo está a levar mais tempo para parar do que o esperado.", "Possível falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);

			CancelarThread.Dispose();
			CancelarThread = null;
			RentabilidadeThread = null;
		}

		public async Task PararTudo()
		{
			await PararProcessoAtivo();
			PararThreadRentabilidade();
			ExecucaoME.Text = string.Empty;
		}

		private string RemoveEscapeSequences(string str)
		{
			return EscapedSequences.Replace(str, "");
		}

		private void ScrollFim()
		{
			Invoke(() =>
			{
				ExecucaoME.SelectionStart = ExecucaoME.Text.Length;
				ExecucaoME.SelectionLength = 0;
				ExecucaoME.ScrollToCaret();
			});
		}
	}
}
