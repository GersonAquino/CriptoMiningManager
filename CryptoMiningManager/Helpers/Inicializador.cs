using CryptoMiningManager.Constants;
using CryptoMiningManager.CustomControls;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.EventArgs;
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

		public void Inicializar(EventHandler taskbarSairClick)
		{
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
						MessageBoxesHelper.MostraErro("Não foi possível criar uma configuração geral base, por favor considere criar uma manualmente.", "Configuração Geral");
					}
				}

				Inicializar_Base(taskbarSairClick);
			}
			catch (Exception ex)
			{
				Global.ConfigGeralAtiva = null;
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErroCritico("Erro ao inicializar ícone na barra de tarefas!", ex: ex);
			}
		}


		public async Task InicializarAsync(EventHandler taskbarSairClick)
		{
			try
			{
				Global.ConfigGeralAtiva = await ConfigGeralHelper.GetEntidadeAsync("Ativo = 1");
				if (Global.ConfigGeralAtiva == null)
				{
					Global.ConfigGeralAtiva = new();
					Global.ConfigGeralAtiva.Descricao = "Configuração Geral";
					Global.ConfigGeralAtiva.Ativo = true;

					if (!await ConfigGeralHelper.GravarEntidadeAsync(Global.ConfigGeralAtiva))
					{
						Global.ConfigGeralAtiva = null;
						LogHelper.EscreveLog(LogLevel.Error, "Falha ao criar configuração geral base automaticamente! É necessário validar o código! (não houve exceção)");
						MessageBoxesHelper.MostraErro("Não foi possível criar uma configuração geral base, por favor considere criar uma manualmente.", "Configuração Geral");
					}
				}

				Inicializar_Base(taskbarSairClick);
			}
			catch (Exception ex)
			{
				Global.ConfigGeralAtiva = null;
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErroCritico("Erro ao inicializar ícone na barra de tarefas!", ex: ex);
			}
		}

		private void Inicializar_Base(EventHandler taskbarSairClick)
		{
			TaskBarIcon.NotifyIcon.Text = "Inativo";

			ToolStripMenuItem item = TaskBarIcon.AdicionarItem(Taskbar.Mineracao);
			CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Iniciar, Taskbar_IniciarClick, true);
			CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Parar, Taskbar_PararClick, false);

			Global.AlgoritmosTB = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Algoritmo, null, true);
			CustomNotifyIcon.AdicionarSubItems_FromEnum<Algoritmo>(Global.AlgoritmosTB);

			if (Global.AlgoritmosTB.DropDownItems[(Global.ConfigGeralAtiva.Algoritmo ?? Algoritmo.Rentabilidade).GetDescricaoEnum()] is ToolStripMenuItem rentabilidadeItem)
				rentabilidadeItem.Checked = true;
			else
				throw new Exception("Houve uma falha ao pré-ativar o algoritmo definido!");

			CustomNotifyIcon.ToggleEventosItems(Global.AlgoritmosTB.DropDownItems, AlgoritmoItem_CheckedChanged, true);

			Global.MineradoresRB = CustomNotifyIcon.AdicionarSubItem(item, Taskbar_Mineracao.Mineradores, null, false);

			TaskBarIcon.AdicionarItem(Taskbar.Sair, taskbarSairClick, true);
		}

		#region Eventos TaskbarIcon
		private void AlgoritmoItem_CheckedChanged(object sender, EventArgs e)
		{
			CustomNotifyIcon.UniqueCheckedChanged(sender, Global.AlgoritmosTB.DropDownItems, AlgoritmoItem_CheckedChanged, "algoritmo", async itemAlterado => //Isto ser async pode ou não causar erros, não tenho 100% certeza
			{
				switch ((Algoritmo)itemAlterado.Tag)
				{
					case Algoritmo.Minerador: //Criar os items de mineradores
						Global.MineradoresRB.DropDownItems.Clear();

						foreach (Minerador minerador in (await MineracaoHelper.GetMineradoresAtivosPorMoeda()).Values)
						{
							CustomNotifyIcon.AdicionarSubItem(Global.MineradoresRB, minerador.Nome, MineradorItem_CheckedChanged, true, true, minerador);
						}

						if (Global.MineradoresRB.DropDownItems.Count != 0)
						{
							ToolStripMenuItem primeiroMinerador = (ToolStripMenuItem)Global.MineradoresRB.DropDownItems[0];
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
							CustomNotifyIcon.AdicionarSubItem(Global.MineradoresRB, "Não existem mineradores ativos", null, true).Enabled = false;

						Global.MineradoresRB.Visible = true;
						break;
					case Algoritmo.Rentabilidade:
						Global.MineradoresRB.Visible = false;
						break;
					default:
						break;
				}
			});

		}

		private void MineradorItem_CheckedChanged(object sender, EventArgs e)
		{
			CustomNotifyIcon.UniqueCheckedChanged(sender, Global.MineradoresRB.DropDownItems, MineradorItem_CheckedChanged, "minerador");
		}

		private async void Taskbar_IniciarClick(object sender, EventArgs e)
		{
			try
			{
				ToolStripItem item = CustomNotifyIcon.GetItem_Recursivo(Global.AlgoritmosTB.DropDownItems, i => i is ToolStripMenuItem item && item.Checked);
				Algoritmo algoritmo = (Algoritmo)item.Tag;

				switch (algoritmo)
				{
					case Algoritmo.Minerador:
						item = CustomNotifyIcon.GetItem_Recursivo(Global.MineradoresRB.DropDownItems, i => i is ToolStripMenuItem item && item.Checked);
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

		//Métodos auxiliares
		internal static void TratarAlteracaoEstadoMineracao(AlteracaoEstadoMineracaoEventArgs e, CustomNotifyIcon taskBarIcon)
		{
			//Dava para usar o CustomNotifyIcon.GetItem_Recursivo para obter ambos os items (Iniciar e Parar), mas assim deve ser mais otimizado em princípio
			if (CustomNotifyIcon.GetItem_Recursivo(taskBarIcon.Items, Taskbar.Mineracao) is not ToolStripMenuItem mineracaoItem)
				return;

			bool notAtiva = !e.Ativa;
			mineracaoItem.DropDownItems[Taskbar_Mineracao.Iniciar].Visible = notAtiva;
			mineracaoItem.DropDownItems[Taskbar_Mineracao.Parar].Visible = e.Ativa;
			Global.AlgoritmosTB.Enabled = notAtiva;
			Global.MineradoresRB.Enabled = notAtiva;
			taskBarIcon.NotifyIcon.Text = e.Ativa ? "Ativo" : "Inativo";
		}
	}
}
