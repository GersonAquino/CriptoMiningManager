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

namespace CryptoMiningManager.Views.UserControls.Configurations;

internal partial class CoinUserControl : XtraUserControl
{
	private readonly IEntityHelper<Coin> EntityHelper;

	private Dictionary<int, Coin> OriginalCoins;

	public CoinUserControl(IEntityHelper<Coin> entidadesHelper)
	{
		InitializeComponent();

		EntityHelper = entidadesHelper;
	}

	private async void CoinUserControl_Load(object sender, EventArgs e)
	{
		await RefreshData();
		CoinGV.BestFitColumns(true);
	}

	private async void RefreshBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		await RefreshData();
	}

	private void SaveBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MoedasGC);
			List<Coin> coinsToUpdate = new();
			foreach (Coin coin in CoinBindingSource.List)
			{
				if (OriginalCoins[coin.Id].Name != coin.Name)
					coinsToUpdate.Add(coin);
			}

			if (coinsToUpdate.Count != 0)
				EntityHelper.SaveEntities(coinsToUpdate);

			XtraMessageBox.Show("Alterações gravadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro");
			XtraMessageBox.Show("Erro ao validar alterações!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	//FUNÇÕES AUXILIARES
	private async Task RefreshData()
	{
		using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MoedasGC);
		CoinGV.BeginDataUpdate();
		try
		{
			List<Coin> coins = await EntityHelper.SaveEntities();

			CoinBindingSource.Clear();
			OriginalCoins = new Dictionary<int, Coin>(coins.Count);

			coins.ForEach(m =>
			{
				CoinBindingSource.Add(m);
				Coin copy = DeepCopier.Copy(m);
				OriginalCoins.Add(copy.Id, copy);
			});

			return;
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao carregar dados.");
			XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			CoinGV.EndDataUpdate();
		}
	}
}
