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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineradorEditorUserControl));
            this.MineradorEditorRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.GravarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.MineradorEditorRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.MineradorDLC = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.ParametrosTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MineradorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AtivoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.DataCriacaoDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.DataAlteracaoDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.LocalizacaoButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.MineradorLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForLocalizacao = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForParametros = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDataCriacao = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAtivo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDataAlteracao = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorEditorRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorDLC)).BeginInit();
            this.MineradorDLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametrosTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtivoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocalizacaoButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorLCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLocalizacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParametros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataCriacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAtivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataAlteracao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // MineradorEditorRC
            // 
            this.MineradorEditorRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 40, 35, 40);
            this.MineradorEditorRC.ExpandCollapseItem.Id = 0;
            this.MineradorEditorRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MineradorEditorRC.ExpandCollapseItem,
            this.GravarBBI});
            this.MineradorEditorRC.Location = new System.Drawing.Point(0, 0);
            this.MineradorEditorRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MineradorEditorRC.MaxItemId = 3;
            this.MineradorEditorRC.Name = "MineradorEditorRC";
            this.MineradorEditorRC.OptionsMenuMinWidth = 385;
            this.MineradorEditorRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.MineradorEditorRP});
            this.MineradorEditorRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.MineradorEditorRC.Size = new System.Drawing.Size(1395, 186);
            // 
            // GravarBBI
            // 
            this.GravarBBI.Caption = "Gravar";
            this.GravarBBI.Id = 2;
            this.GravarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GravarBBI.ImageOptions.SvgImage")));
            this.GravarBBI.Name = "GravarBBI";
            this.GravarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.GravarBBI_ItemClick);
            // 
            // MineradorEditorRP
            // 
            this.MineradorEditorRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.OperacoesRPG});
            this.MineradorEditorRP.Name = "MineradorEditorRP";
            this.MineradorEditorRP.Text = "Editor Minerador";
            // 
            // OperacoesRPG
            // 
            this.OperacoesRPG.ItemLinks.Add(this.GravarBBI);
            this.OperacoesRPG.Name = "OperacoesRPG";
            this.OperacoesRPG.Text = "Operações";
            // 
            // MineradorDLC
            // 
            this.MineradorDLC.Controls.Add(this.ParametrosTextEdit);
            this.MineradorDLC.Controls.Add(this.AtivoCheckEdit);
            this.MineradorDLC.Controls.Add(this.DataCriacaoDateEdit);
            this.MineradorDLC.Controls.Add(this.DataAlteracaoDateEdit);
            this.MineradorDLC.Controls.Add(this.LocalizacaoButtonEdit);
            this.MineradorDLC.DataMember = null;
            this.MineradorDLC.DataSource = this.MineradorBindingSource;
            this.MineradorDLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MineradorDLC.Location = new System.Drawing.Point(0, 186);
            this.MineradorDLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MineradorDLC.MenuManager = this.MineradorEditorRC;
            this.MineradorDLC.Name = "MineradorDLC";
            this.MineradorDLC.Root = this.MineradorLCG;
            this.MineradorDLC.Size = new System.Drawing.Size(1395, 638);
            this.MineradorDLC.TabIndex = 1;
            this.MineradorDLC.Text = "dataLayoutControl1";
            // 
            // ParametrosTextEdit
            // 
            this.ParametrosTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MineradorBindingSource, "Parametros", true));
            this.ParametrosTextEdit.Location = new System.Drawing.Point(110, 42);
            this.ParametrosTextEdit.MenuManager = this.MineradorEditorRC;
            this.ParametrosTextEdit.Name = "ParametrosTextEdit";
            this.ParametrosTextEdit.Size = new System.Drawing.Size(1273, 26);
            this.ParametrosTextEdit.StyleController = this.MineradorDLC;
            this.ParametrosTextEdit.TabIndex = 6;
            // 
            // MineradorBindingSource
            // 
            this.MineradorBindingSource.DataSource = typeof(Modelos.Classes.Minerador);
            // 
            // AtivoCheckEdit
            // 
            this.AtivoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.MineradorBindingSource, "Ativo", true));
            this.AtivoCheckEdit.Location = new System.Drawing.Point(12, 72);
            this.AtivoCheckEdit.MenuManager = this.MineradorEditorRC;
            this.AtivoCheckEdit.Name = "AtivoCheckEdit";
            this.AtivoCheckEdit.Properties.Caption = "Ativo";
            this.AtivoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AtivoCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.AtivoCheckEdit.Size = new System.Drawing.Size(1371, 21);
            this.AtivoCheckEdit.StyleController = this.MineradorDLC;
            this.AtivoCheckEdit.TabIndex = 7;
            // 
            // DataCriacaoDateEdit
            // 
            this.DataCriacaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MineradorBindingSource, "DataCriacao", true));
            this.DataCriacaoDateEdit.EditValue = null;
            this.DataCriacaoDateEdit.Location = new System.Drawing.Point(110, 97);
            this.DataCriacaoDateEdit.MenuManager = this.MineradorEditorRC;
            this.DataCriacaoDateEdit.Name = "DataCriacaoDateEdit";
            this.DataCriacaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataCriacaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataCriacaoDateEdit.Properties.ReadOnly = true;
            this.DataCriacaoDateEdit.Size = new System.Drawing.Size(585, 26);
            this.DataCriacaoDateEdit.StyleController = this.MineradorDLC;
            this.DataCriacaoDateEdit.TabIndex = 8;
            // 
            // DataAlteracaoDateEdit
            // 
            this.DataAlteracaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MineradorBindingSource, "DataAlteracao", true));
            this.DataAlteracaoDateEdit.EditValue = null;
            this.DataAlteracaoDateEdit.Location = new System.Drawing.Point(797, 97);
            this.DataAlteracaoDateEdit.MenuManager = this.MineradorEditorRC;
            this.DataAlteracaoDateEdit.Name = "DataAlteracaoDateEdit";
            this.DataAlteracaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataAlteracaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataAlteracaoDateEdit.Properties.ReadOnly = true;
            this.DataAlteracaoDateEdit.Size = new System.Drawing.Size(586, 26);
            this.DataAlteracaoDateEdit.StyleController = this.MineradorDLC;
            this.DataAlteracaoDateEdit.TabIndex = 9;
            // 
            // LocalizacaoButtonEdit
            // 
            this.LocalizacaoButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MineradorBindingSource, "Localizacao", true));
            this.LocalizacaoButtonEdit.Location = new System.Drawing.Point(110, 12);
            this.LocalizacaoButtonEdit.MenuManager = this.MineradorEditorRC;
            this.LocalizacaoButtonEdit.Name = "LocalizacaoButtonEdit";
            this.LocalizacaoButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LocalizacaoButtonEdit.Size = new System.Drawing.Size(1273, 26);
            this.LocalizacaoButtonEdit.StyleController = this.MineradorDLC;
            this.LocalizacaoButtonEdit.TabIndex = 10;
            this.LocalizacaoButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LocalizacaoButtonEdit_ButtonClick);
            // 
            // MineradorLCG
            // 
            this.MineradorLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.MineradorLCG.GroupBordersVisible = false;
            this.MineradorLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.MineradorLCG.Name = "MineradorLCG";
            this.MineradorLCG.Size = new System.Drawing.Size(1395, 638);
            this.MineradorLCG.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForLocalizacao,
            this.ItemForParametros,
            this.ItemForDataCriacao,
            this.ItemForAtivo,
            this.ItemForDataAlteracao,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1375, 618);
            // 
            // ItemForLocalizacao
            // 
            this.ItemForLocalizacao.Control = this.LocalizacaoButtonEdit;
            this.ItemForLocalizacao.Location = new System.Drawing.Point(0, 0);
            this.ItemForLocalizacao.Name = "ItemForLocalizacao";
            this.ItemForLocalizacao.Size = new System.Drawing.Size(1375, 30);
            this.ItemForLocalizacao.Text = "Localização";
            this.ItemForLocalizacao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForParametros
            // 
            this.ItemForParametros.Control = this.ParametrosTextEdit;
            this.ItemForParametros.Location = new System.Drawing.Point(0, 30);
            this.ItemForParametros.Name = "ItemForParametros";
            this.ItemForParametros.Size = new System.Drawing.Size(1375, 30);
            this.ItemForParametros.Text = "Parâmetros";
            this.ItemForParametros.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForDataCriacao
            // 
            this.ItemForDataCriacao.Control = this.DataCriacaoDateEdit;
            this.ItemForDataCriacao.Location = new System.Drawing.Point(0, 85);
            this.ItemForDataCriacao.Name = "ItemForDataCriacao";
            this.ItemForDataCriacao.Size = new System.Drawing.Size(687, 30);
            this.ItemForDataCriacao.Text = "Data Criação";
            this.ItemForDataCriacao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForAtivo
            // 
            this.ItemForAtivo.Control = this.AtivoCheckEdit;
            this.ItemForAtivo.Location = new System.Drawing.Point(0, 60);
            this.ItemForAtivo.Name = "ItemForAtivo";
            this.ItemForAtivo.Size = new System.Drawing.Size(1375, 25);
            this.ItemForAtivo.Text = "Ativo";
            this.ItemForAtivo.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForAtivo.TextVisible = false;
            // 
            // ItemForDataAlteracao
            // 
            this.ItemForDataAlteracao.Control = this.DataAlteracaoDateEdit;
            this.ItemForDataAlteracao.Location = new System.Drawing.Point(687, 85);
            this.ItemForDataAlteracao.Name = "ItemForDataAlteracao";
            this.ItemForDataAlteracao.Size = new System.Drawing.Size(688, 30);
            this.ItemForDataAlteracao.Text = "Data Alteração";
            this.ItemForDataAlteracao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 115);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1375, 503);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // MineradorEditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MineradorDLC);
            this.Controls.Add(this.MineradorEditorRC);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MineradorEditorUserControl";
            this.Size = new System.Drawing.Size(1395, 824);
            ((System.ComponentModel.ISupportInitialize)(this.MineradorEditorRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorDLC)).EndInit();
            this.MineradorDLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParametrosTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtivoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocalizacaoButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorLCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLocalizacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForParametros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataCriacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAtivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataAlteracao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MineradorEditorRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage MineradorEditorRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraDataLayout.DataLayoutControl MineradorDLC;
        private DevExpress.XtraLayout.LayoutControlGroup MineradorLCG;
        private DevExpress.XtraBars.BarButtonItem GravarBBI;
        private System.Windows.Forms.BindingSource MineradorBindingSource;
        private DevExpress.XtraEditors.TextEdit ParametrosTextEdit;
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
    }
}
