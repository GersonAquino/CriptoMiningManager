namespace CryptoMiningManager.Views.UserControls.Configurations
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
            this.CommandsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CommandGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComandos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPreMining = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAfterMining = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosGC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandGV)).BeginInit();
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
            this.AtualizarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RefreshBBI_ItemClick);
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
            this.EditarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EditBBI_ItemClick);
            // 
            // EliminarBBI
            // 
            this.EliminarBBI.Caption = "Eliminar";
            this.EliminarBBI.Id = 4;
            this.EliminarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("EliminarBBI.ImageOptions.SvgImage")));
            this.EliminarBBI.Name = "EliminarBBI";
            this.EliminarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DeleteBBI_ItemClick);
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
            this.ComandosGC.DataSource = this.CommandsBindingSource;
            this.ComandosGC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComandosGC.Location = new System.Drawing.Point(0, 186);
            this.ComandosGC.MainView = this.CommandGV;
            this.ComandosGC.Name = "ComandosGC";
            this.ComandosGC.Size = new System.Drawing.Size(1603, 691);
            this.ComandosGC.TabIndex = 1;
            this.ComandosGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CommandGV});
            // 
            // ComandosBindingSource
            // 
            this.CommandsBindingSource.DataSource = typeof(Models.Classes.Command);
            // 
            // ComandosGV
            // 
            this.CommandGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComandos,
            this.colPreMining,
            this.colAfterMining,
            this.colId,
            this.colActive,
            this.colCreatedDate,
            this.colUpdatedDate});
            this.CommandGV.GridControl = this.ComandosGC;
            this.CommandGV.Name = "ComandosGV";
            this.CommandGV.OptionsBehavior.Editable = false;
            this.CommandGV.OptionsBehavior.ReadOnly = true;
            this.CommandGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
            this.CommandGV.OptionsMenu.ShowConditionalFormattingItem = true;
            this.CommandGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.CommandGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
            this.CommandGV.OptionsSelection.MultiSelect = true;
            this.CommandGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.CommandGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.CommandGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.CommandGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
            this.CommandGV.OptionsView.ShowFooter = true;
            this.CommandGV.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colId, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.CommandGV.DoubleClick += new System.EventHandler(this.CommandGV_DoubleClick);
            // 
            // colComandos
            // 
            this.colComandos.FieldName = "Comandos";
            this.colComandos.Name = "colComandos";
            this.colComandos.Visible = true;
            this.colComandos.VisibleIndex = 2;
            // 
            // colPreMining
            // 
            this.colPreMining.Caption = "Pré Mineração";
            this.colPreMining.FieldName = "PreMining";
            this.colPreMining.Name = "colPreMining";
            this.colPreMining.Visible = true;
            this.colPreMining.VisibleIndex = 3;
            // 
            // colAfterMining
            // 
            this.colAfterMining.Caption = "Pós Mineração";
            this.colAfterMining.FieldName = "AfterMining";
            this.colAfterMining.Name = "colAfterMining";
            this.colAfterMining.Visible = true;
            this.colAfterMining.VisibleIndex = 4;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 1;
            // 
            // colActive
            // 
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 5;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Data Criação";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 6;
            // 
            // colUpdatedDate
            // 
            this.colUpdatedDate.Caption = "Data Alteração";
            this.colUpdatedDate.FieldName = "UpdatedDate";
            this.colUpdatedDate.Name = "colUpdatedDate";
            this.colUpdatedDate.Visible = true;
            this.colUpdatedDate.VisibleIndex = 7;
            // 
            // ComandosUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ComandosGC);
            this.Controls.Add(this.ComandosRC);
            this.Name = "ComandosUserControl";
            this.Size = new System.Drawing.Size(1603, 877);
            this.Load += new System.EventHandler(this.CommandUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ComandosRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosGC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ComandosRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ComandosRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraGrid.GridControl ComandosGC;
        private DevExpress.XtraGrid.Views.Grid.GridView CommandGV;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private DevExpress.XtraBars.BarButtonItem NovoBBI;
        private DevExpress.XtraBars.BarButtonItem EditarBBI;
        private DevExpress.XtraBars.BarButtonItem EliminarBBI;
        private System.Windows.Forms.BindingSource CommandsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colComandos;
        private DevExpress.XtraGrid.Columns.GridColumn colPreMining;
        private DevExpress.XtraGrid.Columns.GridColumn colAfterMining;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
    }
}
