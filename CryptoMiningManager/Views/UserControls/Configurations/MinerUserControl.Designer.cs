namespace CryptoMiningManager.Views.UserControls.Configurations
{
    partial class MinerUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinerUserControl));
            MinersGC = new DevExpress.XtraGrid.GridControl();
            MinersBindingSource = new System.Windows.Forms.BindingSource(components);
            MinerGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            colMinerId = new DevExpress.XtraGrid.Columns.GridColumn();
            colNameMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            colLocationMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colParametersMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colActiveMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colCreatedDateMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colUpdatedDateMinerador = new DevExpress.XtraGrid.Columns.GridColumn();
            colCoinId = new DevExpress.XtraGrid.Columns.GridColumn();
            colMoedaObj = new DevExpress.XtraGrid.Columns.GridColumn();
            MineradoresRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            NovoBBI = new DevExpress.XtraBars.BarButtonItem();
            EditarBBI = new DevExpress.XtraBars.BarButtonItem();
            EliminarBBI = new DevExpress.XtraBars.BarButtonItem();
            MineradoresRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)MinersGC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinerGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresRC).BeginInit();
            SuspendLayout();
            // 
            // MineradoresGC
            // 
            MinersGC.DataSource = MinersBindingSource;
            MinersGC.Dock = System.Windows.Forms.DockStyle.Fill;
            MinersGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinersGC.Location = new System.Drawing.Point(0, 186);
            MinersGC.MainView = MinerGV;
            MinersGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinersGC.Name = "MineradoresGC";
            MinersGC.Size = new System.Drawing.Size(1695, 918);
            MinersGC.TabIndex = 1;
            MinersGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { MinerGV });
            // 
            // MineradoresBindingSource
            // 
            MinersBindingSource.DataSource = typeof(Models.Classes.Miner);
            // 
            // MineradoresGV
            // 
            MinerGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colMinerId, colNameMinerador, colMoeda, colLocationMinerador, colParametersMinerador, colActiveMinerador, colCreatedDateMinerador, colUpdatedDateMinerador, colCoinId, colMoedaObj });
            MinerGV.DetailHeight = 458;
            MinerGV.GridControl = MinersGC;
            MinerGV.Name = "MineradoresGV";
            MinerGV.OptionsBehavior.Editable = false;
            MinerGV.OptionsBehavior.ReadOnly = true;
            MinerGV.OptionsEditForm.PopupEditFormWidth = 933;
            MinerGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            MinerGV.OptionsMenu.ShowConditionalFormattingItem = true;
            MinerGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            MinerGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            MinerGV.OptionsSelection.MultiSelect = true;
            MinerGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            MinerGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            MinerGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            MinerGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            MinerGV.OptionsView.ShowFooter = true;
            MinerGV.DoubleClick += MinerGV_DoubleClick;
            // 
            // colIdMinerador
            // 
            colMinerId.FieldName = "Id";
            colMinerId.MinWidth = 23;
            colMinerId.Name = "colIdMinerador";
            colMinerId.Visible = true;
            colMinerId.VisibleIndex = 1;
            colMinerId.Width = 87;
            // 
            // colNameMinerador
            // 
            colNameMinerador.FieldName = "Name";
            colNameMinerador.Name = "colNameMinerador";
            colNameMinerador.Visible = true;
            colNameMinerador.VisibleIndex = 2;
            // 
            // colMoeda
            // 
            colMoeda.Caption = "Moeda";
            colMoeda.FieldName = "Moeda";
            colMoeda.Name = "colMoeda";
            colMoeda.UnboundDataType = typeof(string);
            colMoeda.UnboundExpression = "ToStr([Moeda.Id]) + ' - ' + [Moeda.Name]";
            colMoeda.Visible = true;
            colMoeda.VisibleIndex = 3;
            // 
            // colLocationMinerador
            // 
            colLocationMinerador.Caption = "Localização";
            colLocationMinerador.FieldName = "Location";
            colLocationMinerador.MinWidth = 23;
            colLocationMinerador.Name = "colLocationMinerador";
            colLocationMinerador.Visible = true;
            colLocationMinerador.VisibleIndex = 4;
            colLocationMinerador.Width = 107;
            // 
            // colParametersMinerador
            // 
            colParametersMinerador.Caption = "Parâmetros";
            colParametersMinerador.FieldName = "Parameters";
            colParametersMinerador.MaxWidth = 300;
            colParametersMinerador.MinWidth = 23;
            colParametersMinerador.Name = "colParametersMinerador";
            colParametersMinerador.Visible = true;
            colParametersMinerador.VisibleIndex = 5;
            colParametersMinerador.Width = 107;
            // 
            // colActiveMinerador
            // 
            colActiveMinerador.FieldName = "Active";
            colActiveMinerador.MinWidth = 23;
            colActiveMinerador.Name = "colActiveMinerador";
            colActiveMinerador.Visible = true;
            colActiveMinerador.VisibleIndex = 6;
            colActiveMinerador.Width = 87;
            // 
            // colCreatedDateMinerador
            // 
            colCreatedDateMinerador.Caption = "Data Criação";
            colCreatedDateMinerador.FieldName = "CreatedDate";
            colCreatedDateMinerador.MinWidth = 23;
            colCreatedDateMinerador.Name = "colCreatedDateMinerador";
            colCreatedDateMinerador.Visible = true;
            colCreatedDateMinerador.VisibleIndex = 7;
            colCreatedDateMinerador.Width = 115;
            // 
            // colUpdatedDateMinerador
            // 
            colUpdatedDateMinerador.Caption = "Data Alteração";
            colUpdatedDateMinerador.FieldName = "UpdatedDate";
            colUpdatedDateMinerador.MinWidth = 23;
            colUpdatedDateMinerador.Name = "colUpdatedDateMinerador";
            colUpdatedDateMinerador.Visible = true;
            colUpdatedDateMinerador.VisibleIndex = 8;
            colUpdatedDateMinerador.Width = 126;
            // 
            // colCoinId
            // 
            colCoinId.FieldName = "CoinId";
            colCoinId.Name = "colCoinId";
            colCoinId.OptionsColumn.AllowEdit = false;
            colCoinId.OptionsColumn.ReadOnly = true;
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
            AtualizarBBI.ItemClick += RefreshBBI_ItemClick;
            // 
            // NovoBBI
            // 
            NovoBBI.Caption = "Novo";
            NovoBBI.Id = 2;
            NovoBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NovoBBI.ImageOptions.SvgImage");
            NovoBBI.Name = "NovoBBI";
            NovoBBI.ItemClick += NewBBI_ItemClick;
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
            EliminarBBI.ItemClick += DeleteBBI_ItemClick;
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
            Controls.Add(MinersGC);
            Controls.Add(MineradoresRC);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MineradoresUserControl";
            Size = new System.Drawing.Size(1695, 1104);
            Load += MinerUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)MinersGC).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinerGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresRC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MineradoresRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage MineradoresRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraGrid.GridControl MinersGC;
        private DevExpress.XtraGrid.Views.Grid.GridView MinerGV;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private DevExpress.XtraBars.BarButtonItem NovoBBI;
        private DevExpress.XtraBars.BarButtonItem EditarBBI;
        private DevExpress.XtraBars.BarButtonItem EliminarBBI;
        private System.Windows.Forms.BindingSource MinersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colParametersMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colMinerId;
        private DevExpress.XtraGrid.Columns.GridColumn colActiveMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDateMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDateMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colNameMinerador;
        private DevExpress.XtraGrid.Columns.GridColumn colMoeda;
        private DevExpress.XtraGrid.Columns.GridColumn colCoinId;
        private DevExpress.XtraGrid.Columns.GridColumn colMoedaObj;
    }
}
