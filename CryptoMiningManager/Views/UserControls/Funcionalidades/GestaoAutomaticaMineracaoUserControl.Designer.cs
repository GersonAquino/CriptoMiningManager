namespace CryptoMiningManager.Views.UserControls.Funcionalidades
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestaoAutomaticaMineracaoUserControl));
            this.MoedasGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdExternoMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBtc_revenueMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MineradoresGC = new DevExpress.XtraGrid.GridControl();
            this.MineradorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MineradoresGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalizacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParametros = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAtivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataCriacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataAlteracao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GestaoAutomaticaMineracaoRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.IniciarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.PararBBI = new DevExpress.XtraBars.BarButtonItem();
            this.AlgoritmoBEI = new DevExpress.XtraBars.BarEditItem();
            this.AlgoritmoRIDG = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.IntervaloVerificacaoRentabilidadeBEI = new DevExpress.XtraBars.BarEditItem();
            this.IntervaloVerificacaoRentabilidadeRISE = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.OperacoresRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.OpcoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.LateralDireitaLC = new DevExpress.XtraLayout.LayoutControl();
            this.UltimaVerificacaoRentabilidadeDE = new DevExpress.XtraEditors.DateEdit();
            this.UltimaAlteracaoMineradorDE = new DevExpress.XtraEditors.DateEdit();
            this.MoedaAtualTE = new DevExpress.XtraEditors.TextEdit();
            this.LateralDireitaLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            this.UltimaVerificacaoRentabilidadeLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.UltimaAlteracaoMineradorLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.MoedaAtualLCI = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GestaoAutomaticaMineracaoRC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlgoritmoRIDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervaloVerificacaoRentabilidadeRISE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LateralDireitaLC)).BeginInit();
            this.LateralDireitaLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaVerificacaoRentabilidadeDE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaAlteracaoMineradorDE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedaAtualTE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LateralDireitaLCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaVerificacaoRentabilidadeLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaAlteracaoMineradorLCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedaAtualLCI)).BeginInit();
            this.SuspendLayout();
            // 
            // MoedasGV
            // 
            this.MoedasGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdMoedas,
            this.colIdExternoMoedas,
            this.colNomeMoedas,
            this.colBtc_revenueMoedas});
            this.MoedasGV.GridControl = this.MineradoresGC;
            this.MoedasGV.Name = "MoedasGV";
            // 
            // colIdMoedas
            // 
            this.colIdMoedas.FieldName = "Id";
            this.colIdMoedas.Name = "colIdMoedas";
            this.colIdMoedas.Visible = true;
            this.colIdMoedas.VisibleIndex = 0;
            // 
            // colIdExternoMoedas
            // 
            this.colIdExternoMoedas.FieldName = "IdExterno";
            this.colIdExternoMoedas.Name = "colIdExternoMoedas";
            this.colIdExternoMoedas.Visible = true;
            this.colIdExternoMoedas.VisibleIndex = 1;
            // 
            // colNomeMoedas
            // 
            this.colNomeMoedas.FieldName = "Nome";
            this.colNomeMoedas.Name = "colNomeMoedas";
            this.colNomeMoedas.Visible = true;
            this.colNomeMoedas.VisibleIndex = 2;
            // 
            // colBtc_revenueMoedas
            // 
            this.colBtc_revenueMoedas.FieldName = "Btc_revenue";
            this.colBtc_revenueMoedas.Name = "colBtc_revenueMoedas";
            this.colBtc_revenueMoedas.Visible = true;
            this.colBtc_revenueMoedas.VisibleIndex = 3;
            // 
            // MineradoresGC
            // 
            this.MineradoresGC.DataSource = this.MineradorBindingSource;
            this.MineradoresGC.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.MoedasGV;
            gridLevelNode1.RelationName = "Moedas";
            this.MineradoresGC.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.MineradoresGC.Location = new System.Drawing.Point(0, 186);
            this.MineradoresGC.MainView = this.MineradoresGV;
            this.MineradoresGC.Name = "MineradoresGC";
            this.MineradoresGC.Size = new System.Drawing.Size(986, 588);
            this.MineradoresGC.TabIndex = 4;
            this.MineradoresGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MineradoresGV,
            this.MoedasGV});
            // 
            // MineradorBindingSource
            // 
            this.MineradorBindingSource.DataSource = typeof(Modelos.Classes.Minerador);
            // 
            // MineradoresGV
            // 
            this.MineradoresGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNome,
            this.colLocalizacao,
            this.colParametros,
            this.colAtivo,
            this.colDataCriacao,
            this.colDataAlteracao});
            this.MineradoresGV.GridControl = this.MineradoresGC;
            this.MineradoresGV.Name = "MineradoresGV";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colNome
            // 
            this.colNome.FieldName = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.Visible = true;
            this.colNome.VisibleIndex = 0;
            // 
            // colLocalizacao
            // 
            this.colLocalizacao.Caption = "Localização";
            this.colLocalizacao.FieldName = "Localizacao";
            this.colLocalizacao.Name = "colLocalizacao";
            this.colLocalizacao.Visible = true;
            this.colLocalizacao.VisibleIndex = 1;
            // 
            // colParametros
            // 
            this.colParametros.Caption = "Parâmetros";
            this.colParametros.FieldName = "Parametros";
            this.colParametros.Name = "colParametros";
            this.colParametros.Visible = true;
            this.colParametros.VisibleIndex = 2;
            // 
            // colAtivo
            // 
            this.colAtivo.FieldName = "Ativo";
            this.colAtivo.Name = "colAtivo";
            // 
            // colDataCriacao
            // 
            this.colDataCriacao.FieldName = "DataCriacao";
            this.colDataCriacao.Name = "colDataCriacao";
            // 
            // colDataAlteracao
            // 
            this.colDataAlteracao.FieldName = "DataAlteracao";
            this.colDataAlteracao.Name = "colDataAlteracao";
            // 
            // GestaoAutomaticaMineracaoRC
            // 
            this.GestaoAutomaticaMineracaoRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 39, 35, 39);
            this.GestaoAutomaticaMineracaoRC.ExpandCollapseItem.Id = 0;
            this.GestaoAutomaticaMineracaoRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.GestaoAutomaticaMineracaoRC.ExpandCollapseItem,
            this.IniciarBBI,
            this.PararBBI,
            this.AlgoritmoBEI,
            this.IntervaloVerificacaoRentabilidadeBEI,
            this.AtualizarBBI});
            this.GestaoAutomaticaMineracaoRC.Location = new System.Drawing.Point(0, 0);
            this.GestaoAutomaticaMineracaoRC.Margin = new System.Windows.Forms.Padding(4);
            this.GestaoAutomaticaMineracaoRC.MaxItemId = 6;
            this.GestaoAutomaticaMineracaoRC.Name = "GestaoAutomaticaMineracaoRC";
            this.GestaoAutomaticaMineracaoRC.OptionsMenuMinWidth = 385;
            this.GestaoAutomaticaMineracaoRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.GestaoAutomaticaMineracaoRC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.AlgoritmoRIDG,
            this.IntervaloVerificacaoRentabilidadeRISE});
            this.GestaoAutomaticaMineracaoRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.GestaoAutomaticaMineracaoRC.Size = new System.Drawing.Size(1441, 186);
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
            this.PararBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PararBBI_ItemClick);
            // 
            // AlgoritmoBEI
            // 
            this.AlgoritmoBEI.Caption = "Algoritmo";
            this.AlgoritmoBEI.Edit = this.AlgoritmoRIDG;
            this.AlgoritmoBEI.EditHeight = 85;
            this.AlgoritmoBEI.EditWidth = 140;
            this.AlgoritmoBEI.Id = 3;
            this.AlgoritmoBEI.Name = "AlgoritmoBEI";
            // 
            // AlgoritmoRIDG
            // 
            this.AlgoritmoRIDG.Columns = 1;
            this.AlgoritmoRIDG.Name = "AlgoritmoRIDG";
            // 
            // IntervaloVerificacaoRentabilidadeBEI
            // 
            this.IntervaloVerificacaoRentabilidadeBEI.Caption = "Verificação Rentabilidade (m)";
            this.IntervaloVerificacaoRentabilidadeBEI.Edit = this.IntervaloVerificacaoRentabilidadeRISE;
            this.IntervaloVerificacaoRentabilidadeBEI.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.IntervaloVerificacaoRentabilidadeBEI.Id = 4;
            this.IntervaloVerificacaoRentabilidadeBEI.Name = "IntervaloVerificacaoRentabilidadeBEI";
            this.IntervaloVerificacaoRentabilidadeBEI.EditValueChanged += new System.EventHandler(this.IntervaloVerificacaoRentabilidadeBEI_EditValueChanged);
            // 
            // IntervaloVerificacaoRentabilidadeRISE
            // 
            this.IntervaloVerificacaoRentabilidadeRISE.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.IntervaloVerificacaoRentabilidadeRISE.AutoHeight = false;
            this.IntervaloVerificacaoRentabilidadeRISE.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IntervaloVerificacaoRentabilidadeRISE.IsFloatValue = false;
            this.IntervaloVerificacaoRentabilidadeRISE.MaskSettings.Set("mask", "N00");
            this.IntervaloVerificacaoRentabilidadeRISE.MaxValue = new decimal(new int[] {
            35791,
            0,
            0,
            0});
            this.IntervaloVerificacaoRentabilidadeRISE.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IntervaloVerificacaoRentabilidadeRISE.Name = "IntervaloVerificacaoRentabilidadeRISE";
            // 
            // AtualizarBBI
            // 
            this.AtualizarBBI.Caption = "Atualizar";
            this.AtualizarBBI.Id = 5;
            this.AtualizarBBI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("AtualizarBBI.ImageOptions.SvgImage")));
            this.AtualizarBBI.Name = "AtualizarBBI";
            this.AtualizarBBI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AtualizarBBI_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.OperacoresRPG,
            this.OpcoesRPG});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Gestão automática de mineração";
            // 
            // OperacoresRPG
            // 
            this.OperacoresRPG.ItemLinks.Add(this.AtualizarBBI);
            this.OperacoresRPG.ItemLinks.Add(this.IniciarBBI);
            this.OperacoresRPG.ItemLinks.Add(this.PararBBI);
            this.OperacoresRPG.Name = "OperacoresRPG";
            this.OperacoresRPG.Text = "Operações";
            // 
            // OpcoesRPG
            // 
            this.OpcoesRPG.ItemLinks.Add(this.IntervaloVerificacaoRentabilidadeBEI);
            this.OpcoesRPG.ItemLinks.Add(this.AlgoritmoBEI);
            this.OpcoesRPG.Name = "OpcoesRPG";
            this.OpcoesRPG.Text = "Opções";
            // 
            // LateralDireitaLC
            // 
            this.LateralDireitaLC.Controls.Add(this.UltimaVerificacaoRentabilidadeDE);
            this.LateralDireitaLC.Controls.Add(this.UltimaAlteracaoMineradorDE);
            this.LateralDireitaLC.Controls.Add(this.MoedaAtualTE);
            this.LateralDireitaLC.Dock = System.Windows.Forms.DockStyle.Right;
            this.LateralDireitaLC.Location = new System.Drawing.Point(986, 186);
            this.LateralDireitaLC.Name = "LateralDireitaLC";
            this.LateralDireitaLC.Root = this.LateralDireitaLCG;
            this.LateralDireitaLC.Size = new System.Drawing.Size(455, 588);
            this.LateralDireitaLC.TabIndex = 1;
            this.LateralDireitaLC.Text = "layoutControl1";
            // 
            // UltimaVerificacaoRentabilidadeDE
            // 
            this.UltimaVerificacaoRentabilidadeDE.EditValue = null;
            this.UltimaVerificacaoRentabilidadeDE.Location = new System.Drawing.Point(227, 12);
            this.UltimaVerificacaoRentabilidadeDE.MenuManager = this.GestaoAutomaticaMineracaoRC;
            this.UltimaVerificacaoRentabilidadeDE.Name = "UltimaVerificacaoRentabilidadeDE";
            this.UltimaVerificacaoRentabilidadeDE.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.UltimaVerificacaoRentabilidadeDE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UltimaVerificacaoRentabilidadeDE.Properties.MaskSettings.Set("mask", "G");
            this.UltimaVerificacaoRentabilidadeDE.Properties.ReadOnly = true;
            this.UltimaVerificacaoRentabilidadeDE.Size = new System.Drawing.Size(216, 26);
            this.UltimaVerificacaoRentabilidadeDE.StyleController = this.LateralDireitaLC;
            this.UltimaVerificacaoRentabilidadeDE.TabIndex = 4;
            // 
            // UltimaAlteracaoMineradorDE
            // 
            this.UltimaAlteracaoMineradorDE.EditValue = null;
            this.UltimaAlteracaoMineradorDE.Location = new System.Drawing.Point(227, 42);
            this.UltimaAlteracaoMineradorDE.MenuManager = this.GestaoAutomaticaMineracaoRC;
            this.UltimaAlteracaoMineradorDE.Name = "UltimaAlteracaoMineradorDE";
            this.UltimaAlteracaoMineradorDE.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.UltimaAlteracaoMineradorDE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UltimaAlteracaoMineradorDE.Properties.MaskSettings.Set("mask", "G");
            this.UltimaAlteracaoMineradorDE.Properties.ReadOnly = true;
            this.UltimaAlteracaoMineradorDE.Size = new System.Drawing.Size(216, 26);
            this.UltimaAlteracaoMineradorDE.StyleController = this.LateralDireitaLC;
            this.UltimaAlteracaoMineradorDE.TabIndex = 5;
            // 
            // MoedaAtualTE
            // 
            this.MoedaAtualTE.Location = new System.Drawing.Point(227, 72);
            this.MoedaAtualTE.MenuManager = this.GestaoAutomaticaMineracaoRC;
            this.MoedaAtualTE.Name = "MoedaAtualTE";
            this.MoedaAtualTE.Properties.ReadOnly = true;
            this.MoedaAtualTE.Size = new System.Drawing.Size(216, 26);
            this.MoedaAtualTE.StyleController = this.LateralDireitaLC;
            this.MoedaAtualTE.TabIndex = 6;
            // 
            // LateralDireitaLCG
            // 
            this.LateralDireitaLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LateralDireitaLCG.GroupBordersVisible = false;
            this.LateralDireitaLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.UltimaVerificacaoRentabilidadeLCI,
            this.UltimaAlteracaoMineradorLCI,
            this.emptySpaceItem1,
            this.MoedaAtualLCI});
            this.LateralDireitaLCG.Name = "LateralDireitaLCG";
            this.LateralDireitaLCG.Size = new System.Drawing.Size(455, 588);
            this.LateralDireitaLCG.TextVisible = false;
            // 
            // UltimaVerificacaoRentabilidadeLCI
            // 
            this.UltimaVerificacaoRentabilidadeLCI.Control = this.UltimaVerificacaoRentabilidadeDE;
            this.UltimaVerificacaoRentabilidadeLCI.Location = new System.Drawing.Point(0, 0);
            this.UltimaVerificacaoRentabilidadeLCI.Name = "UltimaVerificacaoRentabilidadeLCI";
            this.UltimaVerificacaoRentabilidadeLCI.Size = new System.Drawing.Size(435, 30);
            this.UltimaVerificacaoRentabilidadeLCI.Text = "Última verificação de rentabilidade";
            this.UltimaVerificacaoRentabilidadeLCI.TextSize = new System.Drawing.Size(203, 17);
            // 
            // UltimaAlteracaoMineradorLCI
            // 
            this.UltimaAlteracaoMineradorLCI.Control = this.UltimaAlteracaoMineradorDE;
            this.UltimaAlteracaoMineradorLCI.Location = new System.Drawing.Point(0, 30);
            this.UltimaAlteracaoMineradorLCI.Name = "UltimaAlteracaoMineradorLCI";
            this.UltimaAlteracaoMineradorLCI.Size = new System.Drawing.Size(435, 30);
            this.UltimaAlteracaoMineradorLCI.Text = "Última alteração de minerador";
            this.UltimaAlteracaoMineradorLCI.TextSize = new System.Drawing.Size(203, 17);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 90);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(435, 478);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // MoedaAtualLCI
            // 
            this.MoedaAtualLCI.Control = this.MoedaAtualTE;
            this.MoedaAtualLCI.Location = new System.Drawing.Point(0, 60);
            this.MoedaAtualLCI.Name = "MoedaAtualLCI";
            this.MoedaAtualLCI.Size = new System.Drawing.Size(435, 30);
            this.MoedaAtualLCI.Text = "Moeda atual";
            this.MoedaAtualLCI.TextSize = new System.Drawing.Size(203, 17);
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Parâmetros";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Parâmetros";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // GestaoAutomaticaMineracaoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MineradoresGC);
            this.Controls.Add(this.LateralDireitaLC);
            this.Controls.Add(this.GestaoAutomaticaMineracaoRC);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GestaoAutomaticaMineracaoUserControl";
            this.Size = new System.Drawing.Size(1441, 774);
            this.Load += new System.EventHandler(this.GestaoAutomaticaMineracaoUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MoedasGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineradoresGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GestaoAutomaticaMineracaoRC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlgoritmoRIDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervaloVerificacaoRentabilidadeRISE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LateralDireitaLC)).EndInit();
            this.LateralDireitaLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaVerificacaoRentabilidadeDE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaAlteracaoMineradorDE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedaAtualTE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LateralDireitaLCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaVerificacaoRentabilidadeLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaAlteracaoMineradorLCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoedaAtualLCI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl GestaoAutomaticaMineracaoRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoresRPG;
        private DevExpress.XtraBars.BarButtonItem IniciarBBI;
        private DevExpress.XtraBars.BarButtonItem PararBBI;
        private DevExpress.XtraLayout.LayoutControl LateralDireitaLC;
        private DevExpress.XtraLayout.LayoutControlGroup LateralDireitaLCG;
        private DevExpress.XtraBars.BarEditItem AlgoritmoBEI;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup AlgoritmoRIDG;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OpcoesRPG;
        private DevExpress.XtraBars.BarEditItem IntervaloVerificacaoRentabilidadeBEI;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit IntervaloVerificacaoRentabilidadeRISE;
        private DevExpress.XtraEditors.DateEdit UltimaVerificacaoRentabilidadeDE;
        private DevExpress.XtraLayout.LayoutControlItem UltimaVerificacaoRentabilidadeLCI;
        private DevExpress.XtraEditors.DateEdit UltimaAlteracaoMineradorDE;
        private DevExpress.XtraLayout.LayoutControlItem UltimaAlteracaoMineradorLCI;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit MoedaAtualTE;
        private DevExpress.XtraLayout.LayoutControlItem MoedaAtualLCI;
        private DevExpress.XtraGrid.GridControl MineradoresGC;
        private DevExpress.XtraGrid.Views.Grid.GridView MineradoresGV;
        private System.Windows.Forms.BindingSource MineradorBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalizacao;
        private DevExpress.XtraGrid.Columns.GridColumn colParametros;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAtivo;
        private DevExpress.XtraGrid.Columns.GridColumn colDataCriacao;
        private DevExpress.XtraGrid.Columns.GridColumn colDataAlteracao;
        private DevExpress.XtraGrid.Columns.GridColumn colNome;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private DevExpress.XtraGrid.Views.Grid.GridView MoedasGV;
        private DevExpress.XtraGrid.Columns.GridColumn colIdMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colIdExternoMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colBtc_revenueMoedas;
    }
}
