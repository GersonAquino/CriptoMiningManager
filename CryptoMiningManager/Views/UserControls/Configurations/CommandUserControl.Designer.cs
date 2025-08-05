namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    partial class CommandUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandUserControl));
            this.ComandosRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.NovoBBI = new DevExpress.XtraBars.BarButtonItem();
            this.EditarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.EliminarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.ComandosRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ComandosGC = new DevExpress.XtraGrid.GridControl();
            this.ComandosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ComandosGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComandos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPreMineracao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosMineracao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAtivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataCriacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataAlteracao = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosGC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ComandosRC
            // 
            this.ComandosRC.ExpandCollapseItem.Id = 0;
            this.ComandosRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ComandosRC.ExpandCollapseItem,
            this.AtualizarBBI,
            this.NovoBBI,
            this.EditarBBI,
            this.EliminarBBI});
            this.ComandosRC.Location = new System.Drawing.Point(0, 0);
            this.ComandosRC.MaxItemId = 5;
            this.ComandosRC.Name = "ComandosRC";
            this.ComandosRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ComandosRP});
            this.ComandosRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ComandosRC.Size = new System.Drawing.Size(1603, 186);
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
            // ComandosRP
            // 
            this.ComandosRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.OperacoesRPG});
            this.ComandosRP.Name = "ComandosRP";
            this.ComandosRP.Text = "Comandos";
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
            // ComandosGC
            // 
            this.ComandosGC.DataSource = this.ComandosBindingSource;
            this.ComandosGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComandosGC.Location = new System.Drawing.Point(0, 186);
            this.ComandosGC.MainView = this.ComandosGV;
            this.ComandosGC.Name = "ComandosGC";
            this.ComandosGC.Size = new System.Drawing.Size(1603, 691);
            this.ComandosGC.TabIndex = 1;
            this.ComandosGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ComandosGV});
            // 
            // ComandosBindingSource
            // 
            this.ComandosBindingSource.DataSource = typeof(Models.Classes.Command);
            // 
            // ComandosGV
            // 
            this.ComandosGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComandos,
            this.colPreMineracao,
            this.colPosMineracao,
            this.colId,
            this.colAtivo,
            this.colDataCriacao,
            this.colDataAlteracao});
            this.ComandosGV.GridControl = this.ComandosGC;
            this.ComandosGV.Name = "ComandosGV";
            this.ComandosGV.OptionsBehavior.Editable = false;
            this.ComandosGV.OptionsBehavior.ReadOnly = true;
            this.ComandosGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            this.ComandosGV.OptionsMenu.ShowConditionalFormattingItem = true;
            this.ComandosGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.ComandosGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.ComandosGV.OptionsSelection.MultiSelect = true;
            this.ComandosGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.ComandosGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.ComandosGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.ComandosGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            this.ComandosGV.OptionsView.ShowFooter = true;
            this.ComandosGV.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colId, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.ComandosGV.DoubleClick += new System.EventHandler(this.ComandosGV_DoubleClick);
            // 
            // colComandos
            // 
            this.colComandos.FieldName = "Comandos";
            this.colComandos.Name = "colComandos";
            this.colComandos.Visible = true;
            this.colComandos.VisibleIndex = 2;
            // 
            // colPreMineracao
            // 
            this.colPreMineracao.Caption = "Pré Mineração";
            this.colPreMineracao.FieldName = "PreMineracao";
            this.colPreMineracao.Name = "colPreMineracao";
            this.colPreMineracao.Visible = true;
            this.colPreMineracao.VisibleIndex = 3;
            // 
            // colPosMineracao
            // 
            this.colPosMineracao.Caption = "Pós Mineração";
            this.colPosMineracao.FieldName = "PosMineracao";
            this.colPosMineracao.Name = "colPosMineracao";
            this.colPosMineracao.Visible = true;
            this.colPosMineracao.VisibleIndex = 4;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            // 
            // colAtivo
            // 
            this.colAtivo.FieldName = "Ativo";
            this.colAtivo.Name = "colAtivo";
            this.colAtivo.Visible = true;
            this.colAtivo.VisibleIndex = 5;
            // 
            // colDataCriacao
            // 
            this.colDataCriacao.Caption = "Data Criação";
            this.colDataCriacao.FieldName = "DataCriacao";
            this.colDataCriacao.Name = "colDataCriacao";
            this.colDataCriacao.Visible = true;
            this.colDataCriacao.VisibleIndex = 6;
            // 
            // colDataAlteracao
            // 
            this.colDataAlteracao.Caption = "Data Alteração";
            this.colDataAlteracao.FieldName = "DataAlteracao";
            this.colDataAlteracao.Name = "colDataAlteracao";
            this.colDataAlteracao.Visible = true;
            this.colDataAlteracao.VisibleIndex = 7;
            // 
            // ComandosUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComandosGC);
            this.Controls.Add(this.ComandosRC);
            this.Name = "ComandosUserControl";
            this.Size = new System.Drawing.Size(1603, 877);
            this.Load += new System.EventHandler(this.ComandosUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ComandosRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosGC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ComandosRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ComandosRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraGrid.GridControl ComandosGC;
        private DevExpress.XtraGrid.Views.Grid.GridView ComandosGV;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private DevExpress.XtraBars.BarButtonItem NovoBBI;
        private DevExpress.XtraBars.BarButtonItem EditarBBI;
        private DevExpress.XtraBars.BarButtonItem EliminarBBI;
        private System.Windows.Forms.BindingSource ComandosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colComandos;
        private DevExpress.XtraGrid.Columns.GridColumn colPreMineracao;
        private DevExpress.XtraGrid.Columns.GridColumn colPosMineracao;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAtivo;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCriacao;
        private DevExpress.XtraGrid.Columns.GridColumn colDataAlteracao;
    }
}
