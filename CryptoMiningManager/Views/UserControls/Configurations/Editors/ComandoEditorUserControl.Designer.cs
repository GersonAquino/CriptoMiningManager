namespace CryptoMiningManager.Views.UserControls.Configurations.Editors
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
            this.ActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ComamandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CreatedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.UpdatedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.PreMiningCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.AfterMiningCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.CommandMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.BaseLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ComandoLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCreatedDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForComandos = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForPreMining = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAfterMining = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUpdatedDate = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoEditorRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseDLC)).BeginInit();
            this.BaseDLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComamandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdatedDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdatedDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreMiningCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterMiningCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseLCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoLCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComandos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPreMining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAfterMining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUpdatedDate)).BeginInit();
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
            this.GravarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveBBI_ItemClick);
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
            this.BaseDLC.Controls.Add(this.ActiveCheckEdit);
            this.BaseDLC.Controls.Add(this.CreatedDateDateEdit);
            this.BaseDLC.Controls.Add(this.UpdatedDateDateEdit);
            this.BaseDLC.Controls.Add(this.PreMiningCheckEdit);
            this.BaseDLC.Controls.Add(this.AfterMiningCheckEdit);
            this.BaseDLC.Controls.Add(this.CommandMemoEdit);
            this.BaseDLC.DataMember = null;
            this.BaseDLC.DataSource = this.ComamandBindingSource;
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
            // ActiveCheckEdit
            // 
            this.ActiveCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ComamandBindingSource, "Active", true));
            this.ActiveCheckEdit.Location = new System.Drawing.Point(12, 115);
            this.ActiveCheckEdit.MenuManager = this.ComandoEditorRC;
            this.ActiveCheckEdit.Name = "ActiveCheckEdit";
            this.ActiveCheckEdit.Properties.Caption = "Active";
            this.ActiveCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.ActiveCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ActiveCheckEdit.Size = new System.Drawing.Size(1371, 21);
            this.ActiveCheckEdit.StyleController = this.BaseDLC;
            this.ActiveCheckEdit.TabIndex = 7;
            // 
            // ComandoBindingSource
            // 
            this.ComamandBindingSource.DataSource = typeof(Models.Classes.Command);
            // 
            // CreatedDateDateEdit
            // 
            this.CreatedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("DateTime", this.ComamandBindingSource, "CreatedDate", true));
            this.CreatedDateDateEdit.EditValue = null;
            this.CreatedDateDateEdit.Location = new System.Drawing.Point(110, 190);
            this.CreatedDateDateEdit.MenuManager = this.ComandoEditorRC;
            this.CreatedDateDateEdit.Name = "CreatedDateDateEdit";
            this.CreatedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatedDateDateEdit.Properties.ReadOnly = true;
            this.CreatedDateDateEdit.Size = new System.Drawing.Size(585, 26);
            this.CreatedDateDateEdit.StyleController = this.BaseDLC;
            this.CreatedDateDateEdit.TabIndex = 8;
            // 
            // UpdatedDateDateEdit
            // 
            this.UpdatedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("DateTime", this.ComamandBindingSource, "UpdatedDate", true));
            this.UpdatedDateDateEdit.EditValue = null;
            this.UpdatedDateDateEdit.Location = new System.Drawing.Point(797, 190);
            this.UpdatedDateDateEdit.MenuManager = this.ComandoEditorRC;
            this.UpdatedDateDateEdit.Name = "UpdatedDateDateEdit";
            this.UpdatedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UpdatedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UpdatedDateDateEdit.Properties.ReadOnly = true;
            this.UpdatedDateDateEdit.Size = new System.Drawing.Size(586, 26);
            this.UpdatedDateDateEdit.StyleController = this.BaseDLC;
            this.UpdatedDateDateEdit.TabIndex = 9;
            // 
            // PreMiningCheckEdit
            // 
            this.PreMiningCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ComamandBindingSource, "PreMining", true));
            this.PreMiningCheckEdit.Location = new System.Drawing.Point(12, 140);
            this.PreMiningCheckEdit.MenuManager = this.ComandoEditorRC;
            this.PreMiningCheckEdit.Name = "PreMiningCheckEdit";
            this.PreMiningCheckEdit.Properties.Caption = "Pré Mineração";
            this.PreMiningCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.PreMiningCheckEdit.Size = new System.Drawing.Size(1371, 21);
            this.PreMiningCheckEdit.StyleController = this.BaseDLC;
            this.PreMiningCheckEdit.TabIndex = 12;
            // 
            // AfterMiningCheckEdit
            // 
            this.AfterMiningCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ComamandBindingSource, "AfterMining", true));
            this.AfterMiningCheckEdit.Location = new System.Drawing.Point(12, 165);
            this.AfterMiningCheckEdit.MenuManager = this.ComandoEditorRC;
            this.AfterMiningCheckEdit.Name = "AfterMiningCheckEdit";
            this.AfterMiningCheckEdit.Properties.Caption = "Pós Mineração";
            this.AfterMiningCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AfterMiningCheckEdit.Size = new System.Drawing.Size(1371, 21);
            this.AfterMiningCheckEdit.StyleController = this.BaseDLC;
            this.AfterMiningCheckEdit.TabIndex = 13;
            // 
            // ComandosMemoEdit
            // 
            this.CommandMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ComamandBindingSource, "Comandos", true));
            this.CommandMemoEdit.Location = new System.Drawing.Point(12, 33);
            this.CommandMemoEdit.MenuManager = this.ComandoEditorRC;
            this.CommandMemoEdit.Name = "ComandosMemoEdit";
            this.CommandMemoEdit.Properties.LinesCount = 4;
            this.CommandMemoEdit.Size = new System.Drawing.Size(1371, 78);
            this.CommandMemoEdit.StyleController = this.BaseDLC;
            this.CommandMemoEdit.TabIndex = 14;
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
            this.ItemForCreatedDate,
            this.ItemForActive,
            this.ItemForComandos,
            this.emptySpaceItem1,
            this.ItemForPreMining,
            this.ItemForAfterMining,
            this.ItemForUpdatedDate});
            this.ComandoLCG.Location = new System.Drawing.Point(0, 0);
            this.ComandoLCG.Name = "ComandoLCG";
            this.ComandoLCG.Size = new System.Drawing.Size(1375, 618);
            // 
            // ItemForCreatedDate
            // 
            this.ItemForCreatedDate.Control = this.CreatedDateDateEdit;
            this.ItemForCreatedDate.Location = new System.Drawing.Point(0, 178);
            this.ItemForCreatedDate.Name = "ItemForCreatedDate";
            this.ItemForCreatedDate.Size = new System.Drawing.Size(687, 30);
            this.ItemForCreatedDate.Text = "Data Criação";
            this.ItemForCreatedDate.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForActive
            // 
            this.ItemForActive.Control = this.ActiveCheckEdit;
            this.ItemForActive.Location = new System.Drawing.Point(0, 103);
            this.ItemForActive.Name = "ItemForActive";
            this.ItemForActive.Size = new System.Drawing.Size(1375, 25);
            this.ItemForActive.Text = "Active";
            this.ItemForActive.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForActive.TextVisible = false;
            // 
            // ItemForComandos
            // 
            this.ItemForComandos.Control = this.CommandMemoEdit;
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
            // ItemForPreMining
            // 
            this.ItemForPreMining.Control = this.PreMiningCheckEdit;
            this.ItemForPreMining.Location = new System.Drawing.Point(0, 128);
            this.ItemForPreMining.Name = "ItemForPreMining";
            this.ItemForPreMining.Size = new System.Drawing.Size(1375, 25);
            this.ItemForPreMining.Text = "Pre Mineracao";
            this.ItemForPreMining.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPreMining.TextVisible = false;
            // 
            // ItemForAfterMining
            // 
            this.ItemForAfterMining.Control = this.AfterMiningCheckEdit;
            this.ItemForAfterMining.Location = new System.Drawing.Point(0, 153);
            this.ItemForAfterMining.Name = "ItemForAfterMining";
            this.ItemForAfterMining.Size = new System.Drawing.Size(1375, 25);
            this.ItemForAfterMining.Text = "Pos Mineracao";
            this.ItemForAfterMining.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForAfterMining.TextVisible = false;
            // 
            // ItemForUpdatedDate
            // 
            this.ItemForUpdatedDate.Control = this.UpdatedDateDateEdit;
            this.ItemForUpdatedDate.Location = new System.Drawing.Point(687, 178);
            this.ItemForUpdatedDate.Name = "ItemForUpdatedDate";
            this.ItemForUpdatedDate.Size = new System.Drawing.Size(688, 30);
            this.ItemForUpdatedDate.Text = "Data Alteração";
            this.ItemForUpdatedDate.TextSize = new System.Drawing.Size(86, 17);
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
            ((System.ComponentModel.ISupportInitialize)(this.ActiveCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComamandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatedDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdatedDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpdatedDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreMiningCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterMiningCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommandMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseLCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComandoLCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComandos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPreMining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAfterMining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUpdatedDate)).EndInit();
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
        private System.Windows.Forms.BindingSource ComamandBindingSource;
        private DevExpress.XtraEditors.CheckEdit ActiveCheckEdit;
        private DevExpress.XtraEditors.DateEdit CreatedDateDateEdit;
        private DevExpress.XtraEditors.DateEdit UpdatedDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup ComandoLCG;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActive;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUpdatedDate;
        private DevExpress.XtraEditors.CheckEdit PreMiningCheckEdit;
        private DevExpress.XtraEditors.CheckEdit AfterMiningCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForComandos;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAfterMining;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreMining;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.MemoEdit CommandMemoEdit;
    }
}
