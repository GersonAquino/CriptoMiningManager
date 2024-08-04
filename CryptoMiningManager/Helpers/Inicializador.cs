using CryptoMiningManager.Constants;
using CryptoMiningManager.CustomControls;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace CryptoMiningManager.Helpers
{
	public class Inicializador
	{
		private readonly IEntidadesHelper<ConfiguracaoGeral> ConfigGeralHelper;

		private readonly CustomNotifyIcon TaskBarIcon;
		private readonly MineracaoHelper MineracaoHelper;

		public Inicializador(IEntidadesHelper<ConfiguracaoGeral> configGeralHelper, CustomNotifyIcon notifyIcon, MineracaoHelper mineracaoHelper)
		{
			ConfigGeralHelper = configGeralHelper;
			MineracaoHelper = mineracaoHelper;
			TaskBarIcon = notifyIcon;
		}


		public async Task Inicializar(EventHandler taskbarSairClick)
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
						MessageBoxesHelper.MostraErro("Não foi possível criar uma configuração geral base, por favor considere criar uma manualmente.", "Configuração Geral");
					}
				}

				TaskBarIcon.NotifyIcon.Text = "Inativo";

				ToolStripMenuItem item = TaskBarIcon.AdicionarItem(Taskbar.Mineracao);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Iniciar, Taskbar_IniciarClick, true);
				CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Parar, Taskbar_PararClick, false);

				Global.AlgoritmosItem = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Algoritmo, null, true);
				CustomNotifyIcon.AdicionarSubItems_FromEnum<Algoritmo>(Global.AlgoritmosItem);

				if (Global.AlgoritmosItem.DropDownItems[(Global.ConfigGeralAtiva.Algoritmo ?? Algoritmo.Rentabilidade).GetDescricaoEnum()] is ToolStripMenuItem rentabilidadeItem)
					rentabilidadeItem.Checked = true;
				else
					throw new Exception("Houve uma falha ao pré-ativar o algoritmo definido!");

				CustomNotifyIcon.ToggleEventosItems(Global.AlgoritmosItem.DropDownItems, AlgoritmoItem_CheckedChanged, true);

				Global.MineradoresItem = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Mineradores, null, false);

				TaskBarIcon.AdicionarItem(Taskbar.Sair, taskbarSairClick, true);
			}
			catch (Exception ex)
			{
				Global.ConfigGeralAtiva = null;
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErroCritico("Erro ao inicializar ícone na barra de tarefas!", ex: ex);
			}
		}

		#region Eventos TaskbarIcon
		private void AlgoritmoItem_CheckedChanged(object sender, EventArgs e)
		{
			CustomNotifyIcon.UniqueCheckedChanged(sender, Global.AlgoritmosItem.DropDownItems, AlgoritmoItem_CheckedChanged, "algoritmo", itemAlterado =>
			{
				switch ((Algoritmo)itemAlterado.Tag)
				{
					case Algoritmo.Minerador: //Criar os items de mineradores
						Global.MineradoresItem.DropDownItems.Clear();

						foreach (Minerador minerador in MineracaoHelper.GetMineradoresAtivosPorMoeda().GetAwaiter().GetResult().Values)
						{
							CustomNotifyIcon.AdicionarSubItem(Global.MineradoresItem, minerador.Nome, MineradorItem_CheckedChanged, true, true, minerador);
						}

						if (Global.MineradoresItem.DropDownItems.Count != 0)
						{
							ToolStripMenuItem primeiroMinerador = (ToolStripMenuItem)Global.MineradoresItem.DropDownItems[0];
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
							CustomNotifyIcon.AdicionarSubItem(Global.MineradoresItem, "Não existem mineradores ativos", null, true).Enabled = false;

						Global.MineradoresItem.Visible = true;
						break;
					case Algoritmo.Rentabilidade:
						Global.MineradoresItem.Visible = false;
						break;
					default:
						break;
				}
			});

		}

		private void MineradorItem_CheckedChanged(object sender, EventArgs e)
		{
			CustomNotifyIcon.UniqueCheckedChanged(sender, Global.MineradoresItem.DropDownItems, MineradorItem_CheckedChanged, "minerador");
		}

		private async void Taskbar_IniciarClick(object sender, EventArgs e)
		{
			try
			{
				ToolStripItem item = CustomNotifyIcon.GetItem_Recursivo(Global.AlgoritmosItem.DropDownItems, i => i is ToolStripMenuItem item && item.Checked);
				Algoritmo algoritmo = (Algoritmo)item.Tag;

				switch (algoritmo)
				{
					case Algoritmo.Minerador:
						item = CustomNotifyIcon.GetItem_Recursivo(Global.MineradoresItem.DropDownItems, i => i is ToolStripMenuItem item && item.Checked);
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
				MessageBoxesHelper.MostraErroCritico("Erro ao iniciar mineração!", ex: ex);
			}
		}

		private async void Taskbar_PararClick(object sender, EventArgs e)
		{
			try
			{
				await MineracaoHelper.Parar_Async();
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao parar mineração pelo TaskbarIcon");
				MessageBoxesHelper.MostraErroCritico("Erro ao parar mineração!", ex: ex);
			}
		}
		#endregion
	}
}
