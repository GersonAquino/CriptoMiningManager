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

        public MoedasUserControl(IHttpHelper httpHelper, IEntidadesHelper<Moeda> entidadesHelper, IDados dados)
        {
            InitializeComponent();

            Dados = dados;
            EntidadesHelper = entidadesHelper;
            HttpHelper = httpHelper;

            URLRentabilidade = ConfigurationManager.AppSettings["URLRentabilidade"];
        }

        private async void MineradoresUserControl_Load(object sender, EventArgs e)
        {
            await AtualizarDados();
        }

        private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await AtualizarDados();
        }

        //FUNÇÕES AUXILIARES
        private async Task AtualizarDados()
        {
            IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MoedasGC);
            MoedasGV.BeginDataUpdate();
            try
            {
                MoedasBindingSource.Clear();

                List<Moeda> moedasAPI = (await HttpHelper.PedidoGETHttpSingle<Moedas>(URLRentabilidade)).GetMoedas();
                Dictionary<int, Moeda> moedasExistentes = (await EntidadesHelper.GetEntidades("IdExterno IN @IdsExternos", null, ("IdsExternos", moedasAPI.Select(m => m.IdExterno)))).ToDictionary(m => m.IdExterno);

                moedasAPI.ForEach(moeda =>
                {
                    if (moedasExistentes.TryGetValue(moeda.IdExterno, out Moeda moedaExistente))
                    {
                        moeda.Id = moedaExistente.Id;
                        moeda.Nome = moedaExistente.Nome;
                    }
                    else
                    {
                        moeda.Id = -1;
                        moeda.Nome = null;
                    }

                    //Faz-se antes do Merge só para evitar mais um loop à lista de moedas inteira, em caso de erro depois limpa-se o data source
                    MoedasBindingSource.Add(moeda);
                });

                try
                {
                    await Dados.BulkMerge(moedasAPI.ToArray());
                }
                catch
                {
                    MoedasBindingSource.Clear();
                    throw;
                }
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
