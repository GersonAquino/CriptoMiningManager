using Autofac;
using CryptoMiningManager.Constants;
using CryptoMiningManager.CustomControls;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views.UserControls.Configuracoes;
using CryptoMiningManager.Views.UserControls.Funcionalidades;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Enums;
using Modelos.EventArgs;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace CryptoMiningManager.Views
{
	public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private ILifetimeScope Scope { get; }

		private bool UtilizadorQuerSair { get; set; }

		private ConfiguracoesEntidadesHelper ConfiguracoesEntidadesHelper { get; }
		private GestaoAutomaticaMineracaoUserControl GestaoAutomaticaMineracaoUC { get; set; }
		private CustomNotifyIcon TaskBarIcon { get; }
		private MineracaoHelper MineracaoHelper { get; }

		public MainForm(ILifetimeScope scope, CustomNotifyIcon notifyIcon, MineracaoHelper mineracaoHelper, ConfiguracoesEntidadesHelper configuracoesEntidadesHelper)
		{
			InitializeComponent();

			ConfiguracoesEntidadesHelper = configuracoesEntidadesHelper;
			MineracaoHelper = mineracaoHelper;
			Scope = scope;
			TaskBarIcon = notifyIcon;
			UtilizadorQuerSair = false;

			MineracaoHelper.AlteracaoEstadoMineracao += MineracaoHelper_AlteracaoEstadoMineracao;
			//MineracaoHelper.AlteracaoMinerador += MineracaoHelper_AlteracaoMinerador;
			//MineracaoHelper.AlteracaoMoedaMaisRentavel += MineracaoHelper_AlteracaoMoedaMaisRentavel;
			//MineracaoHelper.ErroMinerador += MineracaoHelper_ErroMinerador;
			//MineracaoHelper.OutputMinerador += MineracaoHelper_OutputMinerador;
			//MineracaoHelper.RegistarLogsMineracao += MineracaoHelper_RegistarLogsMineracao;
			//MineracaoHelper.VerificaoRentabilidade += MineracaoHelper_VerificaoRentabilidade;

			beiVersao.EditValue = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		#region Eventos MainForm
		private async void MainForm_Load(object sender, EventArgs e)
		{
			using (ILifetimeScope scope = Scope.BeginLifetimeScope())
			{
				await scope.Resolve<Inicializador>().Inicializar((_, _) => { UtilizadorQuerSair = true; this.Close(); });
			}

			TaskBarIcon.AdicionarItem(Taskbar.Configuracoes, ConfiguracoesItem_Click); //TODO: Implementar

			TaskBarIcon.NotifyIcon.DoubleClick += (_, _) => this.Show();

			TaskBarIcon.NotifyIcon.Visible = true;

			if (Global.ConfigGeralAtiva?.IniciarMinimizada == true)
				this.Hide();
			else
				Global.AppVisivel = true;
		}

		private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (UtilizadorQuerSair)
				{
					if (MineracaoHelper.ProcessoAtivo != null)
					{
						if (MessageBoxesHelper.PerguntaSimples("Existe um processo de mineração ativo, pretende continuar?", this.Text))
							await MineracaoHelper.Parar_Async();
						else
							e.Cancel = true;
					}

					return;
				}

				if (Global.ConfigGeralAtiva?.MinimizarAoFechar == true && this.Visible)
				{
					this.Hide();
					e.Cancel = true;
					return;
				}

				string mensagem;
				if (MineracaoHelper.ProcessoAtivo != null)
					mensagem = "Existe um processo de mineração ativo, pretende continuar?";
				else
					mensagem = "Pretende terminar a aplicação?";

				e.Cancel = !MessageBoxesHelper.PerguntaSimples(mensagem, this.Text);

				if (!e.Cancel && GestaoAutomaticaMineracaoUC != null)
					await MineracaoHelper.Parar_Async();
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErro("Erro ao fechar aplicação (a aplicação fechará na mesma).", ex: ex);
				e.Cancel = false;
			}
			finally
			{
				UtilizadorQuerSair = false;
			}
		}

		private void MainForm_VisibleChanged(object sender, EventArgs e)
		{
			try
			{
				ToggleEventosVisuaisMineracao(this.Visible);
				Global.AppVisivel = this.Visible;
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErro("Erro ao mostrar/esconder form.", ex: ex);
			}
		}

		#endregion

		#region Eventos Click que criam um tab com um UserControl
		private void ComandosACE_Click(object sender, EventArgs e)
		{
			CallUserControlTab<ComandosUserControl>(sender);
		}

		private void ConfiguracoesGeraisACE_Click(object sender, EventArgs e)
		{
			CallUserControlTab<ConfiguracoesGeraisUserControl>(sender);
		}

		private void GestaoAutomaticaMineracaoACE_Click(object sender, EventArgs e)
		{
			CallUserControlTab<GestaoAutomaticaMineracaoUserControl>(sender);
		}

		private void MineradoresACE_Click(object sender, EventArgs e)
		{
			CallUserControlTab<MineradoresUserControl>(sender);
		}

		private void MoedasACE_Click(object sender, EventArgs e)
		{
			CallUserControlTab<MoedasUserControl>(sender);
		}
		#endregion

		#region Eventos TaskbarIcon
		private void ConfiguracoesItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (Global.ConfigGeralAtiva == null)
				{
					MessageBoxesHelper.MostraAviso("Não existe configuração geral ativa, considere criar uma!");
					return;
				}

				this.Show();

				ConfiguracoesEntidadesHelper.AbrirEditorUC("Configuração Geral Ativa", this, Global.ConfigGeralAtiva);
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErro("Erro ao abrir configurações!", ex: ex);
			}
		}
		#endregion
		private void DocumentManager_DocumentActivate(object sender, DocumentEventArgs e)
		{
			if (this.Ribbon.MergedPages.Count != 0)
			{
				this.Ribbon.SelectPage(this.Ribbon.MergedPages[0]);
				this.Ribbon.SelectedPage = this.Ribbon.MergedPages[0];
			}
		}

		private async void TabbedView_DocumentClosing(object sender, DocumentCancelEventArgs e)
		{
			if (e.Document.Caption == GestaoAutomaticaMineracaoACE.Text && MineracaoHelper.ProcessoAtivo != null)
			{
				//TODO: Visto que é possível inicial a mineração pela taskbar, isto já não faz sentido, deve-se adaptar o GestaoAutomaticaMineracaoUserControl para saber se há mineração ativa ou não quando é aberto
				if (MessageBoxesHelper.PerguntaSimples("Fechar este separador irá parar o processo de mineração ativo, pretende continuar?", "Atenção", MessageBoxIcon.Warning))
				{
					await MineracaoHelper.Parar_Async();
					GestaoAutomaticaMineracaoUC = null;
				}
				else
					e.Cancel = true;
			}
		}

		#region Eventos MineracaoHelper
		private void MineracaoHelper_AlteracaoEstadoMineracao(object sender, AlteracaoEstadoMineracaoEventArgs e)
		{
			if (!this.IsDisposed)
				Invoke(() => Inicializador.TratarAlteracaoEstadoMineracao(e, TaskBarIcon));
		}

		private void MineracaoHelper_AlteracaoMinerador(object sender, AlteracaoMineradorEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_AlteracaoMoedaMaisRentavel(object sender, AlteracaoMoedaMaisRentavelEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_ErroMinerador(object sender, DataReceivedEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_OutputMinerador(object sender, DataReceivedEventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_RegistarLogsMineracao(object sender, EventArgs e)
		{
			//TODO: Por implementar
		}

		private void MineracaoHelper_VerificaoRentabilidade(object sender, EventArgs e)
		{
			//TODO: Por implementar
		}
		#endregion

		//MÉTODOS AUXILIARES
		/// <summary>
		/// Cria um novo separador com uma <see cref="ILifetimeScope"/> nova
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="sender"></param>
		private void CallUserControlTab<T>(object sender) where T : UserControl
		{
			if (sender is not AccordionControlElement controlElement)
				return;

			try
			{
				using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this))
				{
					//Caso já haja um separador com este control, não se cria outro
					BaseDocument doc = TabbedView.Documents.FindFirst(d => d.Control is T);
					if (doc != null)
					{
						TabbedView.ActivateDocument(doc.Control);
						return;
					}

					ILifetimeScope scope = Scope.BeginLifetimeScope();
					T userControl = scope.Resolve<T>();

					//Fazer o dispose da scope do userControl sem ter de alterar o event handler dos designers //TODO: Isto fecha separadores "filhos", talvez seja melhor repensar
					userControl.Disposed += (_, _) => scope.Dispose();

					doc = TabbedView.AddDocument(userControl);
					TabbedView.Controller.Activate(doc);
					doc.Caption = controlElement.Text;

					if (userControl is GestaoAutomaticaMineracaoUserControl gestaoAutomaticaMineracao)
						GestaoAutomaticaMineracaoUC = gestaoAutomaticaMineracao;
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao abrir menu {menuText}", controlElement.Text);
				MessageBoxesHelper.MostraErro($"Não foi possível abrir o menu {controlElement.Text}", "Erro ao abrir menu!", ex: ex);
			}
		}

		private void ToggleEventosVisuaisMineracao(bool atribuir)
		{
			if (Global.ConfigGeralAtiva?.AtualizarUIMinimizado == true)
				GestaoAutomaticaMineracaoUC?.ToggleEventosMineracao(atribuir);
		}
	}
}