using CryptoMiningManager.Helpers;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
	internal partial class MineradoresUserControl : DevExpress.XtraEditors.XtraUserControl
	{
		private ConfiguracoesEntidadesHelper ConfiguracoesEntidadesHelper { get; }
		private IEntidadesHelper<Minerador> EntidadesHelper { get; }

		public MineradoresUserControl(ConfiguracoesEntidadesHelper configuracoesEntidadesHelper, IEntidadesHelper<Minerador> entidadesHelper)
		{
			InitializeComponent();

			ConfiguracoesEntidadesHelper = configuracoesEntidadesHelper;
			EntidadesHelper = entidadesHelper;
		}

		private async void MineradoresUserControl_Load(object sender, EventArgs e)
		{
			await AtualizarDados();
			MineradoresGV.BestFitColumns(true);
		}

		private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			await AtualizarDados();
		}

		private void NovoBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ConfiguracoesEntidadesHelper.AbrirEditorUC<Minerador>("Novo Minerador", ActiveControl);
		}

		private void MineradoresGV_DoubleClick(object sender, EventArgs e)
		{
			ConfiguracoesEntidadesHelper.DuploCliqueEntidade<Minerador>(e, MineradoresGV, ActiveControl);
		}

		private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ConfiguracoesEntidadesHelper.EditarEntidade<Minerador>(MineradoresGV, ActiveControl);
		}

		private async void EliminarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (MineradoresGV.SelectedRowsCount == 0 || !MessageBoxesHelper.PerguntaSimples("Pretende eliminar os mineradores selecionados?", "Eliminar mineradores"))
					return;

				int[] linhasSelecionadas = MineradoresGV.GetSelectedRows();
				int[] idMineradores = new int[linhasSelecionadas.Length];

				for (int i = 0; i < linhasSelecionadas.Length; i++)
				{
					idMineradores[i] = (int)MineradoresGV.GetRowCellValue(linhasSelecionadas[i], colIdMinerador);
				}

				MineradoresGV.BeginUpdate();
				if (await EntidadesHelper.EliminarEntidades(idMineradores) == linhasSelecionadas.Length)
				{
					MineradoresGV.DeleteSelectedRows();

					MessageBoxesHelper.MostraInformacao("Mineradores eliminados com sucesso!", "Mineradores eliminados");
				}
				else
				{
					//Atualizam-se os dados todos porque não se sabe exatamente quais as entidades eliminadas
					await AtualizarDados();
					MessageBoxesHelper.MostraAviso("Alguns mineradores não foram eliminados.", "Mineradores eliminados");
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao eliminar os mineradores selecionados.");
				MessageBoxesHelper.MostraErro("Erro ao eliminar os mineradores selecionados", ex: ex);
			}
			finally
			{
				MineradoresGV.EndUpdate();
			}
		}

		//MÉTODOS AUXILIARES
		private async Task AtualizarDados()
		{
			IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MineradoresGC);
			MineradoresGV.BeginDataUpdate();
			try
			{
				MineradoresBindingSource.Clear();
				foreach (KeyValuePair<int, Minerador> minerador in await EntidadesHelper.GetEntidadesComLista(ordenacao: "mi.Id, mo.Id"))
				{
					MineradoresBindingSource.Add(minerador.Value);
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao carregar dados.");
				MessageBoxesHelper.MostraErro("Erro ao carregar dados!", "Erro ao carregar dados", ex: ex);
			}
			finally
			{
				MineradoresGV.EndDataUpdate();
				splashScreenHandler.Dispose();
			}
		}
	}
}
