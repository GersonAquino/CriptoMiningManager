using CryptoMiningManager.Helpers;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
	internal partial class ConfiguracoesGeraisUserControl : DevExpress.XtraEditors.XtraUserControl
	{
		private ConfiguracoesEntidadesHelper ConfiguracoesEntidadesHelper { get; }
		private IEntidadesHelper<ConfiguracaoGeral> EntidadesHelper { get; }

		public ConfiguracoesGeraisUserControl(ConfiguracoesEntidadesHelper configuracoesEntidadesHelper, IEntidadesHelper<ConfiguracaoGeral> entidadesHelper)
		{
			InitializeComponent();

			ConfiguracoesEntidadesHelper = configuracoesEntidadesHelper;
			EntidadesHelper = entidadesHelper;
		}

		private async void ConfiguracoesGeraisUserControl_Load(object sender, EventArgs e)
		{
			await AtualizarDados();
			ConfigsGeraisGV.BestFitColumns(true);
		}

		private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			await AtualizarDados();
		}

		private void NovoBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ConfiguracoesEntidadesHelper.AbrirEditorUC<ConfiguracaoGeral>("Nova Configuração Geral", ActiveControl);
		}

		private void ConfigsGeraisGV_DoubleClick(object sender, EventArgs e)
		{
			ConfiguracoesEntidadesHelper.DuploCliqueEntidade<ConfiguracaoGeral>(e, ConfigsGeraisGV, ActiveControl);
		}

		private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ConfiguracoesEntidadesHelper.EditarEntidade<ConfiguracaoGeral>(ConfigsGeraisGV, ActiveControl);
		}

		private async void EliminarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (ConfigsGeraisGV.SelectedRowsCount == 0 ||
					!MessageBoxesHelper.PerguntaSimples("Pretende eliminar as configurações gerais selecionadas?", "Eliminar configurações gerais"))
					return;

				int[] linhasSelecionadas = ConfigsGeraisGV.GetSelectedRows();
				int[] idConfigsGerais = new int[linhasSelecionadas.Length];

				bool configAtivaSelecionada = false;

				for (int i = 0; i < linhasSelecionadas.Length; i++)
				{
					if (ConfigsGeraisGV.IsDataRow(linhasSelecionadas[i]) && ConfigsGeraisGV.GetRow(linhasSelecionadas[i]) is ConfiguracaoGeral configGeral)
					{
						idConfigsGerais[i] = configGeral.Id;

						if (configGeral.Ativo)
						{
							if (!MessageBoxesHelper.PerguntaSimples("Está prestes a eliminar a configuração geral ativa, pretende continuar?",
								"Configuração geral ativa selecionada", MessageBoxIcon.Warning))
								return;

							configAtivaSelecionada = true;
						}
					}

					idConfigsGerais[i] = (int)ConfigsGeraisGV.GetRowCellValue(linhasSelecionadas[i], colId);
				}

				ConfigsGeraisGV.BeginUpdate();
				if (await EntidadesHelper.EliminarEntidades(idConfigsGerais) == linhasSelecionadas.Length)
				{
					ConfigsGeraisGV.DeleteSelectedRows();

					if (configAtivaSelecionada)
						Global.ConfigGeralAtiva = null;

					MessageBoxesHelper.MostraInformacao("Configurações gerais eliminadas com sucesso!", "Configurações gerais eliminadas");
				}
				else
				{
					//Atualizam-se os dados todos porque não se sabe exatamente quais as entidades eliminadas
					await AtualizarDados();
					MessageBoxesHelper.MostraAviso("Alguns configurações gerais não foram eliminadas.", "Configurações gerais eliminadas");
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao eliminar os configurações gerais selecionadas.");
				MessageBoxesHelper.MostraErro("Erro ao eliminar os configurações gerais selecionadas.", ex: ex);
			}
			finally
			{
				ConfigsGeraisGV.EndUpdate();
			}
		}

		//MÉTODOS AUXILIARES
		private async Task AtualizarDados()
		{
			IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(ConfigsGeraisGC);
			ConfigsGeraisGV.BeginDataUpdate();
			try
			{
				ConfigsGeraisBindingSource.Clear();
				foreach (ConfiguracaoGeral configGeral in await EntidadesHelper.GetEntidades())
				{
					ConfigsGeraisBindingSource.Add(configGeral);
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao carregar dados.");
				MessageBoxesHelper.MostraErro("Erro ao carregar dados!", "Erro ao carregar dados", ex: ex);
			}
			finally
			{
				ConfigsGeraisGV.EndDataUpdate();
				splashScreenHandler.Dispose();
			}
		}
	}
}
