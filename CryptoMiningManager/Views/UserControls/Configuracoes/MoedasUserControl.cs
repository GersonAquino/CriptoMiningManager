using CryptoMiningManager.Helpers;
using DeepCopy;
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
	internal partial class MoedasUserControl : DevExpress.XtraEditors.XtraUserControl
	{
		private readonly IEntidadesHelper<Moeda> EntidadesHelper;

		private Dictionary<int, Moeda> MoedasOriginais;

		public MoedasUserControl(IEntidadesHelper<Moeda> entidadesHelper)
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
				using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MoedasGC))
				{
					List<Moeda> moedasAlterar = new();
					foreach (Moeda moeda in MoedasBindingSource.List)
					{
						if (MoedasOriginais[moeda.Id].Nome != moeda.Nome)
							moedasAlterar.Add(moeda);
					}

					if (moedasAlterar.Count != 0)
						EntidadesHelper.GravarEntidades(moedasAlterar);

					MessageBoxesHelper.MostraInformacao("Alterações gravadas com sucesso!", "Sucesso");
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				MessageBoxesHelper.MostraErro("Erro ao validar alterações!", "Erro");
			}
		}

		//MÉTODOS AUXILIARES
		private async Task AtualizarDados()
		{
			IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MoedasGC);
			MoedasGV.BeginDataUpdate();
			try
			{
				List<Moeda> moedas = await EntidadesHelper.GravarEntidades();

				MoedasBindingSource.Clear();
				MoedasOriginais = new Dictionary<int, Moeda>(moedas.Count);

				moedas.ForEach(m =>
				{
					MoedasBindingSource.Add(m);
					Moeda copia = DeepCopier.Copy(m);
					MoedasOriginais.Add(copia.Id, copia);
				});

				return;
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao carregar dados.");
				MessageBoxesHelper.MostraErro("Erro ao carregar dados!", "Erro ao carregar dados", ex: ex);
			}
			finally
			{
				MoedasGV.EndDataUpdate();
				splashScreenHandler.Dispose();
			}
		}
	}
}
