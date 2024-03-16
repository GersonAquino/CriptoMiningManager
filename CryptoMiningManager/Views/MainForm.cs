using CryptoMiningManager.Views.UserControls;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GestorDados.Enums;
using GestorDados.Helpers;
using Modelos.Classes;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create menus
            //#region Funcionalidades
            //AccordionControlElement FuncionalityGroup = FuncionalidadesAccordionControl.AddGroup();
            //FuncionalityGroup.ImageOptions.SvgImage = Properties.Resources.payment;
            //FuncionalityGroup.Text = "Funcionalidades";

            //AccordionControlElement CreateClientErpElement = FuncionalityGroup.Elements.Add();
            //CreateClientErpElement.ImageOptions.SvgImage = Properties.Resources.customers;
            //CreateClientErpElement.Style = ElementStyle.Item;
            //CreateClientErpElement.Text = "Clientes";
            //CreateClientErpElement.Click += CreateClientErpElement_Click;

            //AccordionControlElement InvoicesElement = FuncionalityGroup.Elements.Add();
            //InvoicesElement.ImageOptions.SvgImage = Properties.Resources.bo_list;
            //InvoicesElement.Text = "Faturas";
            //InvoicesElement.Style = ElementStyle.Item;
            //InvoicesElement.Click += EventsAirElement_Click;
            //#endregion

            //#region Histórico
            //AccordionControlElement HistoryGroup = FuncionalidadesAccordionControl.AddGroup();
            //HistoryGroup.ImageOptions.SvgImage = Properties.Resources.chartverticalaxis_logscale;
            //HistoryGroup.Text = "Histórico";

            //AccordionControlElement LogsElement = HistoryGroup.Elements.Add();
            //LogsElement.ImageOptions.SvgImage = Properties.Resources.detailed;
            //LogsElement.Style = ElementStyle.Item;
            //LogsElement.Text = "Logs";
            //LogsElement.Click += LogsElementElement_Click;
            //#endregion

            //#region Configurações
            //AccordionControlElement ConfigurationGroup = FuncionalidadesAccordionControl.AddGroup();
            //ConfigurationGroup.ImageOptions.SvgImage = Properties.Resources.viewsettings;
            //ConfigurationGroup.Text = "Configurações";

            //AccordionControlElement GeneralConfigurationElement = ConfigurationGroup.Elements.Add();
            //GeneralConfigurationElement.ImageOptions.SvgImage = Properties.Resources.viewsettings;
            //GeneralConfigurationElement.Style = ElementStyle.Item;
            //GeneralConfigurationElement.Text = "Configurações Gerais";
            //GeneralConfigurationElement.Click += ConfigsGeraisElementElement_Click;
            //#endregion
        }

        #region Eventos Click que criam um tab com um UserControl

        private void GestaoAutomaticaMineracaoACE_Click(object sender, EventArgs e)
        {
            CallUserControlTab(sender, new GestaoAutomaticaMineracaoUserControl());
        }

        #endregion

        private void documentManager_DocumentActivate(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (this.Ribbon.MergedPages.Count > 0)
            {
                this.Ribbon.SelectPage(this.Ribbon.MergedPages[0]);
                this.Ribbon.SelectedPage = this.Ribbon.MergedPages[0];
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Pretende terminar a aplicação?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = result != DialogResult.Yes;
        }

        private void TabbedView_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            if (e.Document.Caption == GestaoAutomaticaMineracaoACE.Text &&
                DialogResult.Yes != XtraMessageBox.Show("Fechar este separador irá parar qualquer processo de mineração em progresso, pretende continuar?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                e.Cancel = true;
            }
        }

        //FUNÇÕES AUXILIARES
        private void CallUserControlTab<T>(object sender, T userControl) where T : UserControl
        {
            if (!(sender is AccordionControlElement controlElement))
                return;

            try
            {
                using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this))
                {
                    BaseDocument doc = this.TabbedView.AddOrActivateDocument(s => s.Caption == controlElement.Text, () => userControl);
                    doc.Caption = controlElement.Text;
                }
            }
            catch (Exception ex)
            {
                //SerilogHelper.EscreveLogException(SerilogLevel.Error, ex, "Erro ao abrir menu {menuText}", controlElement.Text);
                XtraMessageBox.Show(ex.GetBaseException().Message, $"Não foi possível abrir o menu {controlElement.Text}",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}