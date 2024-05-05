using Autofac;
using DeepCopy;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    internal partial class MoedasUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly string URLRentabilidade;

        private readonly IDados Dados;
        private readonly IHttpHelper HttpHelper;
        private readonly IEntidadesHelper<Moeda> EntidadesHelper;

        private Dictionary<int, Moeda> MoedasOriginais;

        public MoedasUserControl(IDados dados, IEntidadesHelper<Moeda> entidadesHelper, IHttpHelper httpHelper)
        {
            InitializeComponent();

            Dados = dados;
            EntidadesHelper = entidadesHelper;
            HttpHelper = httpHelper;
        }

        private async void MineradoresUserControl_Load(object sender, EventArgs e)
        {
            await AtualizarDados();
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

                    XtraMessageBox.Show("Alterações gravadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MoedasGV.EndDataUpdate();
                MoedasGV.BestFitColumns(true);
                splashScreenHandler.Dispose();
            }
        }
    }
}
