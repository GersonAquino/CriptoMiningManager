using CryptoMiningManager.Constants;
using CryptoMiningManager.CustomControls;
using DevExpress.XtraEditors;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.EventArgs;
using Modelos.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace CryptoMiningManager.Helpers
{
	public class SemUIHelper : ApplicationContext
	{
		private IEntidadesHelper<ConfiguracaoGeral> ConfigGeralHelper { get; }

		private CustomNotifyIcon TaskBarIcon { get; } //Não está implementado no designer para ser implementado no AutoFac como singleton e poder ser alterado onde for preciso
		private MineracaoHelper MineracaoHelper { get; }

		private ToolStripMenuItem AlgoritmosItem { get; set; }
		private ToolStripMenuItem MineradoresItem { get; set; }

		private SynchronizationContext SyncContext { get; }

		public SemUIHelper(IEntidadesHelper<ConfiguracaoGeral> configGeralHelper, CustomNotifyIcon notifyIcon, MineracaoHelper mineracaoHelper)
		{
			ConfigGeralHelper = configGeralHelper;
			MineracaoHelper = mineracaoHelper;
			SyncContext = SynchronizationContext.Current;
			TaskBarIcon = notifyIcon;

			TaskBarIcon.NotifyIcon.Text = "Inativo";

			MineracaoHelper.AlteracaoEstadoMineracao += MineracaoHelper_AlteracaoEstadoMineracao;
			//MineracaoHelper.AlteracaoMinerador += MineracaoHelper_AlteracaoMinerador;
			//MineracaoHelper.AlteracaoMoedaMaisRentavel += MineracaoHelper_AlteracaoMoedaMaisRentavel;
			//MineracaoHelper.ErroMinerador += MineracaoHelper_ErroMinerador;
			//MineracaoHelper.OutputMinerador += MineracaoHelper_OutputMinerador;
			//MineracaoHelper.RegistarLogsMineracao += MineracaoHelper_RegistarLogsMineracao;
			//MineracaoHelper.VerificaoRentabilidade += MineracaoHelper_VerificaoRentabilidade;

			//Inicializar configurações e opções do TaskBarIcon
			try
			{
				Global.ConfigGeralAtiva = ConfigGeralHelper.GetEntidade("Ativo = 1");
				if (Global.ConfigGeralAtiva == null)
				{
					Global.ConfigGeralAtiva = new();
					Global.ConfigGeralAtiva.Descricao = "Configuração Geral";
					Global.ConfigGeralAtiva.Ativo = true;

					if (!ConfigGeralHelper.GravarEntidade(Global.ConfigGeralAtiva))
					{
						Global.ConfigGeralAtiva = null;
						LogHelper.EscreveLog(LogLevel.Error, "Falha ao criar configuração geral base automaticamente! É necessário validar o código! (não houve exceção)");
						XtraMessageBox.Show("Não foi possível criar uma configuração geral base, por favor considere criar uma manualmente.",
						"Configuração Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

				ToolStripMenuItem item = TaskBarIcon.AdicionarItem(Taskbar.Mineracao);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Iniciar, Taskbar_IniciarClick, true);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Parar, Taskbar_PararClick, false);

				AlgoritmosItem = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Algoritmo, null, true);
				CustomNotifyIcon.AdicionarSubItems_FromEnum<Algoritmo>(AlgoritmosItem);

				if (AlgoritmosItem.DropDownItems[(Global.ConfigGeralAtiva.Algoritmo ?? Algoritmo.Rentabilidade).GetDescricaoEnum()] is ToolStripMenuItem rentabilidadeItem)
					rentabilidadeItem.Checked = true;
				else
					throw new Exception("Houve uma falha ao pré-ativar o algoritmo definido!");

				ToggleEventosItems(AlgoritmosItem.DropDownItems, AlgoritmoItem_CheckedChanged, true);

				MineradoresItem = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Mineradores, null, false);

				TaskBarIcon.AdicionarItem(Taskbar.Configuracoes); //TODO: Implementar
				TaskBarIcon.AdicionarItem(Taskbar.Sair, async (_, _) => await FecharAplicacao(), true);

				//TaskBarIcon.NotifyIcon.DoubleClick += (object sender, EventArgs e) => this.Show();
				TaskBarIcon.NotifyIcon.Visible = true;
			}
			catch (Exception ex)
			{
				Global.ConfigGeralAtiva = null;
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show(text: "Erro ao carregar!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#region Eventos MineracaoHelper
		private void MineracaoHelper_AlteracaoEstadoMineracao(object sender, AlteracaoEstadoMineracaoEventArgs e)
		{
			SyncContext.Post(_ =>
			{ //Dava para usar o CustomNotifyIcon.GetItem_Recursivo para obter ambos os items (Iniciar e Parar), mas assim deve ser mais otimizado em princípio
				if (CustomNotifyIcon.GetItem_Recursivo(TaskBarIcon.Items, Taskbar.Mineracao) is ToolStripMenuItem mineracaoItem)
				{
					bool notAtiva = !e.Ativa;
					mineracaoItem.DropDownItems[Taskbar_Mineracao.Iniciar].Visible = notAtiva;
					mineracaoItem.DropDownItems[Taskbar_Mineracao.Parar].Visible = e.Ativa;
					AlgoritmosItem.Enabled = notAtiva;
					MineradoresItem.Enabled = notAtiva;
					TaskBarIcon.NotifyIcon.Text = e.Ativa ? "Ativo" : "Inativo";
				}
			}, null);

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
		private async Task FecharAplicacao()
		{
			try
			{
				if (MineracaoHelper.ProcessoAtivo != null &&
					XtraMessageBox.Show("Existe um processo de mineração ativo, pretende continuar?", "Crypto Mining Manager",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					await MineracaoHelper.Parar();
				}
				Application.Exit();
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
