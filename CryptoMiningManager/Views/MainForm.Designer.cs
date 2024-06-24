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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			MainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			AppConfigurationBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
			skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
			beiVersao = new DevExpress.XtraBars.BarEditItem();
			repositoryItemTextEditVersao = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			GeralRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
			GeralRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			TemaRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			DocumentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
			TabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
			dockManager = new DevExpress.XtraBars.Docking.DockManager(components);
			FuncionalidadesDockPanel = new DevExpress.XtraBars.Docking.DockPanel();
			dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
			FuncionalidadesAccordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
			FuncionalidadesACEG = new DevExpress.XtraBars.Navigation.AccordionControlElement();
			GestaoAutomaticaMineracaoACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
			ConfiguracoesACEG = new DevExpress.XtraBars.Navigation.AccordionControlElement();
			ComandosACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
			ConfiguracoesGeraisACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
			MineradoresACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
			MoedasACE = new DevExpress.XtraBars.Navigation.AccordionControlElement();
			notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
			((System.ComponentModel.ISupportInitialize)MainRibbon).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemTextEditVersao).BeginInit();
			((System.ComponentModel.ISupportInitialize)DocumentManager).BeginInit();
			((System.ComponentModel.ISupportInitialize)TabbedView).BeginInit();
			((System.ComponentModel.ISupportInitialize)dockManager).BeginInit();
			FuncionalidadesDockPanel.SuspendLayout();
			dockPanel1_Container.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)FuncionalidadesAccordionControl).BeginInit();
			SuspendLayout();
			// 
			// MainRibbon
			// 
			MainRibbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 39, 35, 39);
			MainRibbon.ExpandCollapseItem.Id = 0;
			MainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MainRibbon.ExpandCollapseItem, AppConfigurationBarButtonItem, skinRibbonGalleryBarItem1, skinPaletteRibbonGalleryBarItem1, beiVersao });
			MainRibbon.Location = new System.Drawing.Point(0, 0);
			MainRibbon.Margin = new System.Windows.Forms.Padding(4);
			MainRibbon.MaxItemId = 5;
			MainRibbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
			MainRibbon.Name = "MainRibbon";
			MainRibbon.OptionsMenuMinWidth = 385;
			MainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { GeralRibbonPage });
			MainRibbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemTextEditVersao });
			MainRibbon.Size = new System.Drawing.Size(1586, 182);
			MainRibbon.StatusBar = ribbonStatusBar;
			// 
			// AppConfigurationBarButtonItem
			// 
			AppConfigurationBarButtonItem.Caption = "Configurações da Aplicação";
			AppConfigurationBarButtonItem.Id = 1;
			AppConfigurationBarButtonItem.Name = "AppConfigurationBarButtonItem";
			// 
			// skinRibbonGalleryBarItem1
			// 
			skinRibbonGalleryBarItem1.Caption = "Tema";
			skinRibbonGalleryBarItem1.Id = 2;
			skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
			// 
			// skinPaletteRibbonGalleryBarItem1
			// 
			skinPaletteRibbonGalleryBarItem1.Caption = "Palete";
			skinPaletteRibbonGalleryBarItem1.Id = 3;
			skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
			// 
			// beiVersao
			// 
			beiVersao.Caption = "Versão:";
			beiVersao.Edit = repositoryItemTextEditVersao;
			beiVersao.EditValue = "1.0.0.0";
			beiVersao.Id = 4;
			beiVersao.Name = "beiVersao";
			// 
			// repositoryItemTextEditVersao
			// 
			repositoryItemTextEditVersao.AutoHeight = false;
			repositoryItemTextEditVersao.Name = "repositoryItemTextEditVersao";
			repositoryItemTextEditVersao.ReadOnly = true;
			// 
			// GeralRibbonPage
			// 
			GeralRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { GeralRPG, TemaRPG });
			GeralRibbonPage.Name = "GeralRibbonPage";
			GeralRibbonPage.Text = "Geral";
			// 
			// GeralRPG
			// 
			GeralRPG.ItemLinks.Add(AppConfigurationBarButtonItem);
			GeralRPG.Name = "GeralRPG";
			GeralRPG.Text = "Geral";
			GeralRPG.Visible = false;
			// 
			// TemaRPG
			// 
			TemaRPG.ItemLinks.Add(skinRibbonGalleryBarItem1);
			TemaRPG.ItemLinks.Add(skinPaletteRibbonGalleryBarItem1);
			TemaRPG.Name = "TemaRPG";
			TemaRPG.Text = "Tema";
			// 
			// ribbonStatusBar
			// 
			ribbonStatusBar.ItemLinks.Add(beiVersao);
			ribbonStatusBar.Location = new System.Drawing.Point(0, 971);
			ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4);
			ribbonStatusBar.Name = "ribbonStatusBar";
			ribbonStatusBar.Ribbon = MainRibbon;
			ribbonStatusBar.Size = new System.Drawing.Size(1586, 33);
			// 
			// DocumentManager
			// 
			DocumentManager.ContainerControl = this;
			DocumentManager.MenuManager = MainRibbon;
			DocumentManager.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
			DocumentManager.View = TabbedView;
			DocumentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { TabbedView });
			DocumentManager.DocumentActivate += DocumentManager_DocumentActivate;
			// 
			// TabbedView
			// 
			TabbedView.DocumentClosing += TabbedView_DocumentClosing;
			// 
			// dockManager
			// 
			dockManager.AutoHideSpeed = 4;
			dockManager.Form = this;
			dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] { FuncionalidadesDockPanel });
			dockManager.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl" });
			// 
			// FuncionalidadesDockPanel
			// 
			FuncionalidadesDockPanel.Controls.Add(dockPanel1_Container);
			FuncionalidadesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
			FuncionalidadesDockPanel.ID = new System.Guid("e2195159-eed9-4634-ae20-2362dc2a59de");
			FuncionalidadesDockPanel.Location = new System.Drawing.Point(0, 182);
			FuncionalidadesDockPanel.Margin = new System.Windows.Forms.Padding(4);
			FuncionalidadesDockPanel.Name = "FuncionalidadesDockPanel";
			FuncionalidadesDockPanel.Options.ShowCloseButton = false;
			FuncionalidadesDockPanel.OriginalSize = new System.Drawing.Size(244, 200);
			FuncionalidadesDockPanel.Size = new System.Drawing.Size(244, 789);
			FuncionalidadesDockPanel.Text = "Funcionalidades";
			// 
			// dockPanel1_Container
			// 
			dockPanel1_Container.Controls.Add(FuncionalidadesAccordionControl);
			dockPanel1_Container.Location = new System.Drawing.Point(3, 31);
			dockPanel1_Container.Margin = new System.Windows.Forms.Padding(4);
			dockPanel1_Container.Name = "dockPanel1_Container";
			dockPanel1_Container.Size = new System.Drawing.Size(237, 755);
			dockPanel1_Container.TabIndex = 0;
			// 
			// FuncionalidadesAccordionControl
			// 
			FuncionalidadesAccordionControl.Dock = System.Windows.Forms.DockStyle.Fill;
			FuncionalidadesAccordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { FuncionalidadesACEG, ConfiguracoesACEG });
			FuncionalidadesAccordionControl.Location = new System.Drawing.Point(0, 0);
			FuncionalidadesAccordionControl.Margin = new System.Windows.Forms.Padding(4);
			FuncionalidadesAccordionControl.Name = "FuncionalidadesAccordionControl";
			FuncionalidadesAccordionControl.Size = new System.Drawing.Size(237, 755);
			FuncionalidadesAccordionControl.TabIndex = 0;
			FuncionalidadesAccordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
			// 
			// FuncionalidadesACEG
			// 
			FuncionalidadesACEG.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { GestaoAutomaticaMineracaoACE });
			FuncionalidadesACEG.Expanded = true;
			FuncionalidadesACEG.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("FuncionalidadesACEG.ImageOptions.SvgImage");
			FuncionalidadesACEG.Name = "FuncionalidadesACEG";
			FuncionalidadesACEG.Text = "Funcionalidades";
			// 
			// GestaoAutomaticaMineracaoACE
			// 
			GestaoAutomaticaMineracaoACE.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GestaoAutomaticaMineracaoACE.ImageOptions.SvgImage");
			GestaoAutomaticaMineracaoACE.Name = "GestaoAutomaticaMineracaoACE";
			GestaoAutomaticaMineracaoACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
			GestaoAutomaticaMineracaoACE.Text = "Gestão automática de mineração";
			GestaoAutomaticaMineracaoACE.Click += GestaoAutomaticaMineracaoACE_Click;
			// 
			// ConfiguracoesACEG
			// 
			ConfiguracoesACEG.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { ComandosACE, ConfiguracoesGeraisACE, MineradoresACE, MoedasACE });
			ConfiguracoesACEG.Expanded = true;
			ConfiguracoesACEG.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ConfiguracoesACEG.ImageOptions.SvgImage");
			ConfiguracoesACEG.Name = "ConfiguracoesACEG";
			ConfiguracoesACEG.Text = "Configurações";
			// 
			// ComandosACE
			// 
			ComandosACE.Name = "ComandosACE";
			ComandosACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
			ComandosACE.Text = "Comandos";
			ComandosACE.Click += ComandosACE_Click;
			// 
			// ConfiguracoesGeraisACE
			// 
			ConfiguracoesGeraisACE.Name = "ConfiguracoesGeraisACE";
			ConfiguracoesGeraisACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
			ConfiguracoesGeraisACE.Text = "Configurações Gerais";
			ConfiguracoesGeraisACE.Click += ConfiguracoesGeraisACE_Click;
			// 
			// MineradoresACE
			// 
			MineradoresACE.Name = "MineradoresACE";
			MineradoresACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
			MineradoresACE.Text = "Mineradores";
			MineradoresACE.Click += MineradoresACE_Click;
			// 
			// MoedasACE
			// 
			MoedasACE.Name = "MoedasACE";
			MoedasACE.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
			MoedasACE.Text = "Moedas";
			MoedasACE.Click += MoedasACE_Click;
			// 
			// notifyIcon1
			// 
			notifyIcon1.Text = "notifyIcon1";
			notifyIcon1.Visible = true;
			// 
			// MainForm
			// 
			AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
			Appearance.Options.UseFont = true;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1586, 1004);
			Controls.Add(FuncionalidadesDockPanel);
			Controls.Add(ribbonStatusBar);
			Controls.Add(MainRibbon);
			Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("MainForm.IconOptions.Icon");
			Margin = new System.Windows.Forms.Padding(4);
			Name = "MainForm";
			Ribbon = MainRibbon;
			StatusBar = ribbonStatusBar;
			Text = "Crypto Mining Manager";
			FormClosing += MainForm_FormClosing;
			Load += MainForm_Load;
			((System.ComponentModel.ISupportInitialize)MainRibbon).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemTextEditVersao).EndInit();
			((System.ComponentModel.ISupportInitialize)DocumentManager).EndInit();
			((System.ComponentModel.ISupportInitialize)TabbedView).EndInit();
			((System.ComponentModel.ISupportInitialize)dockManager).EndInit();
			FuncionalidadesDockPanel.ResumeLayout(false);
			dockPanel1_Container.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)FuncionalidadesAccordionControl).EndInit();
			ResumeLayout(false);
			PerformLayout();
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
        private DevExpress.XtraBars.Navigation.AccordionControlElement MoedasACE;
		private DevExpress.XtraBars.Navigation.AccordionControlElement ConfiguracoesGeraisACE;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
	}
}