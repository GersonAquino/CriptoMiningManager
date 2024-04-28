namespace CryptoMiningManager.Views.UserControls.Configuracoes.Editores
{
    partial class MineradorEditorUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineradorEditorUserControl));
            MineradorEditorRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            GravarBBI = new DevExpress.XtraBars.BarButtonItem();
            MineradorEditorRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            MineradorDLC = new DevExpress.XtraDataLayout.DataLayoutControl();
            AtivoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            MineradorBindingSource = new System.Windows.Forms.BindingSource(components);
            DataCriacaoDateEdit = new DevExpress.XtraEditors.DateEdit();
            DataAlteracaoDateEdit = new DevExpress.XtraEditors.DateEdit();
            LocalizacaoButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            NomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            ParametrosMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            MoedaSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            MoedasBindingSource = new System.Windows.Forms.BindingSource(components);
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdExternoMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            colNomeMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            MineradorLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForLocalizacao = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForParametros = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDataCriacao = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForAtivo = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForDataAlteracao = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ItemForNome = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForMoeda = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)MineradorEditorRC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradorDLC).BeginInit();
            MineradorDLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AtivoCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LocalizacaoButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NomeTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ParametrosMemoEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedaSearchLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedasBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradorLCG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLocalizacao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForParametros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDataCriacao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForAtivo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDataAlteracao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForMoeda).BeginInit();
            SuspendLayout();
            // 
            // MineradorEditorRC
            // 
            MineradorEditorRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 40, 35, 40);
            MineradorEditorRC.ExpandCollapseItem.Id = 0;
            MineradorEditorRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MineradorEditorRC.ExpandCollapseItem, GravarBBI });
            MineradorEditorRC.Location = new System.Drawing.Point(0, 0);
            MineradorEditorRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MineradorEditorRC.MaxItemId = 3;
            MineradorEditorRC.Name = "MineradorEditorRC";
            MineradorEditorRC.OptionsMenuMinWidth = 385;
            MineradorEditorRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { MineradorEditorRP });
            MineradorEditorRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            MineradorEditorRC.Size = new System.Drawing.Size(1395, 186);
            // 
            // GravarBBI
            // 
            GravarBBI.Caption = "Gravar";
            GravarBBI.Id = 2;
            GravarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GravarBBI.ImageOptions.SvgImage");
            GravarBBI.Name = "GravarBBI";
            GravarBBI.ItemClick += GravarBBI_ItemClick;
            // 
            // MineradorEditorRP
            // 
            MineradorEditorRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { OperacoesRPG });
            MineradorEditorRP.Name = "MineradorEditorRP";
            MineradorEditorRP.Text = "Editor Minerador";
            // 
            // OperacoesRPG
            // 
            OperacoesRPG.ItemLinks.Add(GravarBBI);
            OperacoesRPG.Name = "OperacoesRPG";
            OperacoesRPG.Text = "Operações";
            // 
            // MineradorDLC
            // 
            MineradorDLC.Controls.Add(AtivoCheckEdit);
            MineradorDLC.Controls.Add(DataCriacaoDateEdit);
            MineradorDLC.Controls.Add(DataAlteracaoDateEdit);
            MineradorDLC.Controls.Add(LocalizacaoButtonEdit);
            MineradorDLC.Controls.Add(NomeTextEdit);
            MineradorDLC.Controls.Add(ParametrosMemoEdit);
            MineradorDLC.Controls.Add(MoedaSearchLookUpEdit);
            MineradorDLC.DataMember = null;
            MineradorDLC.DataSource = MineradorBindingSource;
            MineradorDLC.Dock = System.Windows.Forms.DockStyle.Fill;
            MineradorDLC.Location = new System.Drawing.Point(0, 186);
            MineradorDLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MineradorDLC.MenuManager = MineradorEditorRC;
            MineradorDLC.Name = "MineradorDLC";
            MineradorDLC.Root = MineradorLCG;
            MineradorDLC.Size = new System.Drawing.Size(1395, 638);
            MineradorDLC.TabIndex = 1;
            MineradorDLC.Text = "dataLayoutControl1";
            // 
            // AtivoCheckEdit
            // 
            AtivoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", MineradorBindingSource, "Ativo", true));
            AtivoCheckEdit.Location = new System.Drawing.Point(12, 212);
            AtivoCheckEdit.MenuManager = MineradorEditorRC;
            AtivoCheckEdit.Name = "AtivoCheckEdit";
            AtivoCheckEdit.Properties.Caption = "Ativo";
            AtivoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            AtivoCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            AtivoCheckEdit.Size = new System.Drawing.Size(1371, 21);
            AtivoCheckEdit.StyleController = MineradorDLC;
            AtivoCheckEdit.TabIndex = 7;
            // 
            // MineradorBindingSource
            // 
            MineradorBindingSource.DataSource = typeof(Modelos.Classes.Minerador);
            // 
            // DataCriacaoDateEdit
            // 
            DataCriacaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MineradorBindingSource, "DataCriacao", true));
            DataCriacaoDateEdit.EditValue = null;
            DataCriacaoDateEdit.Location = new System.Drawing.Point(110, 237);
            DataCriacaoDateEdit.MenuManager = MineradorEditorRC;
            DataCriacaoDateEdit.Name = "DataCriacaoDateEdit";
            DataCriacaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DataCriacaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DataCriacaoDateEdit.Properties.ReadOnly = true;
            DataCriacaoDateEdit.Size = new System.Drawing.Size(585, 26);
            DataCriacaoDateEdit.StyleController = MineradorDLC;
            DataCriacaoDateEdit.TabIndex = 8;
            // 
            // DataAlteracaoDateEdit
            // 
            DataAlteracaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MineradorBindingSource, "DataAlteracao", true));
            DataAlteracaoDateEdit.EditValue = null;
            DataAlteracaoDateEdit.Location = new System.Drawing.Point(797, 237);
            DataAlteracaoDateEdit.MenuManager = MineradorEditorRC;
            DataAlteracaoDateEdit.Name = "DataAlteracaoDateEdit";
            DataAlteracaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DataAlteracaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            DataAlteracaoDateEdit.Properties.ReadOnly = true;
            DataAlteracaoDateEdit.Size = new System.Drawing.Size(586, 26);
            DataAlteracaoDateEdit.StyleController = MineradorDLC;
            DataAlteracaoDateEdit.TabIndex = 9;
            // 
            // LocalizacaoButtonEdit
            // 
            LocalizacaoButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MineradorBindingSource, "Localizacao", true));
            LocalizacaoButtonEdit.Location = new System.Drawing.Point(110, 42);
            LocalizacaoButtonEdit.MenuManager = MineradorEditorRC;
            LocalizacaoButtonEdit.Name = "LocalizacaoButtonEdit";
            LocalizacaoButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            LocalizacaoButtonEdit.Size = new System.Drawing.Size(1273, 26);
            LocalizacaoButtonEdit.StyleController = MineradorDLC;
            LocalizacaoButtonEdit.TabIndex = 10;
            LocalizacaoButtonEdit.ButtonClick += LocalizacaoButtonEdit_ButtonClick;
            // 
            // NomeTextEdit
            // 
            NomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MineradorBindingSource, "Nome", true));
            NomeTextEdit.Location = new System.Drawing.Point(110, 12);
            NomeTextEdit.MenuManager = MineradorEditorRC;
            NomeTextEdit.Name = "NomeTextEdit";
            NomeTextEdit.Size = new System.Drawing.Size(585, 26);
            NomeTextEdit.StyleController = MineradorDLC;
            NomeTextEdit.TabIndex = 11;
            // 
            // ParametrosMemoEdit
            // 
            ParametrosMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MineradorBindingSource, "Parametros", true));
            ParametrosMemoEdit.Location = new System.Drawing.Point(12, 93);
            ParametrosMemoEdit.MenuManager = MineradorEditorRC;
            ParametrosMemoEdit.Name = "ParametrosMemoEdit";
            ParametrosMemoEdit.Size = new System.Drawing.Size(1371, 115);
            ParametrosMemoEdit.StyleController = MineradorDLC;
            ParametrosMemoEdit.TabIndex = 12;
            // 
            // MoedaSearchLookUpEdit
            // 
            MoedaSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MineradorBindingSource, "Moeda", true));
            MoedaSearchLookUpEdit.Location = new System.Drawing.Point(797, 12);
            MoedaSearchLookUpEdit.MenuManager = MineradorEditorRC;
            MoedaSearchLookUpEdit.Name = "MoedaSearchLookUpEdit";
            MoedaSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            MoedaSearchLookUpEdit.Properties.DataSource = MoedasBindingSource;
            MoedaSearchLookUpEdit.Properties.DisplayMember = "Nome";
            MoedaSearchLookUpEdit.Properties.NullText = "";
            MoedaSearchLookUpEdit.Properties.PopupView = searchLookUpEdit1View;
            MoedaSearchLookUpEdit.Size = new System.Drawing.Size(586, 26);
            MoedaSearchLookUpEdit.StyleController = MineradorDLC;
            MoedaSearchLookUpEdit.TabIndex = 13;
            // 
            // MoedasBindingSource
            // 
            MoedasBindingSource.DataSource = typeof(Modelos.Classes.Moeda);
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdMoedas, colIdExternoMoedas, colNomeMoedas });
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colIdMoedas
            // 
            colIdMoedas.FieldName = "Id";
            colIdMoedas.Name = "colIdMoedas";
            colIdMoedas.Visible = true;
            colIdMoedas.VisibleIndex = 0;
            // 
            // colIdExternoMoedas
            // 
            colIdExternoMoedas.FieldName = "IdExterno";
            colIdExternoMoedas.Name = "colIdExternoMoedas";
            colIdExternoMoedas.Visible = true;
            colIdExternoMoedas.VisibleIndex = 1;
            // 
            // colNomeMoedas
            // 
            colNomeMoedas.FieldName = "Nome";
            colNomeMoedas.Name = "colNomeMoedas";
            colNomeMoedas.Visible = true;
            colNomeMoedas.VisibleIndex = 2;
            // 
            // MineradorLCG
            // 
            MineradorLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            MineradorLCG.GroupBordersVisible = false;
            MineradorLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            MineradorLCG.Name = "MineradorLCG";
            MineradorLCG.Size = new System.Drawing.Size(1395, 638);
            MineradorLCG.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.AllowDrawBackground = false;
            layoutControlGroup1.GroupBordersVisible = false;
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForLocalizacao, ItemForParametros, ItemForDataCriacao, ItemForAtivo, ItemForDataAlteracao, emptySpaceItem1, ItemForNome, ItemForMoeda });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(1375, 618);
            // 
            // ItemForLocalizacao
            // 
            ItemForLocalizacao.Control = LocalizacaoButtonEdit;
            ItemForLocalizacao.Location = new System.Drawing.Point(0, 30);
            ItemForLocalizacao.Name = "ItemForLocalizacao";
            ItemForLocalizacao.Size = new System.Drawing.Size(1375, 30);
            ItemForLocalizacao.Text = "Localização";
            ItemForLocalizacao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForParametros
            // 
            ItemForParametros.Control = ParametrosMemoEdit;
            ItemForParametros.Location = new System.Drawing.Point(0, 60);
            ItemForParametros.Name = "ItemForParametros";
            ItemForParametros.Size = new System.Drawing.Size(1375, 140);
            ItemForParametros.Text = "Parâmetros";
            ItemForParametros.TextLocation = DevExpress.Utils.Locations.Top;
            ItemForParametros.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForDataCriacao
            // 
            ItemForDataCriacao.Control = DataCriacaoDateEdit;
            ItemForDataCriacao.Location = new System.Drawing.Point(0, 225);
            ItemForDataCriacao.Name = "ItemForDataCriacao";
            ItemForDataCriacao.Size = new System.Drawing.Size(687, 30);
            ItemForDataCriacao.Text = "Data Criação";
            ItemForDataCriacao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForAtivo
            // 
            ItemForAtivo.Control = AtivoCheckEdit;
            ItemForAtivo.Location = new System.Drawing.Point(0, 200);
            ItemForAtivo.Name = "ItemForAtivo";
            ItemForAtivo.Size = new System.Drawing.Size(1375, 25);
            ItemForAtivo.Text = "Ativo";
            ItemForAtivo.TextSize = new System.Drawing.Size(0, 0);
            ItemForAtivo.TextVisible = false;
            // 
            // ItemForDataAlteracao
            // 
            ItemForDataAlteracao.Control = DataAlteracaoDateEdit;
            ItemForDataAlteracao.Location = new System.Drawing.Point(687, 225);
            ItemForDataAlteracao.Name = "ItemForDataAlteracao";
            ItemForDataAlteracao.Size = new System.Drawing.Size(688, 30);
            ItemForDataAlteracao.Text = "Data Alteração";
            ItemForDataAlteracao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 255);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(1375, 363);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForNome
            // 
            ItemForNome.Control = NomeTextEdit;
            ItemForNome.Location = new System.Drawing.Point(0, 0);
            ItemForNome.Name = "ItemForNome";
            ItemForNome.Size = new System.Drawing.Size(687, 30);
            ItemForNome.Text = "Nome";
            ItemForNome.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForMoeda
            // 
            ItemForMoeda.Control = MoedaSearchLookUpEdit;
            ItemForMoeda.Location = new System.Drawing.Point(687, 0);
            ItemForMoeda.Name = "ItemForMoeda";
            ItemForMoeda.Size = new System.Drawing.Size(688, 30);
            ItemForMoeda.Text = "Moeda";
            ItemForMoeda.TextSize = new System.Drawing.Size(86, 17);
            // 
            // MineradorEditorUserControl
            // 
            Appearance.BackColor = System.Drawing.Color.White;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(MineradorDLC);
            Controls.Add(MineradorEditorRC);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MineradorEditorUserControl";
            Size = new System.Drawing.Size(1395, 824);
            Load += MineradorEditorUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)MineradorEditorRC).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradorDLC).EndInit();
            MineradorDLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AtivoCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataCriacaoDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataAlteracaoDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LocalizacaoButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NomeTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ParametrosMemoEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoedaSearchLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoedasBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradorLCG).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLocalizacao).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForParametros).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDataCriacao).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForAtivo).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForDataAlteracao).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForNome).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForMoeda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MineradorEditorRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage MineradorEditorRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraDataLayout.DataLayoutControl MineradorDLC;
        private DevExpress.XtraLayout.LayoutControlGroup MineradorLCG;
        private DevExpress.XtraBars.BarButtonItem GravarBBI;
        private System.Windows.Forms.BindingSource MineradorBindingSource;
        private DevExpress.XtraEditors.CheckEdit AtivoCheckEdit;
        private DevExpress.XtraEditors.DateEdit DataCriacaoDateEdit;
        private DevExpress.XtraEditors.DateEdit DataAlteracaoDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLocalizacao;
        private DevExpress.XtraLayout.LayoutControlItem ItemForParametros;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAtivo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDataCriacao;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDataAlteracao;
        private DevExpress.XtraEditors.ButtonEdit LocalizacaoButtonEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit NomeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNome;
        private DevExpress.XtraEditors.MemoEdit ParametrosMemoEdit;
        private DevExpress.XtraEditors.SearchLookUpEdit MoedaSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMoeda;
        private System.Windows.Forms.BindingSource MoedasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colIdExternoMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeMoedas;
    }
}
