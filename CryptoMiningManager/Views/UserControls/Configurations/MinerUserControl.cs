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

namespace CryptoMiningManager.Views.UserControls.Configurations;

internal partial class MinerUserControl : XtraUserControl
{
	private EntityConfigurationHelper EntityConfigurationHelper { get; }
	private IEntityHelper<Miner> EntityHelper { get; }

	public MinerUserControl(EntityConfigurationHelper entityConfigurationHelper, IEntityHelper<Miner> entityHelper)
	{
		InitializeComponent();

		EntityConfigurationHelper = entityConfigurationHelper;
		EntityHelper = entityHelper;
	}

	private async void MinerUserControl_Load(object sender, EventArgs e)
	{
		await RefreshData();
		MinerGV.BestFitColumns(true);
	}

	private async void RefreshBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		await RefreshData();
	}

	private void NewBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		EntityConfigurationHelper.OpenEditorTab<Miner>("Novo Minerador", ActiveControl);
	}

	private void MinerGV_DoubleClick(object sender, EventArgs e)
	{
		EntityConfigurationHelper.EntityDoubleClick<Miner>(e, MinerGV, ActiveControl);
	}

	private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		EntityConfigurationHelper.EditEntity<Miner>(MinerGV, ActiveControl);
	}

	private async void DeleteBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			if (MinerGV.SelectedRowsCount == 0 ||
				XtraMessageBox.Show("Pretende eliminar os mineradores selecionados?", "Eliminar mineradores", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
				return;

			int[] selectedRows = MinerGV.GetSelectedRows();
			int[] minerIds = new int[selectedRows.Length];

			for (int i = 0; i < selectedRows.Length; i++)
			{
				minerIds[i] = (int)MinerGV.GetRowCellValue(selectedRows[i], colMinerId);
			}

			MinerGV.BeginUpdate();
			if (await EntityHelper.DeleteEntities(minerIds) == selectedRows.Length)
			{
				MinerGV.DeleteSelectedRows();

				XtraMessageBox.Show("Mineradores eliminados com sucesso!", "Mineradores eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				//Atualizam-se os dados todos porque não se sabe exatamente quais as entidades eliminadas
				await RefreshData();
				XtraMessageBox.Show("Alguns mineradores não foram eliminados.", "Mineradores eliminados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao eliminar os mineradores selecionados.");
			XtraMessageBox.Show($"Erro ao eliminar os mineradores selecionados.{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			MinerGV.EndUpdate();
		}
	}

	//FUNÇÕES AUXILIARES
	private async Task RefreshData()
	{
		MinerGV.BeginDataUpdate();
		try
		{
			using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MinersGC);
			MinersBindingSource.Clear();
			foreach (KeyValuePair<int, Miner> miner in await EntityHelper.GetEntitiesWithList(sorting: "mi.Id, mo.Id"))
			{
				MinersBindingSource.Add(miner.Value);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao carregar dados.");
			XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			MinerGV.EndDataUpdate();
		}
	}
}
