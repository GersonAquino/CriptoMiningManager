using CryptoMiningManager.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.EventArgs;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Funcionalidades
{
	public partial class GestaoAutomaticaMineracaoUserControl : DevExpress.XtraEditors.XtraUserControl
	{
		private IEntidadesHelper<Minerador> MineradoresHelper { get; }
		private IEntidadesHelper<Moeda> MoedasHelper { get; }

		private MineracaoHelper MineracaoHelper { get; }
		private Semaphore SemaforoLogsMineracao { get; } = new(1, 1);

		public GestaoAutomaticaMineracaoUserControl(IEntidadesHelper<Minerador> mineradoresHelper,
			IEntidadesHelper<Moeda> moedasHelper, MineracaoHelper mineracaoHelper)
		{
			InitializeComponent();
			MineracaoHelper = mineracaoHelper;
			MineradoresHelper = mineradoresHelper;
			MoedasHelper = moedasHelper;

			//Este método aparentemente vai buscar o DescriptionAttribute sozinho, então já fica com uma Caption decente
			AlgoritmoRIDG.Items.AddEnum<Algoritmo>();
			AlgoritmoBEI.EditValue = Global.ConfigGeralAtiva.Algoritmo ?? Algoritmo.Rentabilidade;

			MineracaoHelper.TempoEntreVerificacoes_Rentabilidade = 180000; //30 minutos
			TemporizadorBEI.EditValue = new DateTime(0);

			ToggleEventosMineracao(true);
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
					await MineracaoHelper.Parar();

					if (TemporizadorBEI.EditValue is DateTime tempo && tempo.TimeOfDay.Ticks != 0)
					{
						ToggleBotoesIniciar_Parar(true);
						Temporizador.Enabled = true;
					}
					else if (MineradoresGV.IsDataRow(MineradoresGV.FocusedRowHandle) && MineradoresGV.FocusedRowObject is Minerador minerador)
						await MineracaoHelper.Iniciar((Algoritmo)AlgoritmoBEI.EditValue, minerador);
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
					if (Temporizador.Enabled)
						Temporizador.Enabled = false;
					else
					{
						await MineracaoHelper.Parar();
						ExecucaoME.Text = string.Empty;
					}
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
				MineracaoHelper.TempoEntreVerificacoes_Rentabilidade = intervaloVerificacaoRentabilidade * 60000; //*1000 por serem milisegundos e *60 para passar a minutos
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao alterar intervalo de verificação de rentabilidade.");
				XtraMessageBox.Show("Erro ao alterar intervalo de verificação de rentabilidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#region Eventos MineracaoHelper
		private void MineracaoHelper_AlteracaoEstadoMineracao(object sender, AlteracaoEstadoMineracaoEventArgs e)
		{
			ToggleBotoesIniciar_Parar(e.Ativa);
		}

		private void MineracaoHelper_AlteracaoMinerador(object sender, AlteracaoMineradorEventArgs e)
		{
			BeginInvoke(() =>
			{
				UltimaAlteracaoMineradorDE.DateTime = DateTime.Now;
				MineradorAtivoTE.Text = e.Minerador.Nome;
				MoedaAtualTE.Text = e.Minerador.Moeda.Nome;
			});
		}

		private void MineracaoHelper_AlteracaoMoedaMaisRentavel(object sender, AlteracaoMoedaMaisRentavelEventArgs e)
		{
			Invoke(() => MoedaMaisRentavelTE.Text = string.IsNullOrWhiteSpace(e.Moeda.Nome) ? e.Moeda.NomeExterno : e.Moeda.Nome);
		}

		private void MineracaoHelper_ErroMinerador(object sender, DataReceivedEventArgs e)
		{
			Invoke(() =>
			{
				ExecucaoME.AppendLine("ERRO: " + MineracaoHelper.RemoveEscapeSequences(e.Data));
				ScrollFim();
			});
		}

		private void MineracaoHelper_OutputMinerador(object sender, DataReceivedEventArgs e)
		{
			Invoke(() =>
			{
				if (ExecucaoME.Text.Length > 50000)
					EscreverLogsMineracao();

				ExecucaoME.AppendLine(MineracaoHelper.RemoveEscapeSequences(e.Data));
				ScrollFim();
			});
		}

		private void MineracaoHelper_RegistarLogsMineracao(object sender, EventArgs e)
		{
			Invoke(EscreverLogsMineracao);
		}

		private void MineracaoHelper_VerificaoRentabilidade(object sender, EventArgs e)
		{
			BeginInvoke(() => UltimaVerificacaoRentabilidadeDE.DateTime = DateTime.Now);
		}
		#endregion

		private void Temporizador_Tick(object sender, EventArgs e)
		{
			try
			{
				if (TemporizadorBEI.EditValue is DateTime tempo)
				{
					//Subtrai 1 segundo da forma mais eficiente que há, ainda que seja praticamente insignificante
					DateTime novoTempo = tempo.AddTicks(-TimeSpan.TicksPerSecond);
					TemporizadorBEI.EditValue = novoTempo;

					if (novoTempo.TimeOfDay.Ticks == 0)
						TerminarTemporizador();
				}
				else
					TerminarTemporizador();
			}
			catch (Exception ex)
			{
				//Em caso de falha, regista-se o erro e inicia-se a mineração
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro no temporizador");
				TerminarTemporizador();
			}
		}

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

		/// <summary>
		/// Este método deve ser executado na Thread principal da UI
		/// </summary>
		private void EscreverLogsMineracao()
		{
			//O semáforo garante que nunca se vai tentar escrever no ficheiro 2 vezes (ou mais) em simultâneo
			SemaforoLogsMineracao.WaitOne();
			using (StreamWriter streamWriter = new(MineracaoHelper.CaminhoCompletoLogMineracao, true))
			{
				streamWriter.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}{Environment.NewLine}{ExecucaoME.Text}");
				streamWriter.Flush();
				streamWriter.Close();
			}

			ExecucaoME.Clear();
			SemaforoLogsMineracao.Release();
		}

		/// <summary>
		/// Este método deve ser executado na Thread principal da UI
		/// </summary>
		private void ScrollFim()
		{
			ExecucaoME.SelectionStart = ExecucaoME.Text.Length;
			ExecucaoME.SelectionLength = 0;
			ExecucaoME.ScrollToCaret();
		}

		/// <summary>
		/// Para o temporizador e inicia a mineração
		/// </summary>
		private async void TerminarTemporizador()
		{
			Temporizador.Enabled = false;
			await MineracaoHelper.Iniciar((Algoritmo)AlgoritmoBEI.EditValue, MineradoresGV.FocusedRowObject as Minerador);
		}

		/// <summary>
		/// Alterna o botão visível entre o Iniciar e o Parar
		/// </summary>
		/// <param name="mineracaoAtiva">true para mostrar o botão Iniciar e esconder o Parar, false para o inverso</param>
		private void ToggleBotoesIniciar_Parar(bool mineracaoAtiva)
		{
			if (this.IsDisposed)
				return;

			Invoke(() =>
			{
				if (mineracaoAtiva)
				{
					IniciarBBI.Visibility = BarItemVisibility.Never;
					PararBBI.Visibility = BarItemVisibility.Always;
				}
				else
				{
					IniciarBBI.Visibility = BarItemVisibility.Always;
					PararBBI.Visibility = BarItemVisibility.Never;
				}
			});
		}

		public void ToggleEventosMineracao(bool atribuir)
		{
			if (atribuir)
			{
				MineracaoHelper.AlteracaoEstadoMineracao += MineracaoHelper_AlteracaoEstadoMineracao;
				MineracaoHelper.AlteracaoMinerador += MineracaoHelper_AlteracaoMinerador;
				MineracaoHelper.AlteracaoMoedaMaisRentavel += MineracaoHelper_AlteracaoMoedaMaisRentavel;
				MineracaoHelper.ErroMinerador += MineracaoHelper_ErroMinerador;
				MineracaoHelper.OutputMinerador += MineracaoHelper_OutputMinerador;
				MineracaoHelper.RegistarLogsMineracao += MineracaoHelper_RegistarLogsMineracao;
				MineracaoHelper.VerificaoRentabilidade += MineracaoHelper_VerificaoRentabilidade;
			}
			else
			{
				MineracaoHelper.AlteracaoEstadoMineracao -= MineracaoHelper_AlteracaoEstadoMineracao;
				MineracaoHelper.AlteracaoMinerador -= MineracaoHelper_AlteracaoMinerador;
				MineracaoHelper.AlteracaoMoedaMaisRentavel -= MineracaoHelper_AlteracaoMoedaMaisRentavel;
				MineracaoHelper.ErroMinerador -= MineracaoHelper_ErroMinerador;
				MineracaoHelper.OutputMinerador -= MineracaoHelper_OutputMinerador;
				MineracaoHelper.RegistarLogsMineracao -= MineracaoHelper_RegistarLogsMineracao;
				MineracaoHelper.VerificaoRentabilidade -= MineracaoHelper_VerificaoRentabilidade;
			}
		}
	}
}
