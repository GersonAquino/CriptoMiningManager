using Autofac;
using CryptoMiningManager.Constants;
using CryptoMiningManager.CustomControls;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views.UserControls.Configuracoes;
using CryptoMiningManager.Views.UserControls.Funcionalidades;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Interfaces;
using System;
using System.Windows.Forms;

namespace CryptoMiningManager.Views
{
	public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private IEntidadesHelper<ConfiguracaoGeral> ConfigGeralHelper { get; }
		private ILifetimeScope Scope { get; }

		private bool UtilizadorQuerSair { get; set; }
		private CustomNotifyIcon TaskBarIcon { get; } //Não está implementado no designer para ser implementado no AutoFac como singleton e poder ser alterado onde for preciso
		private GestaoAutomaticaMineracaoUserControl GestaoAutomaticaMineracaoUC { get; set; }
		private MineracaoHelper MineracaoHelper { get; }

		public ConfiguracaoGeral ConfigGeralAtiva { get; set; }

		public MainForm(ILifetimeScope scope, IEntidadesHelper<ConfiguracaoGeral> configGeralHelper, CustomNotifyIcon notifyIcon, MineracaoHelper mineracaoHelper)
		{
			InitializeComponent();

			ConfigGeralHelper = configGeralHelper;
			MineracaoHelper = mineracaoHelper;
			Scope = scope;
			TaskBarIcon = notifyIcon;
			UtilizadorQuerSair = false;
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				ConfigGeralAtiva = await ConfigGeralHelper.GetEntidade("Ativo = 1");
				if (ConfigGeralAtiva == null)
				{
					ConfigGeralAtiva = new();
					ConfigGeralAtiva.Descricao = "Configuração Geral";
					ConfigGeralAtiva.Ativo = true;

					if (!await ConfigGeralHelper.GravarEntidade(ConfigGeralAtiva))
					{
						ConfigGeralAtiva = null;
						LogHelper.EscreveLog(LogLevel.Error, "Falha ao criar configuração geral base automaticamente! É necessário validar o código! (não houve exceção)");
						XtraMessageBox.Show("Não foi possível criar uma configuração geral base, por favor considere criar uma manualmente.",
						"Configuração Geral", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}

				if (ConfigGeralAtiva?.IniciarMinimizada == true)
					this.Hide();

				ToolStripMenuItem item = TaskBarIcon.AdicionarItem(Taskbar.Mineracao); //TODO: Implementar
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Iniciar, null);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Parar, null, false);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Algoritmo, null); //TODO: Implementar //Por agora fica sempre por rentabilidade

				TaskBarIcon.AdicionarItem(Taskbar.Configuracoes); //TODO: Implementar
				TaskBarIcon.AdicionarItem(Taskbar.Sair, (_, _) => { UtilizadorQuerSair = true; this.Close(); }, true);

				TaskBarIcon.NotifyIcon.DoubleClick += (object sender, EventArgs e) => this.Show();
				TaskBarIcon.NotifyIcon.Visible = true;
			}
			catch (Exception ex)
			{
				ConfigGeralAtiva = null;
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show("Erro ao carregar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

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

		private void DocumentManager_DocumentActivate(object sender, DocumentEventArgs e)
		{
			if (this.Ribbon.MergedPages.Count != 0)
			{
				this.Ribbon.SelectPage(this.Ribbon.MergedPages[0]);
				this.Ribbon.SelectedPage = this.Ribbon.MergedPages[0];
			}
		}

		private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (UtilizadorQuerSair)
				{
					if (MineracaoHelper.ProcessoAtivo != null)
					{
						if (XtraMessageBox.Show("Existe um processo de mineração ativo, pretende continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							await MineracaoHelper.PararTudo();
						else
							e.Cancel = true;
					}

					return;
				}

				if (ConfigGeralAtiva?.MinimizarAoFechar == true && this.Visible)
				{
					this.Hide();
					e.Cancel = true;
					return;
				}

				string mensagem;
				if (MineracaoHelper.ProcessoAtivo != null) //TabbedView.Documents.Exists(d => d.Caption == GestaoAutomaticaMineracaoACE.Text) && //Em princípio esta validação não é precisa
					mensagem = "Existe um processo de mineração ativo, pretende continuar?";
				else
					mensagem = "Pretende terminar a aplicação?";

				e.Cancel = XtraMessageBox.Show(mensagem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;

				if (!e.Cancel && GestaoAutomaticaMineracaoUC != null)
					await MineracaoHelper.PararTudo();
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show("Erro ao fechar aplicação (a aplicação fechará na mesma).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = false;
			}
			finally
			{
				UtilizadorQuerSair = false;
			}
		}

		private async void TabbedView_DocumentClosing(object sender, DocumentCancelEventArgs e)
		{
			if (e.Document.Caption == GestaoAutomaticaMineracaoACE.Text && MineracaoHelper.ProcessoAtivo != null)
			{
				if (DialogResult.Yes == XtraMessageBox.Show("Fechar este separador irá parar o processo de mineração ativo, pretende continuar?",
					"Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				{
					await MineracaoHelper.PararTudo();
					GestaoAutomaticaMineracaoUC = null;
				}
				else
					e.Cancel = true;
			}
		}

		//FUNÇÕES AUXILIARES
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

					//Fazer o dispose da scope do userControl sem ter de alterar o event handler dos designers
					userControl.Disposed += (s, e) => scope.Dispose();

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
				XtraMessageBox.Show(ex.GetBaseException().Message, $"Não foi possível abrir o menu {controlElement.Text}",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}