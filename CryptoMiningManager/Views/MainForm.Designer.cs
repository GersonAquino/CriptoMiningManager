namespace CryptoMiningManager.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.AppConfigurationBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.beiVersao = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEditVersao = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.GeralRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.GeralRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.TemaRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.DocumentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.TabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.FuncionalidadesDockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.FuncionalidadesAccordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.FuncionalidadesACEG = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.GestaoAutomaticaMineracaoACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ConfiguracoesACEG = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MineradoresACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ComandosACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditVersao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.FuncionalidadesDockPanel.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FuncionalidadesAccordionControl)).BeginInit();
            this.SuspendLayout();
            // 
            // MainRibbon
            // 
            this.MainRibbon.ExpandCollapseItem.Id = 0;
            this.MainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MainRibbon.ExpandCollapseItem,
            this.AppConfigurationBarButtonItem,
            this.skinRibbonGalleryBarItem1,
            this.skinPaletteRibbonGalleryBarItem1,
            this.beiVersao});
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.MaxItemId = 5;
            this.MainRibbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.MainRibbon.Name = "MainRibbon";
            this.MainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.GeralRibbonPage});
            this.MainRibbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditVersao});
            this.MainRibbon.Size = new System.Drawing.Size(1359, 170);
            this.MainRibbon.StatusBar = this.ribbonStatusBar;
            // 
            // AppConfigurationBarButtonItem
            // 
            this.AppConfigurationBarButtonItem.Caption = "Configurações da Aplicação";
            this.AppConfigurationBarButtonItem.Id = 1;
            this.AppConfigurationBarButtonItem.Name = "AppConfigurationBarButtonItem";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "Tema";
            this.skinRibbonGalleryBarItem1.Id = 2;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            this.skinPaletteRibbonGalleryBarItem1.Caption = "Palete";
            this.skinPaletteRibbonGalleryBarItem1.Id = 3;
            this.skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // beiVersao
            // 
            this.beiVersao.Caption = "Versão:";
            this.beiVersao.Edit = this.repositoryItemTextEditVersao;
            this.beiVersao.EditValue = "1.0.0.0";
            this.beiVersao.Id = 4;
            this.beiVersao.Name = "beiVersao";
            // 
            // repositoryItemTextEditVersao
            // 
            this.repositoryItemTextEditVersao.AutoHeight = false;
            this.repositoryItemTextEditVersao.Name = "repositoryItemTextEditVersao";
            this.repositoryItemTextEditVersao.ReadOnly = true;
            // 
            // GeralRibbonPage
            // 
            this.GeralRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.GeralRPG,
            this.TemaRPG});
            this.GeralRibbonPage.Name = "GeralRibbonPage";
            this.GeralRibbonPage.Text = "Geral";
            // 
            // GeralRPG
            // 
            this.GeralRPG.ItemLinks.Add(this.AppConfigurationBarButtonItem);
            this.GeralRPG.Name = "GeralRPG";
            this.GeralRPG.Text = "Geral";
            this.GeralRPG.Visible = false;
            // 
            // TemaRPG
            // 
            this.TemaRPG.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.TemaRPG.ItemLinks.Add(this.skinPaletteRibbonGalleryBarItem1);
            this.TemaRPG.Name = "TemaRPG";
            this.TemaRPG.Text = "Tema";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.beiVersao);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 737);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.MainRibbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1359, 31);
            // 
            // DocumentManager
            // 
            this.DocumentManager.ContainerControl = this;
            this.DocumentManager.MenuManager = this.MainRibbon;
            this.DocumentManager.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.DocumentManager.View = this.TabbedView;
            this.DocumentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.TabbedView});
            this.DocumentManager.DocumentActivate += new DevExpress.XtraBars.Docking2010.Views.DocumentEventHandler(this.DocumentManager_DocumentActivate);
            // 
            // TabbedView
            // 
            this.TabbedView.DocumentClosing += new DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventHandler(this.TabbedView_DocumentClosing);
            // 
            // dockManager
            // 
            this.dockManager.AutoHideSpeed = 4;
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.FuncionalidadesDockPanel});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // FuncionalidadesDockPanel
            // 
            this.FuncionalidadesDockPanel.Controls.Add(this.dockPanel1_Container);
            this.FuncionalidadesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.FuncionalidadesDockPanel.ID = new System.Guid("e2195159-eed9-4634-ae20-2362dc2a59de");
            this.FuncionalidadesDockPanel.Location = new System.Drawing.Point(0, 170);
            this.FuncionalidadesDockPanel.Name = "FuncionalidadesDockPanel";
            this.FuncionalidadesDockPanel.Options.ShowCloseButton = false;
            this.FuncionalidadesDockPanel.OriginalSize = new System.Drawing.Size(244, 200);
            this.FuncionalidadesDockPanel.Size = new System.Drawing.Size(244, 567);
            this.FuncionalidadesDockPanel.Text = "Funcionalidades";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.FuncionalidadesAccordionControl);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 31);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(237, 533);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // FuncionalidadesAccordionControl
            // 
            this.FuncionalidadesAccordionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuncionalidadesAccordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.FuncionalidadesACEG,
            this.ConfiguracoesACEG});
            this.FuncionalidadesAccordionControl.Location = new System.Drawing.Point(0, 0);
            this.FuncionalidadesAccordionControl.Name = "FuncionalidadesAccordionControl";
            this.FuncionalidadesAccordionControl.Size = new System.Drawing.Size(237, 533);
            this.FuncionalidadesAccordionControl.TabIndex = 0;
            this.FuncionalidadesAccordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // FuncionalidadesACEG
            // 
            this.FuncionalidadesACEG.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.GestaoAutomaticaMineracaoACE});
            this.FuncionalidadesACEG.Expanded = true;
            this.FuncionalidadesACEG.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FuncionalidadesACEG.ImageOptions.SvgImage")));
            this.FuncionalidadesACEG.Name = "FuncionalidadesACEG";
            this.FuncionalidadesACEG.Text = "Funcionalidades";
            // 
            // GestaoAutomaticaMineracaoACE
            // 
            this.GestaoAutomaticaMineracaoACE.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GestaoAutomaticaMineracaoACE.ImageOptions.SvgImage")));
            this.GestaoAutomaticaMineracaoACE.Name = "GestaoAutomaticaMineracaoACE";
            this.GestaoAutomaticaMineracaoACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.GestaoAutomaticaMineracaoACE.Text = "Gestão automática de mineração";
            this.GestaoAutomaticaMineracaoACE.Click += new System.EventHandler(this.GestaoAutomaticaMineracaoACE_Click);
            // 
            // ConfiguracoesACEG
            // 
            this.ConfiguracoesACEG.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.MineradoresACE,
            this.ComandosACE});
            this.ConfiguracoesACEG.Expanded = true;
            this.ConfiguracoesACEG.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ConfiguracoesACEG.ImageOptions.SvgImage")));
            this.ConfiguracoesACEG.Name = "ConfiguracoesACEG";
            this.ConfiguracoesACEG.Text = "Configurações";
            // 
            // MineradoresACE
            // 
            this.MineradoresACE.Name = "MineradoresACE";
            this.MineradoresACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MineradoresACE.Text = "Mineradores";
            this.MineradoresACE.Click += new System.EventHandler(this.MineradoresACE_Click);
            // 
            // ComandosACE
            // 
            this.ComandosACE.Name = "ComandosACE";
            this.ComandosACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ComandosACE.Text = "Comandos";
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 768);
            this.Controls.Add(this.FuncionalidadesDockPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.MainRibbon);
            this.Name = "MainForm";
            this.Ribbon = this.MainRibbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Crypto Mining Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditVersao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.FuncionalidadesDockPanel.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FuncionalidadesAccordionControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MainRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage GeralRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup GeralRPG;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Docking2010.DocumentManager DocumentManager;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Navigation.AccordionControl FuncionalidadesAccordionControl;
        internal DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView TabbedView;
        private DevExpress.XtraBars.BarButtonItem AppConfigurationBarButtonItem;
        internal DevExpress.XtraBars.Docking.DockPanel FuncionalidadesDockPanel;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup TemaRPG;
        private DevExpress.XtraBars.BarEditItem beiVersao;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditVersao;
        private DevExpress.XtraBars.Navigation.AccordionControlElement FuncionalidadesACEG;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GestaoAutomaticaMineracaoACE;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ConfiguracoesACEG;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MineradoresACE;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ComandosACE;
    }
}