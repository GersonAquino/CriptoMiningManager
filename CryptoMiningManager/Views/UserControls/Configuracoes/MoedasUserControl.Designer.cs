namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    partial class MoedasUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoedasUserControl));
            colIdMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            MoedasGC = new DevExpress.XtraGrid.GridControl();
            MoedasBindingSource = new System.Windows.Forms.BindingSource(components);
            MoedasGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdExterno = new DevExpress.XtraGrid.Columns.GridColumn();
            colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            NomeRITE = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            colNomeExterno = new DevExpress.XtraGrid.Columns.GridColumn();
            colBtcPorDia = new DevExpress.XtraGrid.Columns.GridColumn();
            MoedasRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            GravarBBI = new DevExpress.XtraBars.BarButtonItem();
            MoedasRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            ((System.ComponentModel.ISupportInitialize)MoedasGC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedasGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NomeRITE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedasRC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            SuspendLayout();
            // 
            // colIdMoeda
            // 
            colIdMoeda.FieldName = "Id";
            colIdMoeda.MinWidth = 23;
            colIdMoeda.Name = "colIdMoeda";
            colIdMoeda.Visible = true;
            colIdMoeda.VisibleIndex = 0;
            colIdMoeda.Width = 87;
            // 
            // MoedasGC
            // 
            MoedasGC.DataSource = MoedasBindingSource;
            MoedasGC.Dock = System.Windows.Forms.DockStyle.Fill;
            MoedasGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoedasGC.Location = new System.Drawing.Point(0, 186);
            MoedasGC.MainView = MoedasGV;
            MoedasGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoedasGC.Name = "MoedasGC";
            MoedasGC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { NomeRITE });
            MoedasGC.Size = new System.Drawing.Size(1440, 591);
            MoedasGC.TabIndex = 1;
            MoedasGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { MoedasGV });
            // 
            // MoedasBindingSource
            // 
            MoedasBindingSource.DataSource = typeof(Modelos.Classes.Moeda);
            // 
            // MoedasGV
            // 
            MoedasGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colIdExterno, colNome, colNomeExterno, colBtcPorDia });
            MoedasGV.DetailHeight = 458;
            MoedasGV.GridControl = MoedasGC;
            MoedasGV.Name = "MoedasGV";
            MoedasGV.OptionsEditForm.PopupEditFormWidth = 933;
            MoedasGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            MoedasGV.OptionsMenu.ShowConditionalFormattingItem = true;
            MoedasGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            MoedasGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            MoedasGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            MoedasGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            MoedasGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            MoedasGV.OptionsView.ShowFooter = true;
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.OptionsColumn.ReadOnly = true;
            colId.Visible = true;
            colId.VisibleIndex = 0;
            // 
            // colIdExterno
            // 
            colIdExterno.FieldName = "IdExterno";
            colIdExterno.Name = "colIdExterno";
            colIdExterno.OptionsColumn.ReadOnly = true;
            colIdExterno.Visible = true;
            colIdExterno.VisibleIndex = 1;
            colIdExterno.Width = 99;
            // 
            // colNome
            // 
            colNome.ColumnEdit = NomeRITE;
            colNome.FieldName = "Nome";
            colNome.Name = "colNome";
            colNome.Visible = true;
            colNome.VisibleIndex = 2;
            colNome.Width = 76;
            // 
            // NomeRITE
            // 
            NomeRITE.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            NomeRITE.AutoHeight = false;
            NomeRITE.MaxLength = 500;
            NomeRITE.Name = "NomeRITE";
            // 
            // colNomeExterno
            // 
            colNomeExterno.FieldName = "NomeExterno";
            colNomeExterno.Name = "colNomeExterno";
            colNomeExterno.OptionsColumn.ReadOnly = true;
            colNomeExterno.Visible = true;
            colNomeExterno.VisibleIndex = 3;
            colNomeExterno.Width = 124;
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
            AtualizarBBI.ItemClick += AtualizarBBI_ItemClick;
            // 
            // GravarBBI
            // 
            GravarBBI.Caption = "Gravar";
            GravarBBI.Id = 5;
            GravarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GravarBBI.ImageOptions.SvgImage");
            GravarBBI.Name = "GravarBBI";
            GravarBBI.ItemClick += GravarBBI_ItemClick;
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
            Load += MineradoresUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)MoedasGC).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoedasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoedasGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)NomeRITE).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView MoedasGV;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private System.Windows.Forms.BindingSource MoedasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMoeda;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colIdExterno;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn colBtcPorDia;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeExterno;
        private DevExpress.XtraBars.BarButtonItem GravarBBI;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit NomeRITE;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
