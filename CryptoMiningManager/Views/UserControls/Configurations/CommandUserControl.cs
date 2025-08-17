using CryptoMiningManager.Helpers;
using DataManager.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Models.Classes;
using Models.Enums;
using Models.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configurations;

public partial class CommandUserControl : XtraUserControl
{
	private EntityConfigurationHelper EntityConfigurationHelper { get; }
	private IEntityHelper<Command> EntityHelper { get; }

	public CommandUserControl(EntityConfigurationHelper entityConfigurationHelper, IEntityHelper<Command> entityHelper)
	{
		InitializeComponent();

		EntityConfigurationHelper = entityConfigurationHelper;
		EntityHelper = entityHelper;
	}

	private async void CommandUserControl_Load(object sender, EventArgs e)
	{
		await RefreshData();
		CommandGV.BestFitColumns(true);
	}

	private async void RefreshBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		await RefreshData();
	}

	private void NovoBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		EntityConfigurationHelper.OpenEditorTab<Command>("Novo Comando", ActiveControl);
	}

	private void CommandGV_DoubleClick(object sender, EventArgs e)
	{
		EntityConfigurationHelper.EntityDoubleClick<Command>(e, CommandGV, ActiveControl);
	}

	private void EditBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		EntityConfigurationHelper.EditEntity<Command>(CommandGV, ActiveControl);
	}

	private async void DeleteBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			if (CommandGV.SelectedRowsCount == 0 ||
				XtraMessageBox.Show("Pretende eliminar os comandos selecionados?", "Eliminar comandos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
				return;

			int[] selectedRows = CommandGV.GetSelectedRows();
			int[] commandIds = new int[selectedRows.Length];

			for (int i = 0; i < selectedRows.Length; i++)
			{
				commandIds[i] = (int)CommandGV.GetRowCellValue(selectedRows[i], colId);
			}

			CommandGV.BeginUpdate();
			if (await EntityHelper.DeleteEntities(commandIds) == selectedRows.Length)
			{
				CommandGV.DeleteSelectedRows();

				XtraMessageBox.Show("Comandos eliminados com sucesso!", "Comandos eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				//Atualizam-se os dados todos porque não se sabe exatamente quais as entidades eliminadas
				await RefreshData();
				XtraMessageBox.Show("Alguns comandos não foram eliminados.", "Comandos eliminados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao eliminar os comandos selecionados.");
			XtraMessageBox.Show($"Erro ao eliminar os comandos selecionados.{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			CommandGV.EndUpdate();
		}
	}

	//FUNÇÕES AUXILIARES
	private async Task RefreshData()
	{

		CommandGV.BeginDataUpdate();
		try
		{
			using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(ComandosGC);
			CommandsBindingSource.Clear();
			foreach (Command comando in await EntityHelper.GetEntities())
			{
				CommandsBindingSource.Add(comando);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao carregar dados.");
			XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			CommandGV.EndDataUpdate();
		}
	}
}
