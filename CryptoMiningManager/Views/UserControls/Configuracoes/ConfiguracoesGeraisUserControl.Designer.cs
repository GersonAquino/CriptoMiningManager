namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    partial class ConfiguracoesGeraisUserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracoesGeraisUserControl));
			ConfigsGeraisGC = new DevExpress.XtraGrid.GridControl();
			ConfigsGeraisBindingSource = new System.Windows.Forms.BindingSource(components);
			ConfigsGeraisGV = new DevExpress.XtraGrid.Views.Grid.GridView();
			colId = new DevExpress.XtraGrid.Columns.GridColumn();
			colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
			colAtualizarUIMinimizado = new DevExpress.XtraGrid.Columns.GridColumn();
			colConfirmacoesExtraNosEditores = new DevExpress.XtraGrid.Columns.GridColumn();
			colIniciarMinimizada = new DevExpress.XtraGrid.Columns.GridColumn();
			colAlgoritmo = new DevExpress.XtraGrid.Columns.GridColumn();
			colMedirConsumo = new DevExpress.XtraGrid.Columns.GridColumn();
			colMinimizarAoFechar = new DevExpress.XtraGrid.Columns.GridColumn();
			colPesoConsumo = new DevExpress.XtraGrid.Columns.GridColumn();
			colAtivo = new DevExpress.XtraGrid.Columns.GridColumn();
			colDataCriacao = new DevExpress.XtraGrid.Columns.GridColumn();
			colDataAlteracao = new DevExpress.XtraGrid.Columns.GridColumn();
			ConfigsGeraisRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
			AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
			NovoBBI = new DevExpress.XtraBars.BarButtonItem();
			EditarBBI = new DevExpress.XtraBars.BarButtonItem();
			EliminarBBI = new DevExpress.XtraBars.BarButtonItem();
			ConfigsGeraisRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
			OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			colAlternarModoEnergia = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisGC).BeginInit();
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisGV).BeginInit();
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisRC).BeginInit();
			SuspendLayout();
			// 
			// ConfigsGeraisGC
			// 
			ConfigsGeraisGC.DataSource = ConfigsGeraisBindingSource;
			ConfigsGeraisGC.Dock = System.Windows.Forms.DockStyle.Fill;
			ConfigsGeraisGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			ConfigsGeraisGC.Location = new System.Drawing.Point(0, 173);
			ConfigsGeraisGC.MainView = ConfigsGeraisGV;
			ConfigsGeraisGC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			ConfigsGeraisGC.Name = "ConfigsGeraisGC";
			ConfigsGeraisGC.Size = new System.Drawing.Size(1453, 671);
			ConfigsGeraisGC.TabIndex = 1;
			ConfigsGeraisGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { ConfigsGeraisGV });
			// 
			// ConfigsGeraisBindingSource
			// 
			ConfigsGeraisBindingSource.DataSource = typeof(Modelos.Classes.ConfiguracaoGeral);
			// 
			// ConfigsGeraisGV
			// 
			ConfigsGeraisGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colDescricao, colAlternarModoEnergia, colAtualizarUIMinimizado, colConfirmacoesExtraNosEditores, colIniciarMinimizada, colAlgoritmo, colMedirConsumo, colMinimizarAoFechar, colPesoConsumo, colAtivo, colDataCriacao, colDataAlteracao });
			ConfigsGeraisGV.CustomizationFormBounds = new System.Drawing.Rectangle(1241, 662, 259, 290);
			ConfigsGeraisGV.GridControl = ConfigsGeraisGC;
			ConfigsGeraisGV.Name = "ConfigsGeraisGV";
			ConfigsGeraisGV.OptionsBehavior.Editable = false;
			ConfigsGeraisGV.OptionsBehavior.ReadOnly = true;
			ConfigsGeraisGV.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Push;
			ConfigsGeraisGV.OptionsMenu.ShowConditionalFormattingItem = true;
			ConfigsGeraisGV.OptionsMenu.ShowGroupSummaryEditorItem = true;
			ConfigsGeraisGV.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.True;
			ConfigsGeraisGV.OptionsSelection.MultiSelect = true;
			ConfigsGeraisGV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
			ConfigsGeraisGV.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
			ConfigsGeraisGV.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
			ConfigsGeraisGV.OptionsView.FilterCriteriaDisplayStyle = DevExpress.XtraEditors.FilterCriteriaDisplayStyle.Visual;
			ConfigsGeraisGV.OptionsView.ShowFooter = true;
			ConfigsGeraisGV.DoubleClick += ConfigsGeraisGV_DoubleClick;
			// 
			// colId
			// 
			colId.FieldName = "Id";
			colId.MinWidth = 17;
			colId.Name = "colId";
			colId.Width = 64;
			// 
			// colDescricao
			// 
			colDescricao.Caption = "Descrição";
			colDescricao.FieldName = "Descricao";
			colDescricao.MinWidth = 17;
			colDescricao.Name = "colDescricao";
			colDescricao.Visible = true;
			colDescricao.VisibleIndex = 1;
			colDescricao.Width = 130;
			// 
			// colAtualizarUIMinimizado
			// 
			colAtualizarUIMinimizado.Caption = "Atualizar UI Min.";
			colAtualizarUIMinimizado.FieldName = "AtualizarUIMinimizado";
			colAtualizarUIMinimizado.Name = "colAtualizarUIMinimizado";
			colAtualizarUIMinimizado.ToolTip = "Atualizar UI enquanto o programa está minimizado";
			colAtualizarUIMinimizado.Visible = true;
			colAtualizarUIMinimizado.VisibleIndex = 3;
			colAtualizarUIMinimizado.Width = 130;
			// 
			// colConfirmacoesExtraNosEditores
			// 
			colConfirmacoesExtraNosEditores.Caption = "Confirmações Extra";
			colConfirmacoesExtraNosEditores.FieldName = "ConfirmacoesExtraNosEditores";
			colConfirmacoesExtraNosEditores.Name = "colConfirmacoesExtraNosEditores";
			colConfirmacoesExtraNosEditores.ToolTip = "Mostrar confirmações extras nos editores";
			colConfirmacoesExtraNosEditores.Visible = true;
			colConfirmacoesExtraNosEditores.VisibleIndex = 4;
			colConfirmacoesExtraNosEditores.Width = 134;
			// 
			// colIniciarMinimizada
			// 
			colIniciarMinimizada.FieldName = "IniciarMinimizada";
			colIniciarMinimizada.MinWidth = 17;
			colIniciarMinimizada.Name = "colIniciarMinimizada";
			colIniciarMinimizada.Visible = true;
			colIniciarMinimizada.VisibleIndex = 5;
			colIniciarMinimizada.Width = 130;
			// 
			// colAlgoritmo
			// 
			colAlgoritmo.FieldName = "Algoritmo";
			colAlgoritmo.Name = "colAlgoritmo";
			colAlgoritmo.ToolTip = "Algoritmo por defeito";
			colAlgoritmo.Visible = true;
			colAlgoritmo.VisibleIndex = 6;
			colAlgoritmo.Width = 152;
			// 
			// colMedirConsumo
			// 
			colMedirConsumo.FieldName = "MedirConsumo";
			colMedirConsumo.MinWidth = 17;
			colMedirConsumo.Name = "colMedirConsumo";
			colMedirConsumo.ToolTip = "Medir consumo do(s) componente(s) a ser usado(s) na mineração";
			colMedirConsumo.Visible = true;
			colMedirConsumo.VisibleIndex = 7;
			colMedirConsumo.Width = 113;
			// 
			// colMinimizarAoFechar
			// 
			colMinimizarAoFechar.Caption = "Minimizar ao Fechar";
			colMinimizarAoFechar.FieldName = "MinimizarAoFechar";
			colMinimizarAoFechar.MinWidth = 17;
			colMinimizarAoFechar.Name = "colMinimizarAoFechar";
			colMinimizarAoFechar.ToolTip = "Continua a executar o programa em background ao fechar";
			colMinimizarAoFechar.Visible = true;
			colMinimizarAoFechar.VisibleIndex = 8;
			colMinimizarAoFechar.Width = 135;
			// 
			// colPesoConsumo
			// 
			colPesoConsumo.FieldName = "PesoConsumo";
			colPesoConsumo.MinWidth = 17;
			colPesoConsumo.Name = "colPesoConsumo";
			colPesoConsumo.ToolTip = "Peso do consumo (Watts)";
			colPesoConsumo.Visible = true;
			colPesoConsumo.VisibleIndex = 9;
			colPesoConsumo.Width = 135;
			// 
			// colAtivo
			// 
			colAtivo.Caption = "Ativa";
			colAtivo.FieldName = "Ativo";
			colAtivo.MinWidth = 17;
			colAtivo.Name = "colAtivo";
			colAtivo.Visible = true;
			colAtivo.VisibleIndex = 10;
			colAtivo.Width = 143;
			// 
			// colDataCriacao
			// 
			colDataCriacao.Caption = "Data Criação";
			colDataCriacao.FieldName = "DataCriacao";
			colDataCriacao.MinWidth = 17;
			colDataCriacao.Name = "colDataCriacao";
			colDataCriacao.Width = 64;
			// 
			// colDataAlteracao
			// 
			colDataAlteracao.Caption = "Data Alteração";
			colDataAlteracao.FieldName = "DataAlteracao";
			colDataAlteracao.MinWidth = 17;
			colDataAlteracao.Name = "colDataAlteracao";
			colDataAlteracao.Width = 64;
			// 
			// ConfigsGeraisRC
			// 
			ConfigsGeraisRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(30, 31, 30, 31);
			ConfigsGeraisRC.ExpandCollapseItem.Id = 0;
			ConfigsGeraisRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ConfigsGeraisRC.ExpandCollapseItem, AtualizarBBI, NovoBBI, EditarBBI, EliminarBBI });
			ConfigsGeraisRC.Location = new System.Drawing.Point(0, 0);
			ConfigsGeraisRC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			ConfigsGeraisRC.MaxItemId = 5;
			ConfigsGeraisRC.Name = "ConfigsGeraisRC";
			ConfigsGeraisRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ConfigsGeraisRP });
			ConfigsGeraisRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
			ConfigsGeraisRC.Size = new System.Drawing.Size(1453, 173);
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
			// ConfigsGeraisRP
			// 
			ConfigsGeraisRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { OperacoesRPG });
			ConfigsGeraisRP.Name = "ConfigsGeraisRP";
			ConfigsGeraisRP.Text = "ConfigsGerais";
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
			// colAlternarModoEnergia
			// 
			colAlternarModoEnergia.FieldName = "AlternarModoEnergia";
			colAlternarModoEnergia.Name = "colAlternarModoEnergia";
			colAlternarModoEnergia.Visible = true;
			colAlternarModoEnergia.VisibleIndex = 2;
			colAlternarModoEnergia.Width = 152;
			// 
			// ConfiguracoesGeraisUserControl
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(ConfigsGeraisGC);
			Controls.Add(ConfigsGeraisRC);
			Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			Name = "ConfiguracoesGeraisUserControl";
			Size = new System.Drawing.Size(1453, 844);
			Load += ConfiguracoesGeraisUserControl_Load;
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisGC).EndInit();
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisGV).EndInit();
			((System.ComponentModel.ISupportInitialize)ConfigsGeraisRC).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ConfigsGeraisRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ConfigsGeraisRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraGrid.GridControl ConfigsGeraisGC;
        private DevExpress.XtraGrid.Views.Grid.GridView ConfigsGeraisGV;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private DevExpress.XtraBars.BarButtonItem NovoBBI;
        private DevExpress.XtraBars.BarButtonItem EditarBBI;
        private DevExpress.XtraBars.BarButtonItem EliminarBBI;
        private System.Windows.Forms.BindingSource ConfigsGeraisBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colId;
		private DevExpress.XtraGrid.Columns.GridColumn colIniciarMinimizada;
		private DevExpress.XtraGrid.Columns.GridColumn colMedirConsumo;
		private DevExpress.XtraGrid.Columns.GridColumn colMinimizarAoFechar;
		private DevExpress.XtraGrid.Columns.GridColumn colPesoConsumo;
		private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
		private DevExpress.XtraGrid.Columns.GridColumn colAtivo;
		private DevExpress.XtraGrid.Columns.GridColumn colDataCriacao;
		private DevExpress.XtraGrid.Columns.GridColumn colDataAlteracao;
		private DevExpress.XtraGrid.Columns.GridColumn colAtualizarUIMinimizado;
		private DevExpress.XtraGrid.Columns.GridColumn colConfirmacoesExtraNosEditores;
		private DevExpress.XtraGrid.Columns.GridColumn colAlgoritmo;
		private DevExpress.XtraGrid.Columns.GridColumn colAlternarModoEnergia;
	}
}
