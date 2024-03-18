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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineradorEditorUserControl));
            this.MineradorEditorRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.MineradorEditorRP = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.OperacoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.MineradorDLC = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.MineradorLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            this.GravarBBI = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorEditorRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorDLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorLCG)).BeginInit();
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
            this.MineradorDLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MineradorDLC.Location = new System.Drawing.Point(0, 186);
            this.MineradorDLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MineradorDLC.Name = "MineradorDLC";
            this.MineradorDLC.Root = this.MineradorLCG;
            this.MineradorDLC.Size = new System.Drawing.Size(1395, 638);
            this.MineradorDLC.TabIndex = 1;
            this.MineradorDLC.Text = "dataLayoutControl1";
            // 
            // MineradorLCG
            // 
            this.MineradorLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.MineradorLCG.GroupBordersVisible = false;
            this.MineradorLCG.Name = "MineradorLCG";
            this.MineradorLCG.Size = new System.Drawing.Size(1395, 638);
            this.MineradorLCG.TextVisible = false;
            // 
            // GravarBBI
            // 
            this.GravarBBI.Caption = "Gravar";
            this.GravarBBI.Id = 2;
            this.GravarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GravarBBI.ImageOptions.SvgImage")));
            this.GravarBBI.Name = "GravarBBI";
            this.GravarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.GravarBBI_ItemClick);
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
            ((System.ComponentModel.ISupportInitialize)(this.MineradorLCG)).EndInit();
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
    }
}
