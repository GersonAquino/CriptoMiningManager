namespace CryptoMiningManager.Views.UserControls.Configuracoes.Editores
{
    partial class ComandoEditorUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComandoEditorUserControl));
            this.ComandoEditorRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.GravarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.ComandoEditorRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BaseDLC = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.AtivoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ComandoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataCriacaoDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.DataAlteracaoDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.PreMineracaoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.PosMineracaoCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ComandosMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.BaseLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ComandoLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDataCriacao = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAtivo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForComandos = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForPreMineracao = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPosMineracao = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDataAlteracao = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoEditorRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseDLC)).BeginInit();
            this.BaseDLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AtivoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreMineracaoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosMineracaoCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseLCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoLCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataCriacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAtivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComandos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPreMineracao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPosMineracao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataAlteracao)).BeginInit();
            this.SuspendLayout();
            // 
            // ComandoEditorRC
            // 
            this.ComandoEditorRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 40, 35, 40);
            this.ComandoEditorRC.ExpandCollapseItem.Id = 0;
            this.ComandoEditorRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ComandoEditorRC.ExpandCollapseItem,
            this.GravarBBI});
            this.ComandoEditorRC.Location = new System.Drawing.Point(0, 0);
            this.ComandoEditorRC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ComandoEditorRC.MaxItemId = 3;
            this.ComandoEditorRC.Name = "ComandoEditorRC";
            this.ComandoEditorRC.OptionsMenuMinWidth = 385;
            this.ComandoEditorRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ComandoEditorRP});
            this.ComandoEditorRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ComandoEditorRC.Size = new System.Drawing.Size(1395, 186);
            // 
            // GravarBBI
            // 
            this.GravarBBI.Caption = "Gravar";
            this.GravarBBI.Id = 2;
            this.GravarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GravarBBI.ImageOptions.SvgImage")));
            this.GravarBBI.Name = "GravarBBI";
            this.GravarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.GravarBBI_ItemClick);
            // 
            // ComandoEditorRP
            // 
            this.ComandoEditorRP.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.OperacoesRPG});
            this.ComandoEditorRP.Name = "ComandoEditorRP";
            this.ComandoEditorRP.Text = "Editor Comando";
            // 
            // OperacoesRPG
            // 
            this.OperacoesRPG.ItemLinks.Add(this.GravarBBI);
            this.OperacoesRPG.Name = "OperacoesRPG";
            this.OperacoesRPG.Text = "Operações";
            // 
            // BaseDLC
            // 
            this.BaseDLC.Controls.Add(this.AtivoCheckEdit);
            this.BaseDLC.Controls.Add(this.DataCriacaoDateEdit);
            this.BaseDLC.Controls.Add(this.DataAlteracaoDateEdit);
            this.BaseDLC.Controls.Add(this.PreMineracaoCheckEdit);
            this.BaseDLC.Controls.Add(this.PosMineracaoCheckEdit);
            this.BaseDLC.Controls.Add(this.ComandosMemoEdit);
            this.BaseDLC.DataMember = null;
            this.BaseDLC.DataSource = this.ComandoBindingSource;
            this.BaseDLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseDLC.Location = new System.Drawing.Point(0, 186);
            this.BaseDLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BaseDLC.MenuManager = this.ComandoEditorRC;
            this.BaseDLC.Name = "BaseDLC";
            this.BaseDLC.Root = this.BaseLCG;
            this.BaseDLC.Size = new System.Drawing.Size(1395, 638);
            this.BaseDLC.TabIndex = 1;
            this.BaseDLC.Text = "dataLayoutControl1";
            // 
            // AtivoCheckEdit
            // 
            this.AtivoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ComandoBindingSource, "Ativo", true));
            this.AtivoCheckEdit.Location = new System.Drawing.Point(12, 115);
            this.AtivoCheckEdit.MenuManager = this.ComandoEditorRC;
            this.AtivoCheckEdit.Name = "AtivoCheckEdit";
            this.AtivoCheckEdit.Properties.Caption = "Ativo";
            this.AtivoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AtivoCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.AtivoCheckEdit.Size = new System.Drawing.Size(1371, 21);
            this.AtivoCheckEdit.StyleController = this.BaseDLC;
            this.AtivoCheckEdit.TabIndex = 7;
            // 
            // ComandoBindingSource
            // 
            this.ComandoBindingSource.DataSource = typeof(Models.Classes.Command);
            // 
            // DataCriacaoDateEdit
            // 
            this.DataCriacaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("DateTime", this.ComandoBindingSource, "DataCriacao", true));
            this.DataCriacaoDateEdit.EditValue = null;
            this.DataCriacaoDateEdit.Location = new System.Drawing.Point(110, 190);
            this.DataCriacaoDateEdit.MenuManager = this.ComandoEditorRC;
            this.DataCriacaoDateEdit.Name = "DataCriacaoDateEdit";
            this.DataCriacaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataCriacaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataCriacaoDateEdit.Properties.ReadOnly = true;
            this.DataCriacaoDateEdit.Size = new System.Drawing.Size(585, 26);
            this.DataCriacaoDateEdit.StyleController = this.BaseDLC;
            this.DataCriacaoDateEdit.TabIndex = 8;
            // 
            // DataAlteracaoDateEdit
            // 
            this.DataAlteracaoDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("DateTime", this.ComandoBindingSource, "DataAlteracao", true));
            this.DataAlteracaoDateEdit.EditValue = null;
            this.DataAlteracaoDateEdit.Location = new System.Drawing.Point(797, 190);
            this.DataAlteracaoDateEdit.MenuManager = this.ComandoEditorRC;
            this.DataAlteracaoDateEdit.Name = "DataAlteracaoDateEdit";
            this.DataAlteracaoDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataAlteracaoDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DataAlteracaoDateEdit.Properties.ReadOnly = true;
            this.DataAlteracaoDateEdit.Size = new System.Drawing.Size(586, 26);
            this.DataAlteracaoDateEdit.StyleController = this.BaseDLC;
            this.DataAlteracaoDateEdit.TabIndex = 9;
            // 
            // PreMineracaoCheckEdit
            // 
            this.PreMineracaoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ComandoBindingSource, "PreMineracao", true));
            this.PreMineracaoCheckEdit.Location = new System.Drawing.Point(12, 140);
            this.PreMineracaoCheckEdit.MenuManager = this.ComandoEditorRC;
            this.PreMineracaoCheckEdit.Name = "PreMineracaoCheckEdit";
            this.PreMineracaoCheckEdit.Properties.Caption = "Pré Mineração";
            this.PreMineracaoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.PreMineracaoCheckEdit.Size = new System.Drawing.Size(1371, 21);
            this.PreMineracaoCheckEdit.StyleController = this.BaseDLC;
            this.PreMineracaoCheckEdit.TabIndex = 12;
            // 
            // PosMineracaoCheckEdit
            // 
            this.PosMineracaoCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ComandoBindingSource, "PosMineracao", true));
            this.PosMineracaoCheckEdit.Location = new System.Drawing.Point(12, 165);
            this.PosMineracaoCheckEdit.MenuManager = this.ComandoEditorRC;
            this.PosMineracaoCheckEdit.Name = "PosMineracaoCheckEdit";
            this.PosMineracaoCheckEdit.Properties.Caption = "Pós Mineração";
            this.PosMineracaoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.PosMineracaoCheckEdit.Size = new System.Drawing.Size(1371, 21);
            this.PosMineracaoCheckEdit.StyleController = this.BaseDLC;
            this.PosMineracaoCheckEdit.TabIndex = 13;
            // 
            // ComandosMemoEdit
            // 
            this.ComandosMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ComandoBindingSource, "Comandos", true));
            this.ComandosMemoEdit.Location = new System.Drawing.Point(12, 33);
            this.ComandosMemoEdit.MenuManager = this.ComandoEditorRC;
            this.ComandosMemoEdit.Name = "ComandosMemoEdit";
            this.ComandosMemoEdit.Properties.LinesCount = 4;
            this.ComandosMemoEdit.Size = new System.Drawing.Size(1371, 78);
            this.ComandosMemoEdit.StyleController = this.BaseDLC;
            this.ComandosMemoEdit.TabIndex = 14;
            // 
            // BaseLCG
            // 
            this.BaseLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.BaseLCG.GroupBordersVisible = false;
            this.BaseLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ComandoLCG});
            this.BaseLCG.Name = "BaseLCG";
            this.BaseLCG.Size = new System.Drawing.Size(1395, 638);
            this.BaseLCG.TextVisible = false;
            // 
            // ComandoLCG
            // 
            this.ComandoLCG.AllowDrawBackground = false;
            this.ComandoLCG.GroupBordersVisible = false;
            this.ComandoLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDataCriacao,
            this.ItemForAtivo,
            this.ItemForComandos,
            this.emptySpaceItem1,
            this.ItemForPreMineracao,
            this.ItemForPosMineracao,
            this.ItemForDataAlteracao});
            this.ComandoLCG.Location = new System.Drawing.Point(0, 0);
            this.ComandoLCG.Name = "ComandoLCG";
            this.ComandoLCG.Size = new System.Drawing.Size(1375, 618);
            // 
            // ItemForDataCriacao
            // 
            this.ItemForDataCriacao.Control = this.DataCriacaoDateEdit;
            this.ItemForDataCriacao.Location = new System.Drawing.Point(0, 178);
            this.ItemForDataCriacao.Name = "ItemForDataCriacao";
            this.ItemForDataCriacao.Size = new System.Drawing.Size(687, 30);
            this.ItemForDataCriacao.Text = "Data Criação";
            this.ItemForDataCriacao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForAtivo
            // 
            this.ItemForAtivo.Control = this.AtivoCheckEdit;
            this.ItemForAtivo.Location = new System.Drawing.Point(0, 103);
            this.ItemForAtivo.Name = "ItemForAtivo";
            this.ItemForAtivo.Size = new System.Drawing.Size(1375, 25);
            this.ItemForAtivo.Text = "Ativo";
            this.ItemForAtivo.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForAtivo.TextVisible = false;
            // 
            // ItemForComandos
            // 
            this.ItemForComandos.Control = this.ComandosMemoEdit;
            this.ItemForComandos.Location = new System.Drawing.Point(0, 0);
            this.ItemForComandos.Name = "ItemForComandos";
            this.ItemForComandos.Size = new System.Drawing.Size(1375, 103);
            this.ItemForComandos.Text = "Comandos";
            this.ItemForComandos.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForComandos.TextSize = new System.Drawing.Size(86, 17);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 208);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1375, 410);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForPreMineracao
            // 
            this.ItemForPreMineracao.Control = this.PreMineracaoCheckEdit;
            this.ItemForPreMineracao.Location = new System.Drawing.Point(0, 128);
            this.ItemForPreMineracao.Name = "ItemForPreMineracao";
            this.ItemForPreMineracao.Size = new System.Drawing.Size(1375, 25);
            this.ItemForPreMineracao.Text = "Pre Mineracao";
            this.ItemForPreMineracao.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPreMineracao.TextVisible = false;
            // 
            // ItemForPosMineracao
            // 
            this.ItemForPosMineracao.Control = this.PosMineracaoCheckEdit;
            this.ItemForPosMineracao.Location = new System.Drawing.Point(0, 153);
            this.ItemForPosMineracao.Name = "ItemForPosMineracao";
            this.ItemForPosMineracao.Size = new System.Drawing.Size(1375, 25);
            this.ItemForPosMineracao.Text = "Pos Mineracao";
            this.ItemForPosMineracao.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPosMineracao.TextVisible = false;
            // 
            // ItemForDataAlteracao
            // 
            this.ItemForDataAlteracao.Control = this.DataAlteracaoDateEdit;
            this.ItemForDataAlteracao.Location = new System.Drawing.Point(687, 178);
            this.ItemForDataAlteracao.Name = "ItemForDataAlteracao";
            this.ItemForDataAlteracao.Size = new System.Drawing.Size(688, 30);
            this.ItemForDataAlteracao.Text = "Data Alteração";
            this.ItemForDataAlteracao.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ComandoEditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BaseDLC);
            this.Controls.Add(this.ComandoEditorRC);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ComandoEditorUserControl";
            this.Size = new System.Drawing.Size(1395, 824);
            ((System.ComponentModel.ISupportInitialize)(this.ComandoEditorRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseDLC)).EndInit();
            this.BaseDLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AtivoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataCriacaoDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataAlteracaoDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreMineracaoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosMineracaoCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandosMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseLCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoLCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataCriacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAtivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComandos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPreMineracao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPosMineracao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataAlteracao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ComandoEditorRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ComandoEditorRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraDataLayout.DataLayoutControl BaseDLC;
        private DevExpress.XtraLayout.LayoutControlGroup BaseLCG;
        private DevExpress.XtraBars.BarButtonItem GravarBBI;
        private System.Windows.Forms.BindingSource ComandoBindingSource;
        private DevExpress.XtraEditors.CheckEdit AtivoCheckEdit;
        private DevExpress.XtraEditors.DateEdit DataCriacaoDateEdit;
        private DevExpress.XtraEditors.DateEdit DataAlteracaoDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup ComandoLCG;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAtivo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDataCriacao;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDataAlteracao;
        private DevExpress.XtraEditors.CheckEdit PreMineracaoCheckEdit;
        private DevExpress.XtraEditors.CheckEdit PosMineracaoCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForComandos;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPosMineracao;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreMineracao;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.MemoEdit ComandosMemoEdit;
    }
}
