namespace CryptoMiningManager.Views.UserControls.Configurations
{
    partial class CoinUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoinUserControl));
            colCoinId = new DevExpress.XtraGrid.Columns.GridColumn();
            MoedasGC = new DevExpress.XtraGrid.GridControl();
            CoinBindingSource = new System.Windows.Forms.BindingSource(components);
            CoinGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colExternalId = new DevExpress.XtraGrid.Columns.GridColumn();
            colName = new DevExpress.XtraGrid.Columns.GridColumn();
            NameRITE = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            colExternalName = new DevExpress.XtraGrid.Columns.GridColumn();
            colBtcPorDia = new DevExpress.XtraGrid.Columns.GridColumn();
            MoedasRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            GravarBBI = new DevExpress.XtraBars.BarButtonItem();
            MoedasRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            ((System.ComponentModel.ISupportInitialize)MoedasGC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CoinBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CoinGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NameRITE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedasRC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            SuspendLayout();
            // 
            // colCoinId
            // 
            colCoinId.FieldName = "Id";
            colCoinId.MinWidth = 23;
            colCoinId.Name = "colCoinId";
            colCoinId.Visible = true;
            colCoinId.VisibleIndex = 0;
            colCoinId.Width = 87;
            // 
            // MoedasGC
            // 
            MoedasGC.DataSource = CoinBindingSource;
            MoedasGC.Dock = System.Windows.Forms.DockStyle.Fill;
            MoedasGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoedasGC.Location = new System.Drawing.Point(0, 186);
            MoedasGC.MainView = CoinGV;
            MoedasGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoedasGC.Name = "MoedasGC";
            MoedasGC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { NameRITE });
            MoedasGC.Size = new System.Drawing.Size(1440, 591);
            MoedasGC.TabIndex = 1;
            MoedasGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { CoinGV });
            // 
            // MoedasBindingSource
            // 
            CoinBindingSource.DataSource = typeof(Models.Classes.Coin);
            // 
            // MoedasGV
            // 
            CoinGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colExternalId, colName, colExternalName, colBtcPorDia });
            CoinGV.DetailHeight = 458;
            CoinGV.GridControl = MoedasGC;
            CoinGV.Name = "MoedasGV";
            CoinGV.OptionsEditForm.PopupEditFormWidth = 933;
            CoinGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            CoinGV.OptionsMenu.ShowConditionalFormattingItem = true;
            CoinGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            CoinGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            CoinGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            CoinGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            CoinGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            CoinGV.OptionsView.ShowFooter = true;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.OptionsColumn.ReadOnly = true;
            colId.Visible = true;
            colId.VisibleIndex = 0;
            // 
            // colExternalId
            // 
            colExternalId.FieldName = "ExternalId";
            colExternalId.Name = "colExternalId";
            colExternalId.OptionsColumn.ReadOnly = true;
            colExternalId.Visible = true;
            colExternalId.VisibleIndex = 1;
            colExternalId.Width = 99;
            // 
            // colName
            // 
            colName.ColumnEdit = NameRITE;
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.Visible = true;
            colName.VisibleIndex = 2;
            colName.Width = 76;
            // 
            // NameRITE
            // 
            NameRITE.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            NameRITE.AutoHeight = false;
            NameRITE.MaxLength = 500;
            NameRITE.Name = "NameRITE";
            // 
            // colExternalName
            // 
            colExternalName.FieldName = "ExternalName";
            colExternalName.Name = "colExternalName";
            colExternalName.OptionsColumn.ReadOnly = true;
            colExternalName.Visible = true;
            colExternalName.VisibleIndex = 3;
            colExternalName.Width = 124;
            // 
            // colBtcPorDia
            // 
            colBtcPorDia.Caption = "BTC/dia";
            colBtcPorDia.FieldName = "BtcPorDia";
            colBtcPorDia.Name = "colBtcPorDia";
            colBtcPorDia.OptionsColumn.ReadOnly = true;
            colBtcPorDia.Visible = true;
            colBtcPorDia.VisibleIndex = 4;
            colBtcPorDia.Width = 108;
            // 
            // MoedasRC
            // 
            MoedasRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 40, 35, 40);
            MoedasRC.ExpandCollapseItem.Id = 0;
            MoedasRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MoedasRC.ExpandCollapseItem, AtualizarBBI, GravarBBI });
            MoedasRC.Location = new System.Drawing.Point(0, 0);
            MoedasRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoedasRC.MaxItemId = 6;
            MoedasRC.Name = "MoedasRC";
            MoedasRC.OptionsMenuMinWidth = 385;
            MoedasRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { MoedasRP });
            MoedasRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            MoedasRC.Size = new System.Drawing.Size(1440, 186);
            // 
            // AtualizarBBI
            // 
            AtualizarBBI.Caption = "Atualizar";
            AtualizarBBI.Id = 1;
            AtualizarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("AtualizarBBI.ImageOptions.SvgImage");
            AtualizarBBI.Name = "AtualizarBBI";
            AtualizarBBI.ItemClick += RefreshBBI_ItemClick;
            // 
            // GravarBBI
            // 
            GravarBBI.Caption = "Gravar";
            GravarBBI.Id = 5;
            GravarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GravarBBI.ImageOptions.SvgImage");
            GravarBBI.Name = "GravarBBI";
            GravarBBI.ItemClick += SaveBBI_ItemClick;
            // 
            // MoedasRP
            // 
            MoedasRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { OperacoesRPG });
            MoedasRP.Name = "MoedasRP";
            MoedasRP.Text = "Moedas";
            // 
            // OperacoesRPG
            // 
            OperacoesRPG.ItemLinks.Add(AtualizarBBI);
            OperacoesRPG.ItemLinks.Add(GravarBBI);
            OperacoesRPG.Name = "OperacoesRPG";
            OperacoesRPG.Text = "Operações";
            // 
            // MoedasUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(MoedasGC);
            Controls.Add(MoedasRC);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MoedasUserControl";
            Size = new System.Drawing.Size(1440, 777);
            Load += CoinUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)MoedasGC).EndInit();
            ((System.ComponentModel.ISupportInitialize)CoinBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)CoinGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)NameRITE).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoedasRC).EndInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MoedasRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage MoedasRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraGrid.GridControl MoedasGC;
        private DevExpress.XtraGrid.Views.Grid.GridView CoinGV;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private System.Windows.Forms.BindingSource CoinBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCoinId;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colExternalId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBtcPorDia;
        private DevExpress.XtraGrid.Columns.GridColumn colExternalName;
        private DevExpress.XtraBars.BarButtonItem GravarBBI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit NameRITE;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
