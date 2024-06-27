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
			colConsumoMedio = new DevExpress.XtraGrid.Columns.GridColumn();
			colCPU = new DevExpress.XtraGrid.Columns.GridColumn();
			colGPU = new DevExpress.XtraGrid.Columns.GridColumn();
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
			MineradoresGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			MineradoresGC.Location = new System.Drawing.Point(0, 173);
			MineradoresGC.MainView = MineradoresGV;
			MineradoresGC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			MineradoresGC.Name = "MineradoresGC";
			MineradoresGC.Size = new System.Drawing.Size(1453, 671);
			MineradoresGC.TabIndex = 1;
			MineradoresGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { MineradoresGV });
			// 
			// MineradoresBindingSource
			// 
			MineradoresBindingSource.DataSource = typeof(Modelos.Classes.Minerador);
			// 
			// MineradoresGV
			// 
			MineradoresGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdMinerador, colNomeMinerador, colMoeda, colLocalizacaoMinerador, colParametrosMinerador, colConsumoMedio, colCPU, colGPU, colAtivoMinerador, colDataCriacaoMinerador, colDataAlteracaoMinerador, colIdMoeda, colMoedaObj });
			MineradoresGV.GridControl = MineradoresGC;
			MineradoresGV.Name = "MineradoresGV";
			MineradoresGV.OptionsBehavior.Editable = false;
			MineradoresGV.OptionsBehavior.ReadOnly = true;
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
			colIdMinerador.Name = "colIdMinerador";
			colIdMinerador.Visible = true;
			colIdMinerador.VisibleIndex = 1;
			// 
			// colNomeMinerador
			// 
			colNomeMinerador.FieldName = "Nome";
			colNomeMinerador.MinWidth = 17;
			colNomeMinerador.Name = "colNomeMinerador";
			colNomeMinerador.Visible = true;
			colNomeMinerador.VisibleIndex = 2;
			colNomeMinerador.Width = 64;
			// 
			// colMoeda
			// 
			colMoeda.Caption = "Moeda";
			colMoeda.FieldName = "Moeda";
			colMoeda.MinWidth = 17;
			colMoeda.Name = "colMoeda";
			colMoeda.UnboundDataType = typeof(string);
			colMoeda.UnboundExpression = "ToStr([Moeda.Id]) + ' - ' + [Moeda.Nome]";
			colMoeda.Visible = true;
			colMoeda.VisibleIndex = 3;
			colMoeda.Width = 64;
			// 
			// colLocalizacaoMinerador
			// 
			colLocalizacaoMinerador.Caption = "Localização";
			colLocalizacaoMinerador.FieldName = "Localizacao";
			colLocalizacaoMinerador.Name = "colLocalizacaoMinerador";
			colLocalizacaoMinerador.Visible = true;
			colLocalizacaoMinerador.VisibleIndex = 4;
			colLocalizacaoMinerador.Width = 92;
			// 
			// colParametrosMinerador
			// 
			colParametrosMinerador.Caption = "Parâmetros";
			colParametrosMinerador.FieldName = "Parametros";
			colParametrosMinerador.MaxWidth = 257;
			colParametrosMinerador.Name = "colParametrosMinerador";
			colParametrosMinerador.Visible = true;
			colParametrosMinerador.VisibleIndex = 5;
			colParametrosMinerador.Width = 92;
			// 
			// colConsumoMedio
			// 
			colConsumoMedio.Caption = "Consumo Médio (Watts)";
			colConsumoMedio.FieldName = "ConsumoMedio";
			colConsumoMedio.Name = "colConsumoMedio";
			colConsumoMedio.Visible = true;
			colConsumoMedio.VisibleIndex = 6;
			colConsumoMedio.Width = 155;
			// 
			// colCPU
			// 
			colCPU.FieldName = "CPU";
			colCPU.Name = "colCPU";
			colCPU.Visible = true;
			colCPU.VisibleIndex = 7;
			colCPU.Width = 64;
			// 
			// colGPU
			// 
			colGPU.FieldName = "GPU";
			colGPU.Name = "colGPU";
			colGPU.Visible = true;
			colGPU.VisibleIndex = 8;
			colGPU.Width = 64;
			// 
			// colAtivoMinerador
			// 
			colAtivoMinerador.FieldName = "Ativo";
			colAtivoMinerador.Name = "colAtivoMinerador";
			colAtivoMinerador.Visible = true;
			colAtivoMinerador.VisibleIndex = 9;
			// 
			// colDataCriacaoMinerador
			// 
			colDataCriacaoMinerador.Caption = "Data Criação";
			colDataCriacaoMinerador.FieldName = "DataCriacao";
			colDataCriacaoMinerador.Name = "colDataCriacaoMinerador";
			colDataCriacaoMinerador.Visible = true;
			colDataCriacaoMinerador.VisibleIndex = 10;
			colDataCriacaoMinerador.Width = 99;
			// 
			// colDataAlteracaoMinerador
			// 
			colDataAlteracaoMinerador.Caption = "Data Alteração";
			colDataAlteracaoMinerador.FieldName = "DataAlteracao";
			colDataAlteracaoMinerador.Name = "colDataAlteracaoMinerador";
			colDataAlteracaoMinerador.Visible = true;
			colDataAlteracaoMinerador.VisibleIndex = 11;
			colDataAlteracaoMinerador.Width = 108;
			// 
			// colIdMoeda
			// 
			colIdMoeda.FieldName = "IdMoeda";
			colIdMoeda.MinWidth = 17;
			colIdMoeda.Name = "colIdMoeda";
			colIdMoeda.OptionsColumn.AllowEdit = false;
			colIdMoeda.OptionsColumn.ReadOnly = true;
			colIdMoeda.Width = 64;
			// 
			// colMoedaObj
			// 
			colMoedaObj.FieldName = "Moeda";
			colMoedaObj.MinWidth = 17;
			colMoedaObj.Name = "colMoedaObj";
			colMoedaObj.OptionsColumn.AllowEdit = false;
			colMoedaObj.OptionsColumn.AllowShowHide = false;
			colMoedaObj.OptionsColumn.ReadOnly = true;
			colMoedaObj.OptionsColumn.ShowInCustomizationForm = false;
			colMoedaObj.Width = 64;
			// 
			// MineradoresRC
			// 
			MineradoresRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(30, 31, 30, 31);
			MineradoresRC.ExpandCollapseItem.Id = 0;
			MineradoresRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MineradoresRC.ExpandCollapseItem, AtualizarBBI, NovoBBI, EditarBBI, EliminarBBI });
			MineradoresRC.Location = new System.Drawing.Point(0, 0);
			MineradoresRC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			MineradoresRC.MaxItemId = 5;
			MineradoresRC.Name = "MineradoresRC";
			MineradoresRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { MineradoresRP });
			MineradoresRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
			MineradoresRC.Size = new System.Drawing.Size(1453, 173);
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
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(MineradoresGC);
			Controls.Add(MineradoresRC);
			Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			Name = "MineradoresUserControl";
			Size = new System.Drawing.Size(1453, 844);
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
		private DevExpress.XtraGrid.Columns.GridColumn colConsumoMedio;
		private DevExpress.XtraGrid.Columns.GridColumn colCPU;
		private DevExpress.XtraGrid.Columns.GridColumn colGPU;
	}
}
