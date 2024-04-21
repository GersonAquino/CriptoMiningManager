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

        private readonly IHttpHelper HttpHelper;
        private readonly IEntidadesHelper<Moeda> EntidadesHelper;

        public MoedasUserControl(IHttpHelper httpHelper, IEntidadesHelper<Moeda> entidadesHelper)
        {
            InitializeComponent();

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

                var teste = await HttpHelper.PedidoGETHttpSingle<Moedas>(URLRentabilidade);

                List<Moeda> moedasAPI = (await HttpHelper.PedidoGETHttpSingle<Moedas>(URLRentabilidade)).GetMoedas();
                List<Moeda> moedas = (await EntidadesHelper.GetEntidades("IdExterno IN @Ids", null, ("Ids", moedasAPI.Select(m => m.IdExterno)))).ToList();

                //TODO: Ler os dados novos das moedas existentes e gravar as moedas novas, no fim atribuir todas as moedas ao BindingSource
                //ALSO: Remover a coluna IdMinerador da Moeda e meter um IdMoeda no Minerador, é o que faz sentido, ou talvez fazer uma relação many to many, mas isso talvez já seja complicar desnecessariamente

                for (int i = 0; i < moedasAPI.Count; i++)
                {

                }

                foreach (Moeda moeda in moedas)
                {
                    MoedasBindingSource.Add(moeda);
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
