namespace CriptoMiningManager.Views.UserControls.Configuracoes
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
			colAlternarModoEnergia = new DevExpress.XtraGrid.Columns.GridColumn();
			colAtualizarUIMinimizado = new DevExpress.XtraGrid.Columns.GridColumn();
			colConfirmacoesExtraNosEditores = new DevExpress.XtraGrid.Columns.GridColumn();
			colIniciarMinimizada = new DevExpress.XtraGrid.Columns.GridColumn();
			colAlgoritmo = new DevExpress.XtraGrid.Columns.GridColumn();
			colMedirConsumo = new DevExpress.XtraGrid.Columns.GridColumn();
			colMinimizarAoFechar = new DevExpress.XtraGrid.Columns.GridColumn();
			colPesoConsumo = new DevExpress.XtraGrid.Columns.GridColumn();
			colLocalizacaoLogsMineracao = new DevExpress.XtraGrid.Columns.GridColumn();
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
			ConfigsGeraisGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			ConfigsGeraisGC.Location = new System.Drawing.Point(0, 177);
			ConfigsGeraisGC.MainView = ConfigsGeraisGV;
			ConfigsGeraisGC.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			ConfigsGeraisGC.Name = "ConfigsGeraisGC";
			ConfigsGeraisGC.Size = new System.Drawing.Size(1695, 862);
			ConfigsGeraisGC.TabIndex = 1;
			ConfigsGeraisGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { ConfigsGeraisGV });
			// 
			// ConfigsGeraisBindingSource
			// 
			ConfigsGeraisBindingSource.DataSource = typeof(Modelos.Classes.ConfiguracaoGeral);
			// 
			// ConfigsGeraisGV
			// 
			ConfigsGeraisGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colDescricao, colAlternarModoEnergia, colAtualizarUIMinimizado, colConfirmacoesExtraNosEditores, colIniciarMinimizada, colAlgoritmo, colMedirConsumo, colMinimizarAoFechar, colPesoConsumo, colLocalizacaoLogsMineracao, colAtivo, colDataCriacao, colDataAlteracao });
			ConfigsGeraisGV.CustomizationFormBounds = new System.Drawing.Rectangle(1241, 662, 302, 357);
			ConfigsGeraisGV.DetailHeight = 431;
			ConfigsGeraisGV.GridControl = ConfigsGeraisGC;
			ConfigsGeraisGV.Name = "ConfigsGeraisGV";
			ConfigsGeraisGV.OptionsBehavior.Editable = false;
			ConfigsGeraisGV.OptionsBehavior.ReadOnly = true;
			ConfigsGeraisGV.OptionsEditForm.PopupEditFormWidth = 933;
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
			colId.Name = "colId";
			// 
			// colDescricao
			// 
			colDescricao.Caption = "Descrição";
			colDescricao.FieldName = "Descricao";
			colDescricao.Name = "colDescricao";
			colDescricao.Visible = true;
			colDescricao.VisibleIndex = 1;
			colDescricao.Width = 152;
			// 
			// colAlternarModoEnergia
			// 
			colAlternarModoEnergia.FieldName = "AlternarModoEnergia";
			colAlternarModoEnergia.MinWidth = 23;
			colAlternarModoEnergia.Name = "colAlternarModoEnergia";
			colAlternarModoEnergia.Visible = true;
			colAlternarModoEnergia.VisibleIndex = 2;
			colAlternarModoEnergia.Width = 177;
			// 
			// colAtualizarUIMinimizado
			// 
			colAtualizarUIMinimizado.Caption = "Atualizar UI Min.";
			colAtualizarUIMinimizado.FieldName = "AtualizarUIMinimizado";
			colAtualizarUIMinimizado.MinWidth = 23;
			colAtualizarUIMinimizado.Name = "colAtualizarUIMinimizado";
			colAtualizarUIMinimizado.ToolTip = "Atualizar UI enquanto o programa está minimizado";
			colAtualizarUIMinimizado.Visible = true;
			colAtualizarUIMinimizado.VisibleIndex = 3;
			colAtualizarUIMinimizado.Width = 152;
			// 
			// colConfirmacoesExtraNosEditores
			// 
			colConfirmacoesExtraNosEditores.Caption = "Confirmações Extra";
			colConfirmacoesExtraNosEditores.FieldName = "ConfirmacoesExtraNosEditores";
			colConfirmacoesExtraNosEditores.MinWidth = 23;
			colConfirmacoesExtraNosEditores.Name = "colConfirmacoesExtraNosEditores";
			colConfirmacoesExtraNosEditores.ToolTip = "Mostrar confirmações extras nos editores";
			colConfirmacoesExtraNosEditores.Visible = true;
			colConfirmacoesExtraNosEditores.VisibleIndex = 4;
			colConfirmacoesExtraNosEditores.Width = 156;
			// 
			// colIniciarMinimizada
			// 
			colIniciarMinimizada.FieldName = "IniciarMinimizada";
			colIniciarMinimizada.Name = "colIniciarMinimizada";
			colIniciarMinimizada.Visible = true;
			colIniciarMinimizada.VisibleIndex = 5;
			colIniciarMinimizada.Width = 152;
			// 
			// colAlgoritmo
			// 
			colAlgoritmo.FieldName = "Algoritmo";
			colAlgoritmo.MinWidth = 23;
			colAlgoritmo.Name = "colAlgoritmo";
			colAlgoritmo.ToolTip = "Algoritmo por defeito";
			colAlgoritmo.Visible = true;
			colAlgoritmo.VisibleIndex = 6;
			colAlgoritmo.Width = 177;
			// 
			// colMedirConsumo
			// 
			colMedirConsumo.FieldName = "MedirConsumo";
			colMedirConsumo.Name = "colMedirConsumo";
			colMedirConsumo.ToolTip = "Medir consumo do(s) componente(s) a ser usado(s) na mineração";
			colMedirConsumo.Visible = true;
			colMedirConsumo.VisibleIndex = 7;
			colMedirConsumo.Width = 132;
			// 
			// colMinimizarAoFechar
			// 
			colMinimizarAoFechar.Caption = "Minimizar ao Fechar";
			colMinimizarAoFechar.FieldName = "MinimizarAoFechar";
			colMinimizarAoFechar.Name = "colMinimizarAoFechar";
			colMinimizarAoFechar.ToolTip = "Continua a executar o programa em background ao fechar";
			colMinimizarAoFechar.Visible = true;
			colMinimizarAoFechar.VisibleIndex = 8;
			colMinimizarAoFechar.Width = 157;
			// 
			// colPesoConsumo
			// 
			colPesoConsumo.FieldName = "PesoConsumo";
			colPesoConsumo.Name = "colPesoConsumo";
			colPesoConsumo.ToolTip = "Peso do consumo (Watts)";
			colPesoConsumo.Visible = true;
			colPesoConsumo.VisibleIndex = 9;
			colPesoConsumo.Width = 157;
			// 
			// colLocalizacaoLogsMineracao
			// 
			colLocalizacaoLogsMineracao.FieldName = "LocalizacaoLogsMineracao";
			colLocalizacaoLogsMineracao.MinWidth = 23;
			colLocalizacaoLogsMineracao.Name = "colLocalizacaoLogsMineracao";
			colLocalizacaoLogsMineracao.Visible = true;
			colLocalizacaoLogsMineracao.VisibleIndex = 10;
			colLocalizacaoLogsMineracao.Width = 87;
			// 
			// colAtivo
			// 
			colAtivo.Caption = "Ativa";
			colAtivo.FieldName = "Ativo";
			colAtivo.Name = "colAtivo";
			colAtivo.Visible = true;
			colAtivo.VisibleIndex = 11;
			colAtivo.Width = 167;
			// 
			// colDataCriacao
			// 
			colDataCriacao.Caption = "Data Criação";
			colDataCriacao.FieldName = "DataCriacao";
			colDataCriacao.Name = "colDataCriacao";
			// 
			// colDataAlteracao
			// 
			colDataAlteracao.Caption = "Data Alteração";
			colDataAlteracao.FieldName = "DataAlteracao";
			colDataAlteracao.Name = "colDataAlteracao";
			// 
			// ConfigsGeraisRC
			// 
			ConfigsGeraisRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 38, 35, 38);
			ConfigsGeraisRC.ExpandCollapseItem.Id = 0;
			ConfigsGeraisRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ConfigsGeraisRC.ExpandCollapseItem, AtualizarBBI, NovoBBI, EditarBBI, EliminarBBI });
			ConfigsGeraisRC.Location = new System.Drawing.Point(0, 0);
			ConfigsGeraisRC.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			ConfigsGeraisRC.MaxItemId = 5;
			ConfigsGeraisRC.Name = "ConfigsGeraisRC";
			ConfigsGeraisRC.OptionsMenuMinWidth = 385;
			ConfigsGeraisRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ConfigsGeraisRP });
			ConfigsGeraisRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
			ConfigsGeraisRC.Size = new System.Drawing.Size(1695, 177);
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
			// ConfiguracoesGeraisUserControl
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(ConfigsGeraisGC);
			Controls.Add(ConfigsGeraisRC);
			Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			Name = "ConfiguracoesGeraisUserControl";
			Size = new System.Drawing.Size(1695, 1039);
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
		private DevExpress.XtraGrid.Columns.GridColumn colLocalizacaoLogsMineracao;
	}
}
