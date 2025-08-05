using DataManager.Helpers;
using DeepCopy;
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

internal partial class CoinUserControl : DevExpress.XtraEditors.XtraUserControl
{
	private readonly IEntityHelper<Coin> EntidadesHelper;

	private Dictionary<int, Coin> MoedasOriginais;

	public CoinUserControl(IEntityHelper<Coin> entidadesHelper)
	{
		InitializeComponent();

		EntidadesHelper = entidadesHelper;
	}

	private async void MineradoresUserControl_Load(object sender, EventArgs e)
	{
		await AtualizarDados();
		MoedasGV.BestFitColumns(true);
	}

	private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		await AtualizarDados();
	}

	private void GravarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MoedasGC);
			List<Coin> moedasAlterar = new();
			foreach (Coin moeda in MoedasBindingSource.List)
			{
				if (MoedasOriginais[moeda.Id].Nome != moeda.Nome)
					moedasAlterar.Add(moeda);
			}

			if (moedasAlterar.Count != 0)
				EntidadesHelper.GravarEntidades(moedasAlterar);

			XtraMessageBox.Show("Alterações gravadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception ex)
		{
			LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
			XtraMessageBox.Show("Erro ao validar alterações!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	//FUNÇÕES AUXILIARES
	private async Task AtualizarDados()
	{
		IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MoedasGC);
		MoedasGV.BeginDataUpdate();
		try
		{
			List<Coin> moedas = await EntidadesHelper.GravarEntidades();

			MoedasBindingSource.Clear();
			MoedasOriginais = new Dictionary<int, Coin>(moedas.Count);

			moedas.ForEach(m =>
			{
				MoedasBindingSource.Add(m);
				Coin copia = DeepCopier.Copy(m);
				MoedasOriginais.Add(copia.Id, copia);
			});

			return;
		}
		catch (Exception ex)
		{
			LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao carregar dados.");
			XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			MoedasGV.EndDataUpdate();
			splashScreenHandler.Dispose();
		}
	}
}
