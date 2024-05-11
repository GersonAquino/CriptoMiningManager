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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineradoresUserControl));
            MineradoresGC = new DevExpress.XtraGrid.GridControl();
            MineradoresBindingSource = new System.Windows.Forms.BindingSource(components);
            MineradoresGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colNomeMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            colLocalizacaoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colParametrosMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colAtivoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colDataCriacaoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colDataAlteracaoMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            colMoedaObj = new DevExpress.XtraGrid.Columns.GridColumn();
            MineradoresRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            NovoBBI = new DevExpress.XtraBars.BarButtonItem();
            EditarBBI = new DevExpress.XtraBars.BarButtonItem();
            EliminarBBI = new DevExpress.XtraBars.BarButtonItem();
            MineradoresRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)MineradoresGC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresRC).BeginInit();
            SuspendLayout();
            // 
            // MineradoresGC
            // 
            MineradoresGC.DataSource = MineradoresBindingSource;
            MineradoresGC.Dock = System.Windows.Forms.DockStyle.Fill;
            MineradoresGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MineradoresGC.Location = new System.Drawing.Point(0, 186);
            MineradoresGC.MainView = MineradoresGV;
            MineradoresGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MineradoresGC.Name = "MineradoresGC";
            MineradoresGC.Size = new System.Drawing.Size(1695, 918);
            MineradoresGC.TabIndex = 1;
            MineradoresGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { MineradoresGV });
            // 
            // MineradoresBindingSource
            // 
            MineradoresBindingSource.DataSource = typeof(Modelos.Classes.Minerador);
            // 
            // MineradoresGV
            // 
            MineradoresGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdMinerador, colNomeMinerador, colMoeda, colLocalizacaoMinerador, colParametrosMinerador, colAtivoMinerador, colDataCriacaoMinerador, colDataAlteracaoMinerador, colIdMoeda, colMoedaObj });
            MineradoresGV.DetailHeight = 458;
            MineradoresGV.GridControl = MineradoresGC;
            MineradoresGV.Name = "MineradoresGV";
            MineradoresGV.OptionsBehavior.Editable = false;
            MineradoresGV.OptionsBehavior.ReadOnly = true;
            MineradoresGV.OptionsEditForm.PopupEditFormWidth = 933;
            MineradoresGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            MineradoresGV.OptionsMenu.ShowConditionalFormattingItem = true;
            MineradoresGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            MineradoresGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            MineradoresGV.OptionsSelection.MultiSelect = true;
            MineradoresGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            MineradoresGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            MineradoresGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            MineradoresGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            MineradoresGV.OptionsView.ShowFooter = true;
            MineradoresGV.DoubleClick += MineradoresGV_DoubleClick;
            // 
            // colIdMinerador
            // 
            colIdMinerador.FieldName = "Id";
            colIdMinerador.MinWidth = 23;
            colIdMinerador.Name = "colIdMinerador";
            colIdMinerador.Visible = true;
            colIdMinerador.VisibleIndex = 1;
            colIdMinerador.Width = 87;
            // 
            // colNomeMinerador
            // 
            colNomeMinerador.FieldName = "Nome";
            colNomeMinerador.Name = "colNomeMinerador";
            colNomeMinerador.Visible = true;
            colNomeMinerador.VisibleIndex = 2;
            // 
            // colMoeda
            // 
            colMoeda.Caption = "Moeda";
            colMoeda.FieldName = "Moeda";
            colMoeda.Name = "colMoeda";
            colMoeda.UnboundDataType = typeof(string);
            colMoeda.UnboundExpression = "ToStr([Moeda.Id]) + ' - ' + [Moeda.Nome]";
            colMoeda.Visible = true;
            colMoeda.VisibleIndex = 3;
            // 
            // colLocalizacaoMinerador
            // 
            colLocalizacaoMinerador.Caption = "Localização";
            colLocalizacaoMinerador.FieldName = "Localizacao";
            colLocalizacaoMinerador.MinWidth = 23;
            colLocalizacaoMinerador.Name = "colLocalizacaoMinerador";
            colLocalizacaoMinerador.Visible = true;
            colLocalizacaoMinerador.VisibleIndex = 4;
            colLocalizacaoMinerador.Width = 107;
            // 
            // colParametrosMinerador
            // 
            colParametrosMinerador.Caption = "Parâmetros";
            colParametrosMinerador.FieldName = "Parametros";
            colParametrosMinerador.MaxWidth = 300;
            colParametrosMinerador.MinWidth = 23;
            colParametrosMinerador.Name = "colParametrosMinerador";
            colParametrosMinerador.Visible = true;
            colParametrosMinerador.VisibleIndex = 5;
            colParametrosMinerador.Width = 107;
            // 
            // colAtivoMinerador
            // 
            colAtivoMinerador.FieldName = "Ativo";
            colAtivoMinerador.MinWidth = 23;
            colAtivoMinerador.Name = "colAtivoMinerador";
            colAtivoMinerador.Visible = true;
            colAtivoMinerador.VisibleIndex = 6;
            colAtivoMinerador.Width = 87;
            // 
            // colDataCriacaoMinerador
            // 
            colDataCriacaoMinerador.Caption = "Data Criação";
            colDataCriacaoMinerador.FieldName = "DataCriacao";
            colDataCriacaoMinerador.MinWidth = 23;
            colDataCriacaoMinerador.Name = "colDataCriacaoMinerador";
            colDataCriacaoMinerador.Visible = true;
            colDataCriacaoMinerador.VisibleIndex = 7;
            colDataCriacaoMinerador.Width = 115;
            // 
            // colDataAlteracaoMinerador
            // 
            colDataAlteracaoMinerador.Caption = "Data Alteração";
            colDataAlteracaoMinerador.FieldName = "DataAlteracao";
            colDataAlteracaoMinerador.MinWidth = 23;
            colDataAlteracaoMinerador.Name = "colDataAlteracaoMinerador";
            colDataAlteracaoMinerador.Visible = true;
            colDataAlteracaoMinerador.VisibleIndex = 8;
            colDataAlteracaoMinerador.Width = 126;
            // 
            // colIdMoeda
            // 
            colIdMoeda.FieldName = "IdMoeda";
            colIdMoeda.Name = "colIdMoeda";
            colIdMoeda.OptionsColumn.AllowEdit = false;
            colIdMoeda.OptionsColumn.ReadOnly = true;
            // 
            // colMoedaObj
            // 
            colMoedaObj.FieldName = "Moeda";
            colMoedaObj.Name = "colMoedaObj";
            colMoedaObj.OptionsColumn.AllowEdit = false;
            colMoedaObj.OptionsColumn.AllowShowHide = false;
            colMoedaObj.OptionsColumn.ReadOnly = true;
            colMoedaObj.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // MineradoresRC
            // 
            MineradoresRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 41, 35, 41);
            MineradoresRC.ExpandCollapseItem.Id = 0;
            MineradoresRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MineradoresRC.ExpandCollapseItem, AtualizarBBI, NovoBBI, EditarBBI, EliminarBBI });
            MineradoresRC.Location = new System.Drawing.Point(0, 0);
            MineradoresRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MineradoresRC.MaxItemId = 5;
            MineradoresRC.Name = "MineradoresRC";
            MineradoresRC.OptionsMenuMinWidth = 385;
            MineradoresRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { MineradoresRP });
            MineradoresRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            MineradoresRC.Size = new System.Drawing.Size(1695, 186);
            // 
            // AtualizarBBI
            // 
            AtualizarBBI.Caption = "Atualizar";
            AtualizarBBI.Id = 1;
            AtualizarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("AtualizarBBI.ImageOptions.SvgImage");
            AtualizarBBI.Name = "AtualizarBBI";
            AtualizarBBI.ItemClick += AtualizarBBI_ItemClick;
            // 
            // NovoBBI
            // 
            NovoBBI.Caption = "Novo";
            NovoBBI.Id = 2;
            NovoBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NovoBBI.ImageOptions.SvgImage");
            NovoBBI.Name = "NovoBBI";
            NovoBBI.ItemClick += NovoBBI_ItemClick;
            // 
            // EditarBBI
            // 
            EditarBBI.Caption = "Editar";
            EditarBBI.Id = 3;
            EditarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("EditarBBI.ImageOptions.SvgImage");
            EditarBBI.Name = "EditarBBI";
            EditarBBI.ItemClick += EditarBBI_ItemClick;
            // 
            // EliminarBBI
            // 
            EliminarBBI.Caption = "Eliminar";
            EliminarBBI.Id = 4;
            EliminarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("EliminarBBI.ImageOptions.SvgImage");
            EliminarBBI.Name = "EliminarBBI";
            EliminarBBI.ItemClick += EliminarBBI_ItemClick;
            // 
            // MineradoresRP
            // 
            MineradoresRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { OperacoesRPG });
            MineradoresRP.Name = "MineradoresRP";
            MineradoresRP.Text = "Mineradores";
            // 
            // OperacoesRPG
            // 
            OperacoesRPG.ItemLinks.Add(AtualizarBBI);
            OperacoesRPG.ItemLinks.Add(NovoBBI);
            OperacoesRPG.ItemLinks.Add(EditarBBI);
            OperacoesRPG.ItemLinks.Add(EliminarBBI);
            OperacoesRPG.Name = "OperacoesRPG";
            OperacoesRPG.Text = "Operações";
            // 
            // MineradoresUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(MineradoresGC);
            Controls.Add(MineradoresRC);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MineradoresUserControl";
            Size = new System.Drawing.Size(1695, 1104);
            Load += MineradoresUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)MineradoresGC).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresRC).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DevExpress.XtraGrid.Columns.GridColumn colNomeMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colMoeda;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMoeda;
        private DevExpress.XtraGrid.Columns.GridColumn colMoedaObj;
    }
}
