using CryptoMiningManager.Helpers;
using DataManager.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Models.Classes;
using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes;

internal partial class MinerUserControl : DevExpress.XtraEditors.XtraUserControl
{
	private EntityConfigurationHelper ConfiguracoesEntidadesHelper { get; }
	private IEntityHelper<Miner> EntidadesHelper { get; }

	public MinerUserControl(EntityConfigurationHelper configuracoesEntidadesHelper, IEntityHelper<Miner> entidadesHelper)
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
		ConfiguracoesEntidadesHelper.AbrirEditorUC<Miner>("Novo Minerador", ActiveControl);
	}

	private void MineradoresGV_DoubleClick(object sender, EventArgs e)
	{
		ConfiguracoesEntidadesHelper.DuploCliqueEntidade<Miner>(e, MineradoresGV, ActiveControl);
	}

	private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		ConfiguracoesEntidadesHelper.EditarEntidade<Miner>(MineradoresGV, ActiveControl);
	}

	private async void EliminarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			if (MineradoresGV.SelectedRowsCount == 0 ||
				XtraMessageBox.Show("Pretende eliminar os mineradores selecionados?", "Eliminar mineradores", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
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

				XtraMessageBox.Show("Mineradores eliminados com sucesso!", "Mineradores eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				//Atualizam-se os dados todos porque não se sabe exatamente quais as entidades eliminadas
				await AtualizarDados();
				XtraMessageBox.Show("Alguns mineradores não foram eliminados.", "Mineradores eliminados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		catch (Exception ex)
		{
			LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao eliminar os mineradores selecionados.");
			XtraMessageBox.Show($"Erro ao eliminar os mineradores selecionados.{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			MineradoresGV.EndUpdate();
		}
	}

	//FUNÇÕES AUXILIARES
	private async Task AtualizarDados()
	{
		IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MineradoresGC);
		MineradoresGV.BeginDataUpdate();
		try
		{
			MineradoresBindingSource.Clear();
			foreach (KeyValuePair<int, Miner> minerador in await EntidadesHelper.GetEntidadesComLista(ordenacao: "mi.Id, mo.Id"))
			{
				MineradoresBindingSource.Add(minerador.Value);
			}
		}
		catch (Exception ex)
		{
			LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao carregar dados.");
			XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			MineradoresGV.EndDataUpdate();
			splashScreenHandler.Dispose();
		}
	}
}
