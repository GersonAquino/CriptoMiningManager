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
using Modelos.EventArgs;
using Modelos.Interfaces;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Utils;

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
		private ToolStripMenuItem AlgoritmosItem { get; set; }
		private ToolStripMenuItem MineradoresItem { get; set; }

		public MainForm(ILifetimeScope scope, IEntidadesHelper<ConfiguracaoGeral> configGeralHelper, CustomNotifyIcon notifyIcon, MineracaoHelper mineracaoHelper)
		{
			InitializeComponent();

			ConfigGeralHelper = configGeralHelper;
			MineracaoHelper = mineracaoHelper;
			Scope = scope;
			TaskBarIcon = notifyIcon;
			UtilizadorQuerSair = false;

			TaskBarIcon.NotifyIcon.Text = "Inativo";

			MineracaoHelper.AlteracaoEstadoMineracao += MineracaoHelper_AlteracaoEstadoMineracao;
			MineracaoHelper.AlteracaoMinerador += MineracaoHelper_AlteracaoMinerador;
			MineracaoHelper.AlteracaoMoedaMaisRentavel += MineracaoHelper_AlteracaoMoedaMaisRentavel;
			MineracaoHelper.ErroMinerador += MineracaoHelper_ErroMinerador;
			MineracaoHelper.OutputMinerador += MineracaoHelper_OutputMinerador;
			MineracaoHelper.RegistarLogsMineracao += MineracaoHelper_RegistarLogsMineracao;
			MineracaoHelper.VerificaoRentabilidade += MineracaoHelper_VerificaoRentabilidade;
		}

		#region Eventos MainForm
		private async void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				Global.ConfigGeralAtiva = await ConfigGeralHelper.GetEntidade("Ativo = 1");
				if (Global.ConfigGeralAtiva == null)
				{
					Global.ConfigGeralAtiva = new();
					Global.ConfigGeralAtiva.Descricao = "Configuração Geral";
					Global.ConfigGeralAtiva.Ativo = true;

					if (!await ConfigGeralHelper.GravarEntidade(Global.ConfigGeralAtiva))
					{
						Global.ConfigGeralAtiva = null;
						LogHelper.EscreveLog(LogLevel.Error, "Falha ao criar configuração geral base automaticamente! É necessário validar o código! (não houve exceção)");
						XtraMessageBox.Show("Não foi possível criar uma configuração geral base, por favor considere criar uma manualmente.",
						"Configuração Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

				if (Global.ConfigGeralAtiva?.IniciarMinimizada == true)
					MinimizarAplicacao();

				ToolStripMenuItem item = TaskBarIcon.AdicionarItem(Taskbar.Mineracao);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Iniciar, Taskbar_IniciarClick, true);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Parar, Taskbar_PararClick, false, true);

				AlgoritmosItem = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Algoritmo, null, true);
				CustomNotifyIcon.AdicionarSubItems_FromEnum<Algoritmo>(AlgoritmosItem);

				//TODO: Implementar algoritmo por defeito nas configurações
				if (AlgoritmosItem.DropDownItems[Algoritmo.Rentabilidade.GetDescricaoEnum()] is ToolStripMenuItem rentabilidadeItem)
					rentabilidadeItem.Checked = true;

				ToggleEventosItems(AlgoritmosItem.DropDownItems, AlgoritmoItem_CheckedChanged, true);

				MineradoresItem = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Mineradores, null, false);

				TaskBarIcon.AdicionarItem(Taskbar.Configuracoes); //TODO: Implementar
				TaskBarIcon.AdicionarItem(Taskbar.Sair, (_, _) => { UtilizadorQuerSair = true; this.Close(); }, true);

				TaskBarIcon.NotifyIcon.DoubleClick += (object sender, EventArgs e) => this.Show();
				TaskBarIcon.NotifyIcon.Visible = true;
			}
			catch (Exception ex)
			{
				Global.ConfigGeralAtiva = null;
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show(text: "Erro ao carregar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
							await MineracaoHelper.Parar();
						else
							e.Cancel = true;
					}

					return;
				}

				if (Global.ConfigGeralAtiva?.MinimizarAoFechar == true && this.Visible)
				{
					MinimizarAplicacao();
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
					await MineracaoHelper.Parar();
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

		private void MainForm_Shown(object sender, EventArgs e)
		{
			try
			{
				ToggleEventosVisuaisMineracao(true);
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show("Erro ao mostrar form.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				if (DialogResult.Yes == XtraMessageBox.Show("Fechar este separador irá parar o processo de mineração ativo, pretende continuar?",
					"Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				{
					await MineracaoHelper.Parar();
					GestaoAutomaticaMineracaoUC = null;
				}
				else
					e.Cancel = true;
			}
		}

		#region Eventos MineracaoHelper
		private void MineracaoHelper_AlteracaoEstadoMineracao(object sender, AlteracaoEstadoMineracaoEventArgs e)
		{
			Invoke(() =>
			{
				//Dava para usar o CustomNotifyIcon.GetItem_Recursivo para obter ambos os items (Iniciar e Parar), mas assim deve ser mais otimizado em princípio
				if (CustomNotifyIcon.GetItem_Recursivo(TaskBarIcon.Items, Taskbar.Mineracao) is ToolStripMenuItem mineracaoItem)
				{
					bool notAtiva = !e.Ativa;
					mineracaoItem.DropDownItems[Taskbar_Mineracao.Iniciar].Visible = notAtiva;
					mineracaoItem.DropDownItems[Taskbar_Mineracao.Parar].Visible = e.Ativa;
					AlgoritmosItem.Enabled = notAtiva;
					MineradoresItem.Enabled = notAtiva;
					TaskBarIcon.NotifyIcon.Text = e.Ativa ? "Ativo" : "Inativo";
				}
			});
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

		#region Eventos TaskbarIcon
		private void AlgoritmoItem_CheckedChanged(object sender, EventArgs e)
		{
			UniqueCheckedChanged(sender, AlgoritmosItem.DropDownItems, AlgoritmoItem_CheckedChanged, "algoritmo", itemAlterado =>
			{
				switch ((Algoritmo)itemAlterado.Tag)
				{
					case Algoritmo.Minerador: //Criar os items de mineradores
						MineradoresItem.DropDownItems.Clear();

						foreach (Minerador minerador in MineracaoHelper.GetMineradoresAtivosPorMoeda().GetAwaiter().GetResult().Values)
						{
							CustomNotifyIcon.AdicionarSubItem(MineradoresItem, minerador.Nome, MineradorItem_CheckedChanged, true, true, minerador);
						}

						if (MineradoresItem.DropDownItems.Count != 0)
						{
							ToolStripMenuItem primeiroMinerador = (ToolStripMenuItem)MineradoresItem.DropDownItems[0];
							primeiroMinerador.CheckedChanged -= MineradorItem_CheckedChanged;
							try
							{
								primeiroMinerador.Checked = true;
							}
							finally
							{
								primeiroMinerador.CheckedChanged += MineradorItem_CheckedChanged;
							}
						}
						else
							CustomNotifyIcon.AdicionarSubItem(MineradoresItem, "Não existem mineradores ativos", null, true).Enabled = false;

						MineradoresItem.Visible = true;
						break;
					case Algoritmo.Rentabilidade:
						MineradoresItem.Visible = false;
						break;
					default:
						break;
				}
			});

		}

		private void MineradorItem_CheckedChanged(object sender, EventArgs e)
		{
			UniqueCheckedChanged(sender, MineradoresItem.DropDownItems, MineradorItem_CheckedChanged, "minerador");
		}

		private async void Taskbar_IniciarClick(object sender, EventArgs e)
		{
			try
			{
				ToolStripItem item = CustomNotifyIcon.GetItem_Recursivo(AlgoritmosItem.DropDownItems, i => i is ToolStripMenuItem item && item.Checked);
				Algoritmo algoritmo = (Algoritmo)item.Tag;

				switch (algoritmo)
				{
					case Algoritmo.Minerador:
						item = CustomNotifyIcon.GetItem_Recursivo(MineradoresItem.DropDownItems, i => i is ToolStripMenuItem item && item.Checked);
						await MineracaoHelper.Iniciar(algoritmo, (Minerador)item.Tag);
						break;
					case Algoritmo.Rentabilidade:
						await MineracaoHelper.Iniciar(algoritmo);
						break;
					default:
						throw new NotImplementedException($"Algoritmo {algoritmo.GetDescricaoEnum()} não implementado.");
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao iniciar mineração pelo TaskbarIcon");
				XtraMessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void Taskbar_PararClick(object sender, EventArgs e)
		{
			try
			{
				await MineracaoHelper.Parar();
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao parar mineração pelo TaskbarIcon");
				XtraMessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
				XtraMessageBox.Show(ex.GetBaseException().Message, $"Não foi possível abrir o menu {controlElement.Text}",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void MinimizarAplicacao()
		{
			this.Hide();
			ToggleEventosVisuaisMineracao(false);
		}

		private static void ToggleEventosItems(ToolStripItemCollection items, EventHandler eventHandler, bool atribuir, Action<ToolStripMenuItem> acaoExtra = null)
		{
			Action<ToolStripMenuItem> acao;
			if (acaoExtra == null)
			{
				acao = atribuir ? item => item.CheckedChanged += eventHandler : item => item.CheckedChanged -= eventHandler;
			}
			else
			{
				acao = atribuir ? item => { item.CheckedChanged += eventHandler; acaoExtra(item); }
				: item => { item.CheckedChanged -= eventHandler; acaoExtra(item); };
			}

			foreach (ToolStripMenuItem algoritmoItem in items)
			{
				acao(algoritmoItem);
			}
		}

		private void ToggleEventosVisuaisMineracao(bool atribuir)
		{
			if (Global.ConfigGeralAtiva?.AtualizarUIMinimizado == true)
				GestaoAutomaticaMineracaoUC?.ToggleEventosMineracao(atribuir);
		}

		private static void UniqueCheckedChanged(object sender, ToolStripItemCollection items, EventHandler eventHandler, string entidade, Action<ToolStripMenuItem> onChecked = null)
		{
			Action reativarEventos = null;
			try
			{
				if (sender is ToolStripMenuItem itemAlterado)
				{
					//Ao ativar um item irá desativar todos os outros
					if (itemAlterado.Checked)
					{
						reativarEventos = () => ToggleEventosItems(items, eventHandler, true);
						ToggleEventosItems(items, eventHandler, false, item => item.Checked = item.Name == itemAlterado.Name);

						onChecked?.Invoke(itemAlterado);
					}
					else //Impede-se de desativar o único item ativo
					{
						itemAlterado.CheckedChanged -= eventHandler;
						reativarEventos = () => itemAlterado.CheckedChanged += eventHandler;

						itemAlterado.Checked = true;
					}
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show($"Erro ao tratar alteração de {entidade}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				reativarEventos?.Invoke();
			}
		}
	}
}