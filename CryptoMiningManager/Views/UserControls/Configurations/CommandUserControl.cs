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

namespace CryptoMiningManager.Views.UserControls.Configuracoes;

public partial class CommandUserControl : DevExpress.XtraEditors.XtraUserControl
{
	private EntityConfigurationHelper ConfiguracoesEntidadesHelper { get; }
	private IEntityHelper<Command> EntidadesHelper { get; }

	public CommandUserControl(EntityConfigurationHelper configuracoesEntidadesHelper, IEntityHelper<Command> entidadesHelper)
	{
		InitializeComponent();

		ConfiguracoesEntidadesHelper = configuracoesEntidadesHelper;
		EntidadesHelper = entidadesHelper;
	}

	private async void ComandosUserControl_Load(object sender, EventArgs e)
	{
		await AtualizarDados();
		ComandosGV.BestFitColumns(true);
	}

	private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		await AtualizarDados();
	}

	private void NovoBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		ConfiguracoesEntidadesHelper.AbrirEditorUC<Command>("Novo Comando", ActiveControl);
	}

	private void ComandosGV_DoubleClick(object sender, EventArgs e)
	{
		ConfiguracoesEntidadesHelper.DuploCliqueEntidade<Command>(e, ComandosGV, ActiveControl);
	}

	private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		ConfiguracoesEntidadesHelper.EditarEntidade<Command>(ComandosGV, ActiveControl);
	}

	private async void EliminarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			if (ComandosGV.SelectedRowsCount == 0 ||
				XtraMessageBox.Show("Pretende eliminar os comandos selecionados?", "Eliminar comandos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
				return;

			int[] linhasSelecionadas = ComandosGV.GetSelectedRows();
			int[] idComandos = new int[linhasSelecionadas.Length];

			for (int i = 0; i < linhasSelecionadas.Length; i++)
			{
				idComandos[i] = (int)ComandosGV.GetRowCellValue(linhasSelecionadas[i], colId);
			}

			ComandosGV.BeginUpdate();
			if (await EntidadesHelper.EliminarEntidades(idComandos) == linhasSelecionadas.Length)
			{
				ComandosGV.DeleteSelectedRows();

				XtraMessageBox.Show("Comandos eliminados com sucesso!", "Comandos eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				//Atualizam-se os dados todos porque não se sabe exatamente quais as entidades eliminadas
				await AtualizarDados();
				XtraMessageBox.Show("Alguns comandos não foram eliminados.", "Comandos eliminados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		catch (Exception ex)
		{
			LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao eliminar os comandos selecionados.");
			XtraMessageBox.Show($"Erro ao eliminar os comandos selecionados.{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			ComandosGV.EndUpdate();
		}
	}

	//FUNÇÕES AUXILIARES
	private async Task AtualizarDados()
	{

		IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(ComandosGC);
		ComandosGV.BeginDataUpdate();
		try
		{
			ComandosBindingSource.Clear();
			foreach (Command comando in await EntidadesHelper.GetEntidades())
			{
				ComandosBindingSource.Add(comando);
			}
		}
		catch (Exception ex)
		{
			LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao carregar dados.");
			XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			ComandosGV.EndDataUpdate();
			splashScreenHandler.Dispose();
		}
	}
}
