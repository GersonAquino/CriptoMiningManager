namespace CryptoMiningManager.Views.UserControls.Configurations.Editors
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
            MinerDLC = new DevExpress.XtraDataLayout.DataLayoutControl();
            ActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            MinerBindingSource = new System.Windows.Forms.BindingSource(components);
            CreatedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            UpdatedDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            LocationButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            ParametersMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            CoinSearchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            CoinBindingSource = new System.Windows.Forms.BindingSource(components);
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            colCoinIds = new DevExpress.XtraGrid.Columns.GridColumn();
            colExternalIdMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            colNameMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            MineradorLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ItemForLocation = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForParameters = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForCreatedDate = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForActive = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForUpdatedDate = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            ItemForMoeda = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)MineradorEditorRC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinerDLC).BeginInit();
            MinerDLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ActiveCheckEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CreatedDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CreatedDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpdatedDateDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpdatedDateDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LocationButtonEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NameTextEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ParametersMemoEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CoinSearchLookUpEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CoinBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradorLCG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLocation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForParameters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCreatedDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUpdatedDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemForName).BeginInit();
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
            GravarBBI.ItemClick += SaveBBI_ItemClick;
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
            MinerDLC.Controls.Add(ActiveCheckEdit);
            MinerDLC.Controls.Add(CreatedDateDateEdit);
            MinerDLC.Controls.Add(UpdatedDateDateEdit);
            MinerDLC.Controls.Add(LocationButtonEdit);
            MinerDLC.Controls.Add(NameTextEdit);
            MinerDLC.Controls.Add(ParametersMemoEdit);
            MinerDLC.Controls.Add(CoinSearchLookUpEdit);
            MinerDLC.DataMember = null;
            MinerDLC.DataSource = MinerBindingSource;
            MinerDLC.Dock = System.Windows.Forms.DockStyle.Fill;
            MinerDLC.Location = new System.Drawing.Point(0, 186);
            MinerDLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinerDLC.MenuManager = MineradorEditorRC;
            MinerDLC.Name = "MineradorDLC";
            MinerDLC.Root = MineradorLCG;
            MinerDLC.Size = new System.Drawing.Size(1395, 638);
            MinerDLC.TabIndex = 1;
            MinerDLC.Text = "dataLayoutControl1";
            // 
            // ActiveCheckEdit
            // 
            ActiveCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", MinerBindingSource, "Active", true));
            ActiveCheckEdit.Location = new System.Drawing.Point(12, 212);
            ActiveCheckEdit.MenuManager = MineradorEditorRC;
            ActiveCheckEdit.Name = "ActiveCheckEdit";
            ActiveCheckEdit.Properties.Caption = "Active";
            ActiveCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            ActiveCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            ActiveCheckEdit.Size = new System.Drawing.Size(1371, 21);
            ActiveCheckEdit.StyleController = MinerDLC;
            ActiveCheckEdit.TabIndex = 7;
            // 
            // MineradorBindingSource
            // 
            MinerBindingSource.DataSource = typeof(Models.Classes.Miner);
            // 
            // CreatedDateDateEdit
            // 
            CreatedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MinerBindingSource, "CreatedDate", true));
            CreatedDateDateEdit.EditValue = null;
            CreatedDateDateEdit.Location = new System.Drawing.Point(110, 237);
            CreatedDateDateEdit.MenuManager = MineradorEditorRC;
            CreatedDateDateEdit.Name = "CreatedDateDateEdit";
            CreatedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            CreatedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            CreatedDateDateEdit.Properties.ReadOnly = true;
            CreatedDateDateEdit.Size = new System.Drawing.Size(585, 26);
            CreatedDateDateEdit.StyleController = MinerDLC;
            CreatedDateDateEdit.TabIndex = 8;
            // 
            // UpdatedDateDateEdit
            // 
            UpdatedDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MinerBindingSource, "UpdatedDate", true));
            UpdatedDateDateEdit.EditValue = null;
            UpdatedDateDateEdit.Location = new System.Drawing.Point(797, 237);
            UpdatedDateDateEdit.MenuManager = MineradorEditorRC;
            UpdatedDateDateEdit.Name = "UpdatedDateDateEdit";
            UpdatedDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            UpdatedDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            UpdatedDateDateEdit.Properties.ReadOnly = true;
            UpdatedDateDateEdit.Size = new System.Drawing.Size(586, 26);
            UpdatedDateDateEdit.StyleController = MinerDLC;
            UpdatedDateDateEdit.TabIndex = 9;
            // 
            // LocationButtonEdit
            // 
            LocationButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MinerBindingSource, "Location", true));
            LocationButtonEdit.Location = new System.Drawing.Point(110, 42);
            LocationButtonEdit.MenuManager = MineradorEditorRC;
            LocationButtonEdit.Name = "LocationButtonEdit";
            LocationButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            LocationButtonEdit.Size = new System.Drawing.Size(1273, 26);
            LocationButtonEdit.StyleController = MinerDLC;
            LocationButtonEdit.TabIndex = 10;
            LocationButtonEdit.ButtonClick += LocationButtonEdit_ButtonClick;
            // 
            // NameTextEdit
            // 
            NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MinerBindingSource, "Name", true));
            NameTextEdit.Location = new System.Drawing.Point(110, 12);
            NameTextEdit.MenuManager = MineradorEditorRC;
            NameTextEdit.Name = "NameTextEdit";
            NameTextEdit.Size = new System.Drawing.Size(585, 26);
            NameTextEdit.StyleController = MinerDLC;
            NameTextEdit.TabIndex = 11;
            // 
            // ParametersMemoEdit
            // 
            ParametersMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MinerBindingSource, "Parameters", true));
            ParametersMemoEdit.Location = new System.Drawing.Point(12, 93);
            ParametersMemoEdit.MenuManager = MineradorEditorRC;
            ParametersMemoEdit.Name = "ParametersMemoEdit";
            ParametersMemoEdit.Size = new System.Drawing.Size(1371, 115);
            ParametersMemoEdit.StyleController = MinerDLC;
            ParametersMemoEdit.TabIndex = 12;
            // 
            // MoedaSearchLookUpEdit
            // 
            CoinSearchLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", MinerBindingSource, "Moeda", true));
            CoinSearchLookUpEdit.Location = new System.Drawing.Point(797, 12);
            CoinSearchLookUpEdit.MenuManager = MineradorEditorRC;
            CoinSearchLookUpEdit.Name = "MoedaSearchLookUpEdit";
            CoinSearchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            CoinSearchLookUpEdit.Properties.DataSource = CoinBindingSource;
            CoinSearchLookUpEdit.Properties.DisplayMember = "Name";
            CoinSearchLookUpEdit.Properties.NullText = "";
            CoinSearchLookUpEdit.Properties.PopupView = searchLookUpEdit1View;
            CoinSearchLookUpEdit.Size = new System.Drawing.Size(586, 26);
            CoinSearchLookUpEdit.StyleController = MinerDLC;
            CoinSearchLookUpEdit.TabIndex = 13;
            // 
            // MoedasBindingSource
            // 
            CoinBindingSource.DataSource = typeof(Models.Classes.Coins);
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCoinIds, colExternalIdMoedas, colNameMoedas });
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colCoinIds
            // 
            colCoinIds.FieldName = "Id";
            colCoinIds.Name = "colCoinIds";
            colCoinIds.Visible = true;
            colCoinIds.VisibleIndex = 0;
            // 
            // colExternalIdMoedas
            // 
            colExternalIdMoedas.FieldName = "ExternalId";
            colExternalIdMoedas.Name = "colExternalIdMoedas";
            colExternalIdMoedas.Visible = true;
            colExternalIdMoedas.VisibleIndex = 1;
            // 
            // colNameMoedas
            // 
            colNameMoedas.FieldName = "Name";
            colNameMoedas.Name = "colNameMoedas";
            colNameMoedas.Visible = true;
            colNameMoedas.VisibleIndex = 2;
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
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { ItemForLocation, ItemForParameters, ItemForCreatedDate, ItemForActive, ItemForUpdatedDate, emptySpaceItem1, ItemForName, ItemForMoeda });
            layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            layoutControlGroup1.Name = "autoGeneratedGroup0";
            layoutControlGroup1.Size = new System.Drawing.Size(1375, 618);
            // 
            // ItemForLocation
            // 
            ItemForLocation.Control = LocationButtonEdit;
            ItemForLocation.Location = new System.Drawing.Point(0, 30);
            ItemForLocation.Name = "ItemForLocation";
            ItemForLocation.Size = new System.Drawing.Size(1375, 30);
            ItemForLocation.Text = "Localização";
            ItemForLocation.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForParameters
            // 
            ItemForParameters.Control = ParametersMemoEdit;
            ItemForParameters.Location = new System.Drawing.Point(0, 60);
            ItemForParameters.Name = "ItemForParameters";
            ItemForParameters.Size = new System.Drawing.Size(1375, 140);
            ItemForParameters.Text = "Parâmetros";
            ItemForParameters.TextLocation = DevExpress.Utils.Locations.Top;
            ItemForParameters.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForCreatedDate
            // 
            ItemForCreatedDate.Control = CreatedDateDateEdit;
            ItemForCreatedDate.Location = new System.Drawing.Point(0, 225);
            ItemForCreatedDate.Name = "ItemForCreatedDate";
            ItemForCreatedDate.Size = new System.Drawing.Size(687, 30);
            ItemForCreatedDate.Text = "Data Criação";
            ItemForCreatedDate.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForActive
            // 
            ItemForActive.Control = ActiveCheckEdit;
            ItemForActive.Location = new System.Drawing.Point(0, 200);
            ItemForActive.Name = "ItemForActive";
            ItemForActive.Size = new System.Drawing.Size(1375, 25);
            ItemForActive.Text = "Active";
            ItemForActive.TextSize = new System.Drawing.Size(0, 0);
            ItemForActive.TextVisible = false;
            // 
            // ItemForUpdatedDate
            // 
            ItemForUpdatedDate.Control = UpdatedDateDateEdit;
            ItemForUpdatedDate.Location = new System.Drawing.Point(687, 225);
            ItemForUpdatedDate.Name = "ItemForUpdatedDate";
            ItemForUpdatedDate.Size = new System.Drawing.Size(688, 30);
            ItemForUpdatedDate.Text = "Data Alteração";
            ItemForUpdatedDate.TextSize = new System.Drawing.Size(86, 17);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 255);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(1375, 363);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForName
            // 
            ItemForName.Control = NameTextEdit;
            ItemForName.Location = new System.Drawing.Point(0, 0);
            ItemForName.Name = "ItemForName";
            ItemForName.Size = new System.Drawing.Size(687, 30);
            ItemForName.Text = "Name";
            ItemForName.TextSize = new System.Drawing.Size(86, 17);
            // 
            // ItemForMoeda
            // 
            ItemForMoeda.Control = CoinSearchLookUpEdit;
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
            Controls.Add(MinerDLC);
            Controls.Add(MineradorEditorRC);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MineradorEditorUserControl";
            Size = new System.Drawing.Size(1395, 824);
            Load += MinerEditorUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)MineradorEditorRC).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinerDLC).EndInit();
            MinerDLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ActiveCheckEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)CreatedDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CreatedDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpdatedDateDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpdatedDateDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LocationButtonEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NameTextEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ParametersMemoEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CoinSearchLookUpEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)CoinBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradorLCG).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForLocation).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForParameters).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForCreatedDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForUpdatedDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForName).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemForMoeda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MineradorEditorRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage MineradorEditorRP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoesRPG;
        private DevExpress.XtraDataLayout.DataLayoutControl MinerDLC;
        private DevExpress.XtraLayout.LayoutControlGroup MineradorLCG;
        private DevExpress.XtraBars.BarButtonItem GravarBBI;
        private System.Windows.Forms.BindingSource MinerBindingSource;
        private DevExpress.XtraEditors.CheckEdit ActiveCheckEdit;
        private DevExpress.XtraEditors.DateEdit CreatedDateDateEdit;
        private DevExpress.XtraEditors.DateEdit UpdatedDateDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLocation;
        private DevExpress.XtraLayout.LayoutControlItem ItemForParameters;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActive;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatedDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUpdatedDate;
        private DevExpress.XtraEditors.ButtonEdit LocationButtonEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraEditors.MemoEdit ParametersMemoEdit;
        private DevExpress.XtraEditors.SearchLookUpEdit CoinSearchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMoeda;
        private System.Windows.Forms.BindingSource CoinBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCoinIds;
        private DevExpress.XtraGrid.Columns.GridColumn colExternalIdMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colNameMoedas;
    }
}
