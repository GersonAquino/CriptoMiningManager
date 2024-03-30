namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    partial class MineradoresUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineradoresUserControl));
            this.MoedasGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MineradoresGC = new DevExpress.XtraGrid.GridControl();
            this.MineradoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MineradoresGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalizacaoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParametrosMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAtivoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataCriacaoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataAlteracaoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MineradoresRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.NovoBBI = new DevExpress.XtraBars.BarButtonItem();
            this.EditarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.EliminarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.MineradoresRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresRC)).BeginInit();
            this.SuspendLayout();
            // 
            // MoedasGV
            // 
            this.MoedasGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdMoeda,
            this.colNome});
            this.MoedasGV.DetailHeight = 458;
            this.MoedasGV.GridControl = this.MineradoresGC;
            this.MoedasGV.Name = "MoedasGV";
            this.MoedasGV.OptionsEditForm.PopupEditFormWidth = 933;
            // 
            // colIdMoeda
            // 
            this.colIdMoeda.FieldName = "Id";
            this.colIdMoeda.MinWidth = 23;
            this.colIdMoeda.Name = "colIdMoeda";
            this.colIdMoeda.Visible = true;
            this.colIdMoeda.VisibleIndex = 0;
            this.colIdMoeda.Width = 87;
            // 
            // colNome
            // 
            this.colNome.FieldName = "Nome";
            this.colNome.MinWidth = 23;
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 1;
            this.colNome.Width = 87;
            // 
            // MineradoresGC
            // 
            this.MineradoresGC.DataSource = this.MineradoresBindingSource;
            this.MineradoresGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MineradoresGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gridLevelNode1.LevelTemplate = this.MoedasGV;
            gridLevelNode1.RelationName = "Moedas";
            this.MineradoresGC.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.MineradoresGC.Location = new System.Drawing.Point(0, 186);
            this.MineradoresGC.MainView = this.MineradoresGV;
            this.MineradoresGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MineradoresGC.Name = "MineradoresGC";
            this.MineradoresGC.Size = new System.Drawing.Size(1695, 918);
            this.MineradoresGC.TabIndex = 1;
            this.MineradoresGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MineradoresGV,
            this.MoedasGV});
            // 
            // MineradoresBindingSource
            // 
            this.MineradoresBindingSource.DataSource = typeof(Modelos.Classes.Minerador);
            // 
            // MineradoresGV
            // 
            this.MineradoresGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdMinerador,
            this.colLocalizacaoMinerador,
            this.colParametrosMinerador,
            this.colAtivoMinerador,
            this.colDataCriacaoMinerador,
            this.colDataAlteracaoMinerador});
            this.MineradoresGV.DetailHeight = 458;
            this.MineradoresGV.GridControl = this.MineradoresGC;
            this.MineradoresGV.Name = "MineradoresGV";
            this.MineradoresGV.OptionsBehavior.Editable = false;
            this.MineradoresGV.OptionsBehavior.ReadOnly = true;
            this.MineradoresGV.OptionsEditForm.PopupEditFormWidth = 933;
            this.MineradoresGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            this.MineradoresGV.OptionsMenu.ShowConditionalFormattingItem = true;
            this.MineradoresGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.MineradoresGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.MineradoresGV.OptionsSelection.MultiSelect = true;
            this.MineradoresGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.MineradoresGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.MineradoresGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.MineradoresGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            this.MineradoresGV.OptionsView.ShowFooter = true;
            this.MineradoresGV.DoubleClick += new System.EventHandler(this.MineradoresGV_DoubleClick);
            // 
            // colIdMinerador
            // 
            this.colIdMinerador.FieldName = "Id";
            this.colIdMinerador.MinWidth = 23;
            this.colIdMinerador.Name = "colIdMinerador";
            this.colIdMinerador.Visible = true;
            this.colIdMinerador.VisibleIndex = 3;
            this.colIdMinerador.Width = 87;
            // 
            // colLocalizacaoMinerador
            // 
            this.colLocalizacaoMinerador.FieldName = "Localizacao";
            this.colLocalizacaoMinerador.MinWidth = 23;
            this.colLocalizacaoMinerador.Name = "colLocalizacaoMinerador";
            this.colLocalizacaoMinerador.Visible = true;
            this.colLocalizacaoMinerador.VisibleIndex = 1;
            this.colLocalizacaoMinerador.Width = 107;
            // 
            // colParametrosMinerador
            // 
            this.colParametrosMinerador.FieldName = "Parametros";
            this.colParametrosMinerador.MinWidth = 23;
            this.colParametrosMinerador.Name = "colParametrosMinerador";
            this.colParametrosMinerador.Visible = true;
            this.colParametrosMinerador.VisibleIndex = 2;
            this.colParametrosMinerador.Width = 107;
            // 
            // colAtivoMinerador
            // 
            this.colAtivoMinerador.FieldName = "Ativo";
            this.colAtivoMinerador.MinWidth = 23;
            this.colAtivoMinerador.Name = "colAtivoMinerador";
            this.colAtivoMinerador.Visible = true;
            this.colAtivoMinerador.VisibleIndex = 4;
            this.colAtivoMinerador.Width = 87;
            // 
            // colDataCriacaoMinerador
            // 
            this.colDataCriacaoMinerador.FieldName = "DataCriacao";
            this.colDataCriacaoMinerador.MinWidth = 23;
            this.colDataCriacaoMinerador.Name = "colDataCriacaoMinerador";
            this.colDataCriacaoMinerador.Visible = true;
            this.colDataCriacaoMinerador.VisibleIndex = 5;
            this.colDataCriacaoMinerador.Width = 115;
            // 
            // colDataAlteracaoMinerador
            // 
            this.colDataAlteracaoMinerador.FieldName = "DataAlteracao";
            this.colDataAlteracaoMinerador.MinWidth = 23;
            this.colDataAlteracaoMinerador.Name = "colDataAlteracaoMinerador";
            this.colDataAlteracaoMinerador.Visible = true;
            this.colDataAlteracaoMinerador.VisibleIndex = 6;
            this.colDataAlteracaoMinerador.Width = 126;
            // 
            // MineradoresRC
            // 
            this.MineradoresRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 40, 35, 40);
            this.MineradoresRC.ExpandCollapseItem.Id = 0;
            this.MineradoresRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MineradoresRC.ExpandCollapseItem,
            this.AtualizarBBI,
            this.NovoBBI,
            this.EditarBBI,
            this.EliminarBBI});
            this.MineradoresRC.Location = new System.Drawing.Point(0, 0);
            this.MineradoresRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MineradoresRC.MaxItemId = 5;
            this.MineradoresRC.Name = "MineradoresRC";
            this.MineradoresRC.OptionsMenuMinWidth = 385;
            this.MineradoresRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.MineradoresRP});
            this.MineradoresRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.MineradoresRC.Size = new System.Drawing.Size(1695, 186);
            // 
            // AtualizarBBI
            // 
            this.AtualizarBBI.Caption = "Atualizar";
            this.AtualizarBBI.Id = 1;
            this.AtualizarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("AtualizarBBI.ImageOptions.SvgImage")));
            this.AtualizarBBI.Name = "AtualizarBBI";
            this.AtualizarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AtualizarBBI_ItemClick);
            // 
            // NovoBBI
            // 
            this.NovoBBI.Caption = "Novo";
            this.NovoBBI.Id = 2;
            this.NovoBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NovoBBI.ImageOptions.SvgImage")));
            this.NovoBBI.Name = "NovoBBI";
            this.NovoBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NovoBBI_ItemClick);
            // 
            // EditarBBI
            // 
            this.EditarBBI.Caption = "Editar";
            this.EditarBBI.Id = 3;
            this.EditarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("EditarBBI.ImageOptions.SvgImage")));
            this.EditarBBI.Name = "EditarBBI";
            this.EditarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EditarBBI_ItemClick);
            // 
            // EliminarBBI
            // 
            this.EliminarBBI.Caption = "Eliminar";
            this.EliminarBBI.Id = 4;
            this.EliminarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("EliminarBBI.ImageOptions.SvgImage")));
            this.EliminarBBI.Name = "EliminarBBI";
            this.EliminarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EliminarBBI_ItemClick);
            // 
            // MineradoresRP
            // 
            this.MineradoresRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.OperacoesRPG});
            this.MineradoresRP.Name = "MineradoresRP";
            this.MineradoresRP.Text = "Mineradores";
            // 
            // OperacoesRPG
            // 
            this.OperacoesRPG.ItemLinks.Add(this.AtualizarBBI);
            this.OperacoesRPG.ItemLinks.Add(this.NovoBBI);
            this.OperacoesRPG.ItemLinks.Add(this.EditarBBI);
            this.OperacoesRPG.ItemLinks.Add(this.EliminarBBI);
            this.OperacoesRPG.Name = "OperacoesRPG";
            this.OperacoesRPG.Text = "Operações";
            // 
            // MineradoresUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MineradoresGC);
            this.Controls.Add(this.MineradoresRC);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MineradoresUserControl";
            this.Size = new System.Drawing.Size(1695, 1104);
            this.Load += new System.EventHandler(this.MineradoresUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresRC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MineradoresRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage MineradoresRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraGrid.GridControl MineradoresGC;
        private DevExpress.XtraGrid.Views.Grid.GridView MineradoresGV;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private DevExpress.XtraBars.BarButtonItem NovoBBI;
        private DevExpress.XtraBars.BarButtonItem EditarBBI;
        private DevExpress.XtraBars.BarButtonItem EliminarBBI;
        private System.Windows.Forms.BindingSource MineradoresBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalizacaoMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colParametrosMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colAtivoMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCriacaoMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colDataAlteracaoMinerador;
        private DevExpress.XtraGrid.Views.Grid.GridView MoedasGV;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMoeda;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
    }
}
