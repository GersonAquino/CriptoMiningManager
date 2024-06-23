namespace CryptoMiningManager.Views.UserControls.Configuracoes.Editores
{
    partial class ConfiguracaoGeralEditorUserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguracaoGeralEditorUserControl));
			ConfigGeralEditorRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
			GravarBBI = new DevExpress.XtraBars.BarButtonItem();
			ConfigGeralEditorRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
			OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			BaseDLC = new DevExpress.XtraDataLayout.DataLayoutControl();
			AtivoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
			ConfigGeralBindingSource = new System.Windows.Forms.BindingSource(components);
			DataCriacaoDateEdit = new DevExpress.XtraEditors.DateEdit();
			DataAlteracaoDateEdit = new DevExpress.XtraEditors.DateEdit();
			IniciarMinimizadaCheckEdit = new DevExpress.XtraEditors.CheckEdit();
			MedirConsumoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
			MinimizarAoFecharCheckEdit = new DevExpress.XtraEditors.CheckEdit();
			BaseLCG = new DevExpress.XtraLayout.LayoutControlGroup();
			ConfigGeralLCG = new DevExpress.XtraLayout.LayoutControlGroup();
			ItemForDataCriacao = new DevExpress.XtraLayout.LayoutControlItem();
			ItemForAtivo = new DevExpress.XtraLayout.LayoutControlItem();
			emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			ItemForDataAlteracao = new DevExpress.XtraLayout.LayoutControlItem();
			ItemForIniciarMinimizada = new DevExpress.XtraLayout.LayoutControlItem();
			ItemForMedirConsumo = new DevExpress.XtraLayout.LayoutControlItem();
			ItemForPesoConsumo = new DevExpress.XtraLayout.LayoutControlItem();
			ItemForMinimizarAoFechar = new DevExpress.XtraLayout.LayoutControlItem();
			ItemForDescricao = new DevExpress.XtraLayout.LayoutControlItem();
			DescricaoMemoEdit = new DevExpress.XtraEditors.MemoEdit();
			PesoConsumoSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			((System.ComponentModel.ISupportInitialize)ConfigGeralEditorRC).BeginInit();
			((System.ComponentModel.ISupportInitialize)BaseDLC).BeginInit();
			BaseDLC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)AtivoCheckEdit.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)ConfigGeralBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties.CalendarTimeProperties).BeginInit();
			((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties.CalendarTimeProperties).BeginInit();
			((System.ComponentModel.ISupportInitialize)IniciarMinimizadaCheckEdit.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)MedirConsumoCheckEdit.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)MinimizarAoFecharCheckEdit.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)BaseLCG).BeginInit();
			((System.ComponentModel.ISupportInitialize)ConfigGeralLCG).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForDataCriacao).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForAtivo).BeginInit();
			((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForDataAlteracao).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForIniciarMinimizada).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForMedirConsumo).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForPesoConsumo).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForMinimizarAoFechar).BeginInit();
			((System.ComponentModel.ISupportInitialize)ItemForDescricao).BeginInit();
			((System.ComponentModel.ISupportInitialize)DescricaoMemoEdit.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)PesoConsumoSpinEdit.Properties).BeginInit();
			SuspendLayout();
			// 
			// ConfigGeralEditorRC
			// 
			ConfigGeralEditorRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 41, 35, 41);
			ConfigGeralEditorRC.ExpandCollapseItem.Id = 0;
			ConfigGeralEditorRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ConfigGeralEditorRC.ExpandCollapseItem, GravarBBI });
			ConfigGeralEditorRC.Location = new System.Drawing.Point(0, 0);
			ConfigGeralEditorRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ConfigGeralEditorRC.MaxItemId = 3;
			ConfigGeralEditorRC.Name = "ConfigGeralEditorRC";
			ConfigGeralEditorRC.OptionsMenuMinWidth = 385;
			ConfigGeralEditorRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ConfigGeralEditorRP });
			ConfigGeralEditorRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
			ConfigGeralEditorRC.Size = new System.Drawing.Size(1395, 186);
			// 
			// GravarBBI
			// 
			GravarBBI.Caption = "Gravar";
			GravarBBI.Id = 2;
			GravarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GravarBBI.ImageOptions.SvgImage");
			GravarBBI.Name = "GravarBBI";
			GravarBBI.ItemClick += GravarBBI_ItemClick;
			// 
			// ConfigGeralEditorRP
			// 
			ConfigGeralEditorRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { OperacoesRPG });
			ConfigGeralEditorRP.Name = "ConfigGeralEditorRP";
			ConfigGeralEditorRP.Text = "Editor Configuração Geral";
			// 
			// OperacoesRPG
			// 
			OperacoesRPG.ItemLinks.Add(GravarBBI);
			OperacoesRPG.Name = "OperacoesRPG";
			OperacoesRPG.Text = "Operações";
			// 
			// BaseDLC
			// 
			BaseDLC.Controls.Add(AtivoCheckEdit);
			BaseDLC.Controls.Add(DataCriacaoDateEdit);
			BaseDLC.Controls.Add(DataAlteracaoDateEdit);
			BaseDLC.Controls.Add(IniciarMinimizadaCheckEdit);
			BaseDLC.Controls.Add(MedirConsumoCheckEdit);
			BaseDLC.Controls.Add(MinimizarAoFecharCheckEdit);
			BaseDLC.Controls.Add(DescricaoMemoEdit);
			BaseDLC.Controls.Add(PesoConsumoSpinEdit);
			BaseDLC.DataMember = null;
			BaseDLC.DataSource = ConfigGeralBindingSource;
			BaseDLC.Dock = System.Windows.Forms.DockStyle.Fill;
			BaseDLC.Location = new System.Drawing.Point(0, 186);
			BaseDLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			BaseDLC.MenuManager = ConfigGeralEditorRC;
			BaseDLC.Name = "BaseDLC";
			BaseDLC.Root = BaseLCG;
			BaseDLC.Size = new System.Drawing.Size(1395, 638);
			BaseDLC.TabIndex = 1;
			BaseDLC.Text = "dataLayoutControl1";
			// 
			// AtivoCheckEdit
			// 
			AtivoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", ConfigGeralBindingSource, "Ativo", true));
			AtivoCheckEdit.Location = new System.Drawing.Point(12, 170);
			AtivoCheckEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			AtivoCheckEdit.MenuManager = ConfigGeralEditorRC;
			AtivoCheckEdit.Name = "AtivoCheckEdit";
			AtivoCheckEdit.Properties.Caption = "Ativa";
			AtivoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
			AtivoCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			AtivoCheckEdit.Size = new System.Drawing.Size(1371, 21);
			AtivoCheckEdit.StyleController = BaseDLC;
			AtivoCheckEdit.TabIndex = 6;
			// 
			// ConfigGeralBindingSource
			// 
			ConfigGeralBindingSource.DataSource = typeof(Modelos.Classes.ConfiguracaoGeral);
			// 
			// DataCriacaoDateEdit
			// 
			DataCriacaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("DateTime", ConfigGeralBindingSource, "DataCriacao", true));
			DataCriacaoDateEdit.EditValue = null;
			DataCriacaoDateEdit.Location = new System.Drawing.Point(111, 195);
			DataCriacaoDateEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			DataCriacaoDateEdit.MenuManager = ConfigGeralEditorRC;
			DataCriacaoDateEdit.Name = "DataCriacaoDateEdit";
			DataCriacaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			DataCriacaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			DataCriacaoDateEdit.Properties.ReadOnly = true;
			DataCriacaoDateEdit.Size = new System.Drawing.Size(584, 26);
			DataCriacaoDateEdit.StyleController = BaseDLC;
			DataCriacaoDateEdit.TabIndex = 7;
			// 
			// DataAlteracaoDateEdit
			// 
			DataAlteracaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("DateTime", ConfigGeralBindingSource, "DataAlteracao", true));
			DataAlteracaoDateEdit.EditValue = null;
			DataAlteracaoDateEdit.Location = new System.Drawing.Point(798, 195);
			DataAlteracaoDateEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			DataAlteracaoDateEdit.MenuManager = ConfigGeralEditorRC;
			DataAlteracaoDateEdit.Name = "DataAlteracaoDateEdit";
			DataAlteracaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			DataAlteracaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			DataAlteracaoDateEdit.Properties.ReadOnly = true;
			DataAlteracaoDateEdit.Size = new System.Drawing.Size(585, 26);
			DataAlteracaoDateEdit.StyleController = BaseDLC;
			DataAlteracaoDateEdit.TabIndex = 8;
			// 
			// IniciarMinimizadaCheckEdit
			// 
			IniciarMinimizadaCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", ConfigGeralBindingSource, "IniciarMinimizada", true));
			IniciarMinimizadaCheckEdit.Location = new System.Drawing.Point(12, 115);
			IniciarMinimizadaCheckEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			IniciarMinimizadaCheckEdit.MenuManager = ConfigGeralEditorRC;
			IniciarMinimizadaCheckEdit.Name = "IniciarMinimizadaCheckEdit";
			IniciarMinimizadaCheckEdit.Properties.Caption = "Iniciar Minimizada";
			IniciarMinimizadaCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
			IniciarMinimizadaCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			IniciarMinimizadaCheckEdit.Size = new System.Drawing.Size(683, 21);
			IniciarMinimizadaCheckEdit.StyleController = BaseDLC;
			IniciarMinimizadaCheckEdit.TabIndex = 3;
			// 
			// MedirConsumoCheckEdit
			// 
			MedirConsumoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", ConfigGeralBindingSource, "MedirConsumo", true));
			MedirConsumoCheckEdit.Location = new System.Drawing.Point(12, 140);
			MedirConsumoCheckEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MedirConsumoCheckEdit.MenuManager = ConfigGeralEditorRC;
			MedirConsumoCheckEdit.Name = "MedirConsumoCheckEdit";
			MedirConsumoCheckEdit.Properties.Caption = "Medir Consumo";
			MedirConsumoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
			MedirConsumoCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			MedirConsumoCheckEdit.Size = new System.Drawing.Size(683, 21);
			MedirConsumoCheckEdit.StyleController = BaseDLC;
			MedirConsumoCheckEdit.TabIndex = 4;
			// 
			// MinimizarAoFecharCheckEdit
			// 
			MinimizarAoFecharCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", ConfigGeralBindingSource, "MinimizarAoFechar", true));
			MinimizarAoFecharCheckEdit.Location = new System.Drawing.Point(699, 115);
			MinimizarAoFecharCheckEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MinimizarAoFecharCheckEdit.MenuManager = ConfigGeralEditorRC;
			MinimizarAoFecharCheckEdit.Name = "MinimizarAoFecharCheckEdit";
			MinimizarAoFecharCheckEdit.Properties.Caption = "Minimizar ao Fechar";
			MinimizarAoFecharCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
			MinimizarAoFecharCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			MinimizarAoFecharCheckEdit.Size = new System.Drawing.Size(684, 21);
			MinimizarAoFecharCheckEdit.StyleController = BaseDLC;
			MinimizarAoFecharCheckEdit.TabIndex = 2;
			// 
			// BaseLCG
			// 
			BaseLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			BaseLCG.GroupBordersVisible = false;
			BaseLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ConfigGeralLCG });
			BaseLCG.Name = "BaseLCG";
			BaseLCG.Size = new System.Drawing.Size(1395, 638);
			BaseLCG.TextVisible = false;
			// 
			// ConfigGeralLCG
			// 
			ConfigGeralLCG.AllowDrawBackground = false;
			ConfigGeralLCG.GroupBordersVisible = false;
			ConfigGeralLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForDataCriacao, ItemForAtivo, emptySpaceItem1, ItemForDataAlteracao, ItemForIniciarMinimizada, ItemForMedirConsumo, ItemForPesoConsumo, ItemForMinimizarAoFechar, ItemForDescricao });
			ConfigGeralLCG.Location = new System.Drawing.Point(0, 0);
			ConfigGeralLCG.Name = "ConfigGeralLCG";
			ConfigGeralLCG.Size = new System.Drawing.Size(1375, 618);
			// 
			// ItemForDataCriacao
			// 
			ItemForDataCriacao.Control = DataCriacaoDateEdit;
			ItemForDataCriacao.Location = new System.Drawing.Point(0, 183);
			ItemForDataCriacao.Name = "ItemForDataCriacao";
			ItemForDataCriacao.Size = new System.Drawing.Size(687, 30);
			ItemForDataCriacao.Text = "Data Criação";
			ItemForDataCriacao.TextSize = new System.Drawing.Size(87, 17);
			// 
			// ItemForAtivo
			// 
			ItemForAtivo.Control = AtivoCheckEdit;
			ItemForAtivo.Location = new System.Drawing.Point(0, 158);
			ItemForAtivo.Name = "ItemForAtivo";
			ItemForAtivo.Size = new System.Drawing.Size(1375, 25);
			ItemForAtivo.Text = "Ativo";
			ItemForAtivo.TextSize = new System.Drawing.Size(0, 0);
			ItemForAtivo.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			emptySpaceItem1.AllowHotTrack = false;
			emptySpaceItem1.Location = new System.Drawing.Point(0, 213);
			emptySpaceItem1.Name = "emptySpaceItem1";
			emptySpaceItem1.Size = new System.Drawing.Size(1375, 405);
			emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// ItemForDataAlteracao
			// 
			ItemForDataAlteracao.Control = DataAlteracaoDateEdit;
			ItemForDataAlteracao.Location = new System.Drawing.Point(687, 183);
			ItemForDataAlteracao.Name = "ItemForDataAlteracao";
			ItemForDataAlteracao.Size = new System.Drawing.Size(688, 30);
			ItemForDataAlteracao.Text = "Data Alteração";
			ItemForDataAlteracao.TextSize = new System.Drawing.Size(87, 17);
			// 
			// ItemForIniciarMinimizada
			// 
			ItemForIniciarMinimizada.Control = IniciarMinimizadaCheckEdit;
			ItemForIniciarMinimizada.Location = new System.Drawing.Point(0, 103);
			ItemForIniciarMinimizada.Name = "ItemForIniciarMinimizada";
			ItemForIniciarMinimizada.Size = new System.Drawing.Size(687, 25);
			ItemForIniciarMinimizada.Text = "Iniciar Minimizada";
			ItemForIniciarMinimizada.TextSize = new System.Drawing.Size(0, 0);
			ItemForIniciarMinimizada.TextVisible = false;
			// 
			// ItemForMedirConsumo
			// 
			ItemForMedirConsumo.Control = MedirConsumoCheckEdit;
			ItemForMedirConsumo.Location = new System.Drawing.Point(0, 128);
			ItemForMedirConsumo.Name = "ItemForMedirConsumo";
			ItemForMedirConsumo.Size = new System.Drawing.Size(687, 30);
			ItemForMedirConsumo.Text = "Medir Consumo";
			ItemForMedirConsumo.TextSize = new System.Drawing.Size(0, 0);
			ItemForMedirConsumo.TextVisible = false;
			// 
			// ItemForPesoConsumo
			// 
			ItemForPesoConsumo.Control = PesoConsumoSpinEdit;
			ItemForPesoConsumo.Location = new System.Drawing.Point(687, 128);
			ItemForPesoConsumo.Name = "ItemForPesoConsumo";
			ItemForPesoConsumo.Size = new System.Drawing.Size(688, 30);
			ItemForPesoConsumo.Text = "Peso Consumo";
			ItemForPesoConsumo.TextSize = new System.Drawing.Size(87, 17);
			// 
			// ItemForMinimizarAoFechar
			// 
			ItemForMinimizarAoFechar.Control = MinimizarAoFecharCheckEdit;
			ItemForMinimizarAoFechar.Location = new System.Drawing.Point(687, 103);
			ItemForMinimizarAoFechar.Name = "ItemForMinimizarAoFechar";
			ItemForMinimizarAoFechar.Size = new System.Drawing.Size(688, 25);
			ItemForMinimizarAoFechar.Text = "Minimizar Ao Fechar";
			ItemForMinimizarAoFechar.TextSize = new System.Drawing.Size(0, 0);
			ItemForMinimizarAoFechar.TextVisible = false;
			// 
			// ItemForDescricao
			// 
			ItemForDescricao.Control = DescricaoMemoEdit;
			ItemForDescricao.Location = new System.Drawing.Point(0, 0);
			ItemForDescricao.Name = "ItemForDescricao";
			ItemForDescricao.Size = new System.Drawing.Size(1375, 103);
			ItemForDescricao.Text = "Descrição";
			ItemForDescricao.TextLocation = DevExpress.Utils.Locations.Top;
			ItemForDescricao.TextSize = new System.Drawing.Size(87, 17);
			// 
			// DescricaoMemoEdit
			// 
			DescricaoMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", ConfigGeralBindingSource, "Descricao", true));
			DescricaoMemoEdit.Location = new System.Drawing.Point(12, 41);
			DescricaoMemoEdit.MenuManager = ConfigGeralEditorRC;
			DescricaoMemoEdit.Name = "DescricaoMemoEdit";
			DescricaoMemoEdit.Properties.MaxLength = 200;
			DescricaoMemoEdit.Size = new System.Drawing.Size(1371, 70);
			DescricaoMemoEdit.StyleController = BaseDLC;
			DescricaoMemoEdit.TabIndex = 0;
			// 
			// PesoConsumoSpinEdit
			// 
			PesoConsumoSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("Value", ConfigGeralBindingSource, "PesoConsumo", true));
			PesoConsumoSpinEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
			PesoConsumoSpinEdit.Location = new System.Drawing.Point(798, 140);
			PesoConsumoSpinEdit.MenuManager = ConfigGeralEditorRC;
			PesoConsumoSpinEdit.Name = "PesoConsumoSpinEdit";
			PesoConsumoSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
			PesoConsumoSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			PesoConsumoSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			PesoConsumoSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			PesoConsumoSpinEdit.Properties.IsFloatValue = false;
			PesoConsumoSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			PesoConsumoSpinEdit.Properties.MaskSettings.Set("mask", "N0");
			PesoConsumoSpinEdit.Properties.MaxValue = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
			PesoConsumoSpinEdit.Size = new System.Drawing.Size(585, 26);
			PesoConsumoSpinEdit.StyleController = BaseDLC;
			PesoConsumoSpinEdit.TabIndex = 5;
			// 
			// ConfiguracaoGeralEditorUserControl
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(BaseDLC);
			Controls.Add(ConfigGeralEditorRC);
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "ConfiguracaoGeralEditorUserControl";
			Size = new System.Drawing.Size(1395, 824);
			((System.ComponentModel.ISupportInitialize)ConfigGeralEditorRC).EndInit();
			((System.ComponentModel.ISupportInitialize)BaseDLC).EndInit();
			BaseDLC.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)AtivoCheckEdit.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)ConfigGeralBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties.CalendarTimeProperties).EndInit();
			((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties.CalendarTimeProperties).EndInit();
			((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)IniciarMinimizadaCheckEdit.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)MedirConsumoCheckEdit.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)MinimizarAoFecharCheckEdit.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)BaseLCG).EndInit();
			((System.ComponentModel.ISupportInitialize)ConfigGeralLCG).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForDataCriacao).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForAtivo).EndInit();
			((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForDataAlteracao).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForIniciarMinimizada).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForMedirConsumo).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForPesoConsumo).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForMinimizarAoFechar).EndInit();
			((System.ComponentModel.ISupportInitialize)ItemForDescricao).EndInit();
			((System.ComponentModel.ISupportInitialize)DescricaoMemoEdit.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)PesoConsumoSpinEdit.Properties).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ConfigGeralEditorRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ConfigGeralEditorRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraDataLayout.DataLayoutControl BaseDLC;
        private DevExpress.XtraLayout.LayoutControlGroup BaseLCG;
        private DevExpress.XtraBars.BarButtonItem GravarBBI;
        private System.Windows.Forms.BindingSource ConfigGeralBindingSource;
        private DevExpress.XtraEditors.CheckEdit AtivoCheckEdit;
        private DevExpress.XtraEditors.DateEdit DataCriacaoDateEdit;
        private DevExpress.XtraEditors.DateEdit DataAlteracaoDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup ConfigGeralLCG;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAtivo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDataCriacao;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDataAlteracao;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraEditors.CheckEdit IniciarMinimizadaCheckEdit;
		private DevExpress.XtraEditors.CheckEdit MedirConsumoCheckEdit;
		private DevExpress.XtraEditors.CheckEdit MinimizarAoFecharCheckEdit;
		private DevExpress.XtraLayout.LayoutControlItem ItemForIniciarMinimizada;
		private DevExpress.XtraLayout.LayoutControlItem ItemForMedirConsumo;
		private DevExpress.XtraLayout.LayoutControlItem ItemForPesoConsumo;
		private DevExpress.XtraLayout.LayoutControlItem ItemForMinimizarAoFechar;
		private DevExpress.XtraEditors.MemoEdit DescricaoMemoEdit;
		private DevExpress.XtraLayout.LayoutControlItem ItemForDescricao;
		private DevExpress.XtraEditors.SpinEdit PesoConsumoSpinEdit;
	}
}
