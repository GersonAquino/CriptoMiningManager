using DevExpress.XtraEditors;
using GestorDados.Helpers;
using Modelos.Cripto;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private const string URLRentabilidade = "https://whattomine.com/coins.json?eth=true&factor%5Beth_hr%5D=87.0&factor%5Beth_p%5D=200.0&e4g=true&factor%5Be4g_hr%5D=87.0&factor%5Be4g_p%5D=200.0&zh=true&factor%5Bzh_hr%5D=188.0&factor%5Bzh_p%5D=240.0&cnh=true&factor%5Bcnh_hr%5D=0.0&factor%5Bcnh_p%5D=0.0&cng=true&factor%5Bcng_hr%5D=0.0&factor%5Bcng_p%5D=0.0&s5r=true&factor%5Bs5r_hr%5D=1.65&factor%5Bs5r_p%5D=150.0&cx=true&factor%5Bcx_hr%5D=7.4&factor%5Bcx_p%5D=260.0&ds=true&factor%5Bds_hr%5D=8.5&factor%5Bds_p%5D=180.0&cc=true&factor%5Bcc_hr%5D=0.0&factor%5Bcc_p%5D=0.0&pn=true&factor%5Bpn_hr%5D=12.0&factor%5Bpn_p%5D=270.0&sd=true&factor%5Bsd_hr%5D=45.0&factor%5Bsd_p%5D=220.0&ct32=true&factor%5Bct32_hr%5D=1.4&factor%5Bct32_p%5D=250.0&eqb=true&factor%5Beqb_hr%5D=0.0&factor%5Beqb_p%5D=0.0&b3=true&factor%5Bb3_hr%5D=3.6&factor%5Bb3_p%5D=250.0&ks=true&factor%5Bks_hr%5D=2.6&factor%5Bks_p%5D=210.0&al=true&factor%5Bal_hr%5D=170.0&factor%5Bal_p%5D=140.0&ops=true&factor%5Bops_hr%5D=87.0&factor%5Bops_p%5D=250.0&ir=true&factor%5Bir_hr%5D=34.0&factor%5Bir_p%5D=240.0&zlh=true&factor%5Bzlh_hr%5D=129.0&factor%5Bzlh_p%5D=280.0&kpw=true&factor%5Bkpw_hr%5D=51.0&factor%5Bkpw_p%5D=270.0&ppw=true&factor%5Bppw_hr%5D=0.0&factor%5Bppw_p%5D=0.0&nx=true&factor%5Bnx_hr%5D=175.0&factor%5Bnx_p%5D=300.0&fpw=true&factor%5Bfpw_hr%5D=46.0&factor%5Bfpw_p%5D=260.0&vh=true&factor%5Bvh_hr%5D=1.4&factor%5Bvh_p%5D=150.0&factor%5Bcost%5D=0.1&factor%5Bcost_currency%5D=EUR&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=binance&factor%5Bexchanges%5D%5B%5D=bitfinex&factor%5Bexchanges%5D%5B%5D=coinex&factor%5Bexchanges%5D%5B%5D=exmo&factor%5Bexchanges%5D%5B%5D=gate&factor%5Bexchanges%5D%5B%5D=graviex&factor%5Bexchanges%5D%5B%5D=hitbtc&factor%5Bexchanges%5D%5B%5D=ogre&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=xeggex&dataset=Main";

        private readonly HttpHelper Http;

        private bool HaAlteracaoNaRentabilidade = false;
        private Thread RentabilidadeThread = null;

        private Moeda MoedaMaisRentavel;

        public MainForm()
        {
            InitializeComponent();
            Http = new HttpHelper(new JsonHelper());
        }

        private void LerDadosBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (RentabilidadeThread == null)
                {
                    RentabilidadeThread = new Thread(async () => await VerificaRentabilidade()) { IsBackground = true };
                    RentabilidadeThread.Start();
                }

                //Moedas classe = await http.PedidoGETHttpSingle<Moedas>("https://whattomine.com/coins.json?eth=true&factor%5Beth_hr%5D=98.0&factor%5Beth_p%5D=260.0&e4g=true&factor%5Be4g_hr%5D=98.0&factor%5Be4g_p%5D=260.0&zh=true&factor%5Bzh_hr%5D=134.0&factor%5Bzh_p%5D=250.0&cnh=true&factor%5Bcnh_hr%5D=2400.0&factor%5Bcnh_p%5D=250.0&cng=true&factor%5Bcng_hr%5D=3700.0&factor%5Bcng_p%5D=250.0&s5r=true&factor%5Bs5r_hr%5D=1.0&factor%5Bs5r_p%5D=130.0&cx=true&factor%5Bcx_hr%5D=4.4&factor%5Bcx_p%5D=230.0&ds=true&factor%5Bds_hr%5D=0.0&factor%5Bds_p%5D=0.0&cc=true&factor%5Bcc_hr%5D=14.2&factor%5Bcc_p%5D=250.0&cr29=true&factor%5Bcr29_hr%5D=14.3&factor%5Bcr29_p%5D=250.0&sd=true&factor%5Bsd_hr%5D=0.0&factor%5Bsd_p%5D=0.0&ct32=true&factor%5Bct32_hr%5D=0.9&factor%5Bct32_p%5D=250.0&eqb=true&factor%5Beqb_hr%5D=46.5&factor%5Beqb_p%5D=250.0&b3=true&factor%5Bb3_hr%5D=2.1&factor%5Bb3_p%5D=270.0&ks=true&factor%5Bks_hr%5D=0.0&factor%5Bks_p%5D=0.0&al=true&factor%5Bal_hr%5D=202.0&factor%5Bal_p%5D=170.0&ops=true&factor%5Bops_hr%5D=77.0&factor%5Bops_p%5D=250.0&ir=true&factor%5Bir_hr%5D=0.0&factor%5Bir_p%5D=0.0&zlh=true&factor%5Bzlh_hr%5D=96.0&factor%5Bzlh_p%5D=260.0&kpw=true&factor%5Bkpw_hr%5D=46.0&factor%5Bkpw_p%5D=269.0&ppw=true&factor%5Bppw_hr%5D=38.9&factor%5Bppw_p%5D=250.0&nx=true&factor%5Bnx_hr%5D=0.0&factor%5Bnx_p%5D=0.0&fpw=true&factor%5Bfpw_hr%5D=41.0&factor%5Bfpw_p%5D=250.0&vh=true&factor%5Bvh_hr%5D=1.45&factor%5Bvh_p%5D=240.0&factor%5Bcost%5D=0.1&factor%5Bcost_currency%5D=EUR&sort=Profitability24&volume=0&revenue=24h&factor%5Bexchanges%5D%5B%5D=&factor%5Bexchanges%5D%5B%5D=binance&factor%5Bexchanges%5D%5B%5D=bitfinex&factor%5Bexchanges%5D%5B%5D=bitforex&factor%5Bexchanges%5D%5B%5D=bittrex&factor%5Bexchanges%5D%5B%5D=coinex&factor%5Bexchanges%5D%5B%5D=exmo&factor%5Bexchanges%5D%5B%5D=gate&factor%5Bexchanges%5D%5B%5D=graviex&factor%5Bexchanges%5D%5B%5D=hitbtc&factor%5Bexchanges%5D%5B%5D=ogre&factor%5Bexchanges%5D%5B%5D=poloniex&factor%5Bexchanges%5D%5B%5D=xeggex&dataset=Main");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro a ler dados: " + ex.Message, "Erro a tentar ler dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task VerificaRentabilidade()
        {

            while (true)
            {
                Moedas classe = await Http.PedidoGETHttpSingle<Moedas>(URLRentabilidade);

                var moedasOrdenadasPorRentabilidade = classe.GetMoedas().OrderByDescending(m => m.btc_revenue).ToList();

                var moedaMaisRentavelAtualmente = moedasOrdenadasPorRentabilidade.First();

                HaAlteracaoNaRentabilidade = MoedaMaisRentavel.id != moedaMaisRentavelAtualmente.id;

                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
    }
}