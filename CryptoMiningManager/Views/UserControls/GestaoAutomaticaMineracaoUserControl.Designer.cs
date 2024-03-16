namespace CryptoMiningManager.Views.UserControls
{
    partial class GestaoAutomaticaMineracaoUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestaoAutomaticaMineracaoUserControl));
            this.GestaoAutomaticaMineracaoRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.OperacoresRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.IniciarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.PararBBI = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.GestaoAutomaticaMineracaoRC)).BeginInit();
            this.SuspendLayout();
            // 
            // GestaoAutomaticaMineracaoRC
            // 
            this.GestaoAutomaticaMineracaoRC.ExpandCollapseItem.Id = 0;
            this.GestaoAutomaticaMineracaoRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.GestaoAutomaticaMineracaoRC.ExpandCollapseItem,
            this.IniciarBBI,
            this.PararBBI});
            this.GestaoAutomaticaMineracaoRC.Location = new System.Drawing.Point(0, 0);
            this.GestaoAutomaticaMineracaoRC.MaxItemId = 3;
            this.GestaoAutomaticaMineracaoRC.Name = "GestaoAutomaticaMineracaoRC";
            this.GestaoAutomaticaMineracaoRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.GestaoAutomaticaMineracaoRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.GestaoAutomaticaMineracaoRC.Size = new System.Drawing.Size(1117, 173);
            // 
            // OperacoresRPG
            // 
            this.OperacoresRPG.ItemLinks.Add(this.IniciarBBI);
            this.OperacoresRPG.ItemLinks.Add(this.PararBBI);
            this.OperacoresRPG.Name = "OperacoresRPG";
            this.OperacoresRPG.Text = "Operações";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.OperacoresRPG});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Gestão automática de mineração";
            // 
            // IniciarBBI
            // 
            this.IniciarBBI.Caption = "Iniciar";
            this.IniciarBBI.Id = 1;
            this.IniciarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("IniciarBBI.ImageOptions.SvgImage")));
            this.IniciarBBI.Name = "IniciarBBI";
            this.IniciarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.IniciarBBI_ItemClick);
            // 
            // PararBBI
            // 
            this.PararBBI.Caption = "Parar";
            this.PararBBI.Id = 2;
            this.PararBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("PararBBI.ImageOptions.SvgImage")));
            this.PararBBI.Name = "PararBBI";
            // 
            // GestaoAutomaticaMineracaoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GestaoAutomaticaMineracaoRC);
            this.Name = "GestaoAutomaticaMineracaoUserControl";
            this.Size = new System.Drawing.Size(1117, 594);
            ((System.ComponentModel.ISupportInitialize)(this.GestaoAutomaticaMineracaoRC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl GestaoAutomaticaMineracaoRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoresRPG;
        private DevExpress.XtraBars.BarButtonItem IniciarBBI;
        private DevExpress.XtraBars.BarButtonItem PararBBI;
    }
}
