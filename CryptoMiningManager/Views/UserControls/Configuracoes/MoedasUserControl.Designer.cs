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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoedasUserControl));
            this.colIdMoeda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MoedasGC = new DevExpress.XtraGrid.GridControl();
            this.MoedasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MoedasGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdExterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeExterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBtcPorDia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MoedasRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.MoedasRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasRC)).BeginInit();
            this.SuspendLayout();
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
            // MoedasGC
            // 
            this.MoedasGC.DataSource = this.MoedasBindingSource;
            this.MoedasGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MoedasGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MoedasGC.Location = new System.Drawing.Point(0, 186);
            this.MoedasGC.MainView = this.MoedasGV;
            this.MoedasGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MoedasGC.Name = "MoedasGC";
            this.MoedasGC.Size = new System.Drawing.Size(1440, 591);
            this.MoedasGC.TabIndex = 1;
            this.MoedasGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MoedasGV});
            // 
            // MoedasBindingSource
            // 
            this.MoedasBindingSource.DataSource = typeof(Modelos.Classes.Moeda);
            // 
            // MoedasGV
            // 
            this.MoedasGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colIdExterno,
            this.colNome,
            this.colNomeExterno,
            this.colBtcPorDia});
            this.MoedasGV.DetailHeight = 458;
            this.MoedasGV.GridControl = this.MoedasGC;
            this.MoedasGV.Name = "MoedasGV";
            this.MoedasGV.OptionsEditForm.PopupEditFormWidth = 933;
            this.MoedasGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            this.MoedasGV.OptionsMenu.ShowConditionalFormattingItem = true;
            this.MoedasGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.MoedasGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.MoedasGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.MoedasGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.MoedasGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            this.MoedasGV.OptionsView.ShowFooter = true;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colIdExterno
            // 
            this.colIdExterno.FieldName = "IdExterno";
            this.colIdExterno.Name = "colIdExterno";
            this.colIdExterno.OptionsColumn.ReadOnly = true;
            this.colIdExterno.Visible = true;
            this.colIdExterno.VisibleIndex = 1;
            this.colIdExterno.Width = 99;
            // 
            // colNome
            // 
            this.colNome.FieldName = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 2;
            this.colNome.Width = 76;
            // 
            // colNomeExterno
            // 
            this.colNomeExterno.FieldName = "NomeExterno";
            this.colNomeExterno.Name = "colNomeExterno";
            this.colNomeExterno.OptionsColumn.ReadOnly = true;
            this.colNomeExterno.Visible = true;
            this.colNomeExterno.VisibleIndex = 3;
            this.colNomeExterno.Width = 124;
            // 
            // colBtcPorDia
            // 
            this.colBtcPorDia.Caption = "BTC/dia";
            this.colBtcPorDia.FieldName = "BtcPorDia";
            this.colBtcPorDia.Name = "colBtcPorDia";
            this.colBtcPorDia.OptionsColumn.ReadOnly = true;
            this.colBtcPorDia.Visible = true;
            this.colBtcPorDia.VisibleIndex = 4;
            this.colBtcPorDia.Width = 108;
            // 
            // MoedasRC
            // 
            this.MoedasRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 40, 35, 40);
            this.MoedasRC.ExpandCollapseItem.Id = 0;
            this.MoedasRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MoedasRC.ExpandCollapseItem,
            this.AtualizarBBI});
            this.MoedasRC.Location = new System.Drawing.Point(0, 0);
            this.MoedasRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MoedasRC.MaxItemId = 5;
            this.MoedasRC.Name = "MoedasRC";
            this.MoedasRC.OptionsMenuMinWidth = 385;
            this.MoedasRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.MoedasRP});
            this.MoedasRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.MoedasRC.Size = new System.Drawing.Size(1440, 186);
            // 
            // AtualizarBBI
            // 
            this.AtualizarBBI.Caption = "Atualizar";
            this.AtualizarBBI.Id = 1;
            this.AtualizarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("AtualizarBBI.ImageOptions.SvgImage")));
            this.AtualizarBBI.Name = "AtualizarBBI";
            this.AtualizarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AtualizarBBI_ItemClick);
            // 
            // MoedasRP
            // 
            this.MoedasRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.OperacoesRPG});
            this.MoedasRP.Name = "MoedasRP";
            this.MoedasRP.Text = "Moedas";
            // 
            // OperacoesRPG
            // 
            this.OperacoesRPG.ItemLinks.Add(this.AtualizarBBI);
            this.OperacoesRPG.Name = "OperacoesRPG";
            this.OperacoesRPG.Text = "Operações";
            // 
            // MoedasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MoedasGC);
            this.Controls.Add(this.MoedasRC);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MoedasUserControl";
            this.Size = new System.Drawing.Size(1440, 777);
            this.Load += new System.EventHandler(this.MineradoresUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasRC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
