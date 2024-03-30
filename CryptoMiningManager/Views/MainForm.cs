using Autofac;
using CryptoMiningManager.Views.UserControls.Configuracoes;
using CryptoMiningManager.Views.UserControls.Funcionalidades;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Windows.Forms;

namespace CryptoMiningManager.Views
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private ILifetimeScope Scope { get; }

        public MainForm(ILifetimeScope scope)
        {
            InitializeComponent();

            Scope = scope;
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
            CallUserControlTab<GestaoAutomaticaMineracaoUserControl>(sender);
        }

        private void MineradoresACE_Click(object sender, EventArgs e)
        {
            CallUserControlTab<MineradoresUserControl>(sender);
        }
        #endregion

        private void DocumentManager_DocumentActivate(object sender, DocumentEventArgs e)
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
        /// <summary>
        /// Cria um novo separador com uma <see cref="ILifetimeScope"/> nova
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        private void CallUserControlTab<T>(object sender) where T : UserControl
        {
            if (!(sender is AccordionControlElement controlElement))
                return;

            try
            {
                using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this))
                {
                    ILifetimeScope scope = Scope.BeginLifetimeScope();
                    T userControl = scope.Resolve<T>();

                    //Fazer o dispose da scope do userControl sem ter de alterar o event handler dos designers
                    userControl.Disposed += (s, e) => scope.Dispose();

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