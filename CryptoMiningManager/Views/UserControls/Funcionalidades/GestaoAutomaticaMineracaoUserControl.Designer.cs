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
            components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestaoAutomaticaMineracaoUserControl));
            MoedasGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIdMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            colIdExternoMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            colNomeMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            colBtc_revenueMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
            MineradoresGC = new DevExpress.XtraGrid.GridControl();
            MineradorBindingSource = new System.Windows.Forms.BindingSource(components);
            MineradoresGV = new DevExpress.XtraGrid.Views.Grid.GridView();
            colId = new DevExpress.XtraGrid.Columns.GridColumn();
            colNome = new DevExpress.XtraGrid.Columns.GridColumn();
            colLocalizacao = new DevExpress.XtraGrid.Columns.GridColumn();
            colParametros = new DevExpress.XtraGrid.Columns.GridColumn();
            colAtivo = new DevExpress.XtraGrid.Columns.GridColumn();
            colDataCriacao = new DevExpress.XtraGrid.Columns.GridColumn();
            colDataAlteracao = new DevExpress.XtraGrid.Columns.GridColumn();
            GestaoAutomaticaMineracaoRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
            IniciarBBI = new DevExpress.XtraBars.BarButtonItem();
            PararBBI = new DevExpress.XtraBars.BarButtonItem();
            AlgoritmoBEI = new DevExpress.XtraBars.BarEditItem();
            AlgoritmoRIDG = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            IntervaloVerificacaoRentabilidadeBEI = new DevExpress.XtraBars.BarEditItem();
            IntervaloVerificacaoRentabilidadeRISE = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            OperacoresRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            OpcoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            LateralDireitaLC = new DevExpress.XtraLayout.LayoutControl();
            MineradorAtivoTE = new DevExpress.XtraEditors.TextEdit();
            UltimaVerificacaoRentabilidadeDE = new DevExpress.XtraEditors.DateEdit();
            UltimaAlteracaoMineradorDE = new DevExpress.XtraEditors.DateEdit();
            MoedaAtualTE = new DevExpress.XtraEditors.TextEdit();
            LateralDireitaLCG = new DevExpress.XtraLayout.LayoutControlGroup();
            UltimaVerificacaoRentabilidadeLCI = new DevExpress.XtraLayout.LayoutControlItem();
            UltimaAlteracaoMineradorLCI = new DevExpress.XtraLayout.LayoutControlItem();
            MoedaAtualLCI = new DevExpress.XtraLayout.LayoutControlItem();
            MineradorAtivoLCI = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)MoedasGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresGC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GestaoAutomaticaMineracaoRC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlgoritmoRIDG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IntervaloVerificacaoRentabilidadeRISE).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LateralDireitaLC).BeginInit();
            LateralDireitaLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MineradorAtivoTE.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeDE.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorDE.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedaAtualTE.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LateralDireitaLCG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeLCI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorLCI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MoedaAtualLCI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineradorAtivoLCI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // MoedasGV
            // 
            MoedasGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colIdMoedas, colIdExternoMoedas, colNomeMoedas, colBtc_revenueMoedas });
            MoedasGV.GridControl = MineradoresGC;
            MoedasGV.Name = "MoedasGV";
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
            // colBtc_revenueMoedas
            // 
            colBtc_revenueMoedas.FieldName = "Btc_revenue";
            colBtc_revenueMoedas.Name = "colBtc_revenueMoedas";
            colBtc_revenueMoedas.Visible = true;
            colBtc_revenueMoedas.VisibleIndex = 3;
            // 
            // MineradoresGC
            // 
            MineradoresGC.DataSource = MineradorBindingSource;
            MineradoresGC.Dock = System.Windows.Forms.DockStyle.Fill;
            MineradoresGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gridLevelNode1.LevelTemplate = MoedasGV;
            gridLevelNode1.RelationName = "Moedas";
            MineradoresGC.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
            MineradoresGC.Location = new System.Drawing.Point(0, 186);
            MineradoresGC.MainView = MineradoresGV;
            MineradoresGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MineradoresGC.Name = "MineradoresGC";
            MineradoresGC.Size = new System.Drawing.Size(986, 588);
            MineradoresGC.TabIndex = 4;
            MineradoresGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { MineradoresGV, MoedasGV });
            // 
            // MineradoresGV
            // 
            MineradoresGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colNome, colLocalizacao, colParametros, colAtivo, colDataCriacao, colDataAlteracao });
            MineradoresGV.GridControl = MineradoresGC;
            MineradoresGV.Name = "MineradoresGV";
            // 
            // colId
            // 
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colNome
            // 
            colNome.FieldName = "Nome";
            colNome.Name = "colNome";
            colNome.Visible = true;
            colNome.VisibleIndex = 0;
            // 
            // colLocalizacao
            // 
            colLocalizacao.Caption = "Localização";
            colLocalizacao.FieldName = "Localizacao";
            colLocalizacao.Name = "colLocalizacao";
            colLocalizacao.Visible = true;
            colLocalizacao.VisibleIndex = 1;
            // 
            // colParametros
            // 
            colParametros.Caption = "Parâmetros";
            colParametros.FieldName = "Parametros";
            colParametros.Name = "colParametros";
            colParametros.Visible = true;
            colParametros.VisibleIndex = 2;
            // 
            // colAtivo
            // 
            colAtivo.FieldName = "Ativo";
            colAtivo.Name = "colAtivo";
            // 
            // colDataCriacao
            // 
            colDataCriacao.FieldName = "DataCriacao";
            colDataCriacao.Name = "colDataCriacao";
            // 
            // colDataAlteracao
            // 
            colDataAlteracao.FieldName = "DataAlteracao";
            colDataAlteracao.Name = "colDataAlteracao";
            // 
            // GestaoAutomaticaMineracaoRC
            // 
            GestaoAutomaticaMineracaoRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 39, 35, 39);
            GestaoAutomaticaMineracaoRC.ExpandCollapseItem.Id = 0;
            GestaoAutomaticaMineracaoRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { GestaoAutomaticaMineracaoRC.ExpandCollapseItem, IniciarBBI, PararBBI, AlgoritmoBEI, IntervaloVerificacaoRentabilidadeBEI, AtualizarBBI });
            GestaoAutomaticaMineracaoRC.Location = new System.Drawing.Point(0, 0);
            GestaoAutomaticaMineracaoRC.Margin = new System.Windows.Forms.Padding(4);
            GestaoAutomaticaMineracaoRC.MaxItemId = 6;
            GestaoAutomaticaMineracaoRC.Name = "GestaoAutomaticaMineracaoRC";
            GestaoAutomaticaMineracaoRC.OptionsMenuMinWidth = 385;
            GestaoAutomaticaMineracaoRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            GestaoAutomaticaMineracaoRC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { AlgoritmoRIDG, IntervaloVerificacaoRentabilidadeRISE });
            GestaoAutomaticaMineracaoRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            GestaoAutomaticaMineracaoRC.Size = new System.Drawing.Size(1441, 186);
            // 
            // IniciarBBI
            // 
            IniciarBBI.Caption = "Iniciar";
            IniciarBBI.Id = 1;
            IniciarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("IniciarBBI.ImageOptions.SvgImage");
            IniciarBBI.Name = "IniciarBBI";
            IniciarBBI.ItemClick += IniciarBBI_ItemClick;
            // 
            // PararBBI
            // 
            PararBBI.Caption = "Parar";
            PararBBI.Id = 2;
            PararBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("PararBBI.ImageOptions.SvgImage");
            PararBBI.Name = "PararBBI";
            PararBBI.ItemClick += PararBBI_ItemClick;
            // 
            // AlgoritmoBEI
            // 
            AlgoritmoBEI.Caption = "Algoritmo";
            AlgoritmoBEI.Edit = AlgoritmoRIDG;
            AlgoritmoBEI.EditHeight = 85;
            AlgoritmoBEI.EditWidth = 140;
            AlgoritmoBEI.Id = 3;
            AlgoritmoBEI.Name = "AlgoritmoBEI";
            // 
            // AlgoritmoRIDG
            // 
            AlgoritmoRIDG.Columns = 1;
            AlgoritmoRIDG.Name = "AlgoritmoRIDG";
            // 
            // IntervaloVerificacaoRentabilidadeBEI
            // 
            IntervaloVerificacaoRentabilidadeBEI.Caption = "Verificação Rentabilidade (m)";
            IntervaloVerificacaoRentabilidadeBEI.Edit = IntervaloVerificacaoRentabilidadeRISE;
            IntervaloVerificacaoRentabilidadeBEI.EditValue = new decimal(new int[] { 10, 0, 0, 0 });
            IntervaloVerificacaoRentabilidadeBEI.Id = 4;
            IntervaloVerificacaoRentabilidadeBEI.Name = "IntervaloVerificacaoRentabilidadeBEI";
            IntervaloVerificacaoRentabilidadeBEI.EditValueChanged += IntervaloVerificacaoRentabilidadeBEI_EditValueChanged;
            // 
            // IntervaloVerificacaoRentabilidadeRISE
            // 
            IntervaloVerificacaoRentabilidadeRISE.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            IntervaloVerificacaoRentabilidadeRISE.AutoHeight = false;
            IntervaloVerificacaoRentabilidadeRISE.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            IntervaloVerificacaoRentabilidadeRISE.IsFloatValue = false;
            IntervaloVerificacaoRentabilidadeRISE.MaskSettings.Set("mask", "N00");
            IntervaloVerificacaoRentabilidadeRISE.MaxValue = new decimal(new int[] { 35791, 0, 0, 0 });
            IntervaloVerificacaoRentabilidadeRISE.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            IntervaloVerificacaoRentabilidadeRISE.Name = "IntervaloVerificacaoRentabilidadeRISE";
            // 
            // AtualizarBBI
            // 
            AtualizarBBI.Caption = "Atualizar";
            AtualizarBBI.Id = 5;
            AtualizarBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("AtualizarBBI.ImageOptions.SvgImage");
            AtualizarBBI.Name = "AtualizarBBI";
            AtualizarBBI.ItemClick += AtualizarBBI_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { OperacoresRPG, OpcoesRPG });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Gestão automática de mineração";
            // 
            // OperacoresRPG
            // 
            OperacoresRPG.ItemLinks.Add(AtualizarBBI);
            OperacoresRPG.ItemLinks.Add(IniciarBBI);
            OperacoresRPG.ItemLinks.Add(PararBBI);
            OperacoresRPG.Name = "OperacoresRPG";
            OperacoresRPG.Text = "Operações";
            // 
            // OpcoesRPG
            // 
            OpcoesRPG.ItemLinks.Add(IntervaloVerificacaoRentabilidadeBEI);
            OpcoesRPG.ItemLinks.Add(AlgoritmoBEI);
            OpcoesRPG.Name = "OpcoesRPG";
            OpcoesRPG.Text = "Opções";
            // 
            // LateralDireitaLC
            // 
            LateralDireitaLC.BackColor = System.Drawing.Color.White;
            LateralDireitaLC.Controls.Add(MineradorAtivoTE);
            LateralDireitaLC.Controls.Add(UltimaVerificacaoRentabilidadeDE);
            LateralDireitaLC.Controls.Add(UltimaAlteracaoMineradorDE);
            LateralDireitaLC.Controls.Add(MoedaAtualTE);
            LateralDireitaLC.Dock = System.Windows.Forms.DockStyle.Right;
            LateralDireitaLC.Location = new System.Drawing.Point(986, 186);
            LateralDireitaLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            LateralDireitaLC.Name = "LateralDireitaLC";
            LateralDireitaLC.Root = LateralDireitaLCG;
            LateralDireitaLC.Size = new System.Drawing.Size(455, 588);
            LateralDireitaLC.TabIndex = 1;
            LateralDireitaLC.Text = "layoutControl1";
            // 
            // MineradorAtivoTE
            // 
            MineradorAtivoTE.Location = new System.Drawing.Point(227, 102);
            MineradorAtivoTE.MenuManager = GestaoAutomaticaMineracaoRC;
            MineradorAtivoTE.Name = "MineradorAtivoTE";
            MineradorAtivoTE.Properties.ReadOnly = true;
            MineradorAtivoTE.Size = new System.Drawing.Size(216, 26);
            MineradorAtivoTE.StyleController = LateralDireitaLC;
            MineradorAtivoTE.TabIndex = 7;
            // 
            // UltimaVerificacaoRentabilidadeDE
            // 
            UltimaVerificacaoRentabilidadeDE.EditValue = null;
            UltimaVerificacaoRentabilidadeDE.Location = new System.Drawing.Point(227, 12);
            UltimaVerificacaoRentabilidadeDE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            UltimaVerificacaoRentabilidadeDE.MenuManager = GestaoAutomaticaMineracaoRC;
            UltimaVerificacaoRentabilidadeDE.Name = "UltimaVerificacaoRentabilidadeDE";
            UltimaVerificacaoRentabilidadeDE.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            UltimaVerificacaoRentabilidadeDE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            UltimaVerificacaoRentabilidadeDE.Properties.MaskSettings.Set("mask", "G");
            UltimaVerificacaoRentabilidadeDE.Properties.ReadOnly = true;
            UltimaVerificacaoRentabilidadeDE.Size = new System.Drawing.Size(216, 26);
            UltimaVerificacaoRentabilidadeDE.StyleController = LateralDireitaLC;
            UltimaVerificacaoRentabilidadeDE.TabIndex = 4;
            // 
            // UltimaAlteracaoMineradorDE
            // 
            UltimaAlteracaoMineradorDE.EditValue = null;
            UltimaAlteracaoMineradorDE.Location = new System.Drawing.Point(227, 42);
            UltimaAlteracaoMineradorDE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            UltimaAlteracaoMineradorDE.MenuManager = GestaoAutomaticaMineracaoRC;
            UltimaAlteracaoMineradorDE.Name = "UltimaAlteracaoMineradorDE";
            UltimaAlteracaoMineradorDE.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            UltimaAlteracaoMineradorDE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            UltimaAlteracaoMineradorDE.Properties.MaskSettings.Set("mask", "G");
            UltimaAlteracaoMineradorDE.Properties.ReadOnly = true;
            UltimaAlteracaoMineradorDE.Size = new System.Drawing.Size(216, 26);
            UltimaAlteracaoMineradorDE.StyleController = LateralDireitaLC;
            UltimaAlteracaoMineradorDE.TabIndex = 5;
            // 
            // MoedaAtualTE
            // 
            MoedaAtualTE.Location = new System.Drawing.Point(227, 72);
            MoedaAtualTE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MoedaAtualTE.MenuManager = GestaoAutomaticaMineracaoRC;
            MoedaAtualTE.Name = "MoedaAtualTE";
            MoedaAtualTE.Properties.ReadOnly = true;
            MoedaAtualTE.Size = new System.Drawing.Size(216, 26);
            MoedaAtualTE.StyleController = LateralDireitaLC;
            MoedaAtualTE.TabIndex = 6;
            // 
            // LateralDireitaLCG
            // 
            LateralDireitaLCG.AppearanceGroup.BackColor = System.Drawing.Color.White;
            LateralDireitaLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            LateralDireitaLCG.GroupBordersVisible = false;
            LateralDireitaLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { UltimaVerificacaoRentabilidadeLCI, UltimaAlteracaoMineradorLCI, MoedaAtualLCI, MineradorAtivoLCI, emptySpaceItem1 });
            LateralDireitaLCG.Name = "LateralDireitaLCG";
            LateralDireitaLCG.Size = new System.Drawing.Size(455, 588);
            LateralDireitaLCG.TextVisible = false;
            // 
            // UltimaVerificacaoRentabilidadeLCI
            // 
            UltimaVerificacaoRentabilidadeLCI.Control = UltimaVerificacaoRentabilidadeDE;
            UltimaVerificacaoRentabilidadeLCI.Location = new System.Drawing.Point(0, 0);
            UltimaVerificacaoRentabilidadeLCI.Name = "UltimaVerificacaoRentabilidadeLCI";
            UltimaVerificacaoRentabilidadeLCI.Size = new System.Drawing.Size(435, 30);
            UltimaVerificacaoRentabilidadeLCI.Text = "Última verificação de rentabilidade";
            UltimaVerificacaoRentabilidadeLCI.TextSize = new System.Drawing.Size(203, 17);
            // 
            // UltimaAlteracaoMineradorLCI
            // 
            UltimaAlteracaoMineradorLCI.Control = UltimaAlteracaoMineradorDE;
            UltimaAlteracaoMineradorLCI.Location = new System.Drawing.Point(0, 30);
            UltimaAlteracaoMineradorLCI.Name = "UltimaAlteracaoMineradorLCI";
            UltimaAlteracaoMineradorLCI.Size = new System.Drawing.Size(435, 30);
            UltimaAlteracaoMineradorLCI.Text = "Última alteração de minerador";
            UltimaAlteracaoMineradorLCI.TextSize = new System.Drawing.Size(203, 17);
            // 
            // MoedaAtualLCI
            // 
            MoedaAtualLCI.Control = MoedaAtualTE;
            MoedaAtualLCI.Location = new System.Drawing.Point(0, 60);
            MoedaAtualLCI.Name = "MoedaAtualLCI";
            MoedaAtualLCI.Size = new System.Drawing.Size(435, 30);
            MoedaAtualLCI.Text = "Moeda atual";
            MoedaAtualLCI.TextSize = new System.Drawing.Size(203, 17);
            // 
            // MineradorAtivoLCI
            // 
            MineradorAtivoLCI.Control = MineradorAtivoTE;
            MineradorAtivoLCI.Location = new System.Drawing.Point(0, 90);
            MineradorAtivoLCI.Name = "MineradorAtivoLCI";
            MineradorAtivoLCI.Size = new System.Drawing.Size(435, 30);
            MineradorAtivoLCI.Text = "Minerador ativo";
            MineradorAtivoLCI.TextSize = new System.Drawing.Size(203, 17);
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 120);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(435, 448);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "Parâmetros";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            gridColumn2.FieldName = "Parâmetros";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // GestaoAutomaticaMineracaoUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(MineradoresGC);
            Controls.Add(LateralDireitaLC);
            Controls.Add(GestaoAutomaticaMineracaoRC);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "GestaoAutomaticaMineracaoUserControl";
            Size = new System.Drawing.Size(1441, 774);
            Load += GestaoAutomaticaMineracaoUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)MoedasGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresGC).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradoresGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)GestaoAutomaticaMineracaoRC).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlgoritmoRIDG).EndInit();
            ((System.ComponentModel.ISupportInitialize)IntervaloVerificacaoRentabilidadeRISE).EndInit();
            ((System.ComponentModel.ISupportInitialize)LateralDireitaLC).EndInit();
            LateralDireitaLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MineradorAtivoTE.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeDE.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeDE.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorDE.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorDE.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoedaAtualTE.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)LateralDireitaLCG).EndInit();
            ((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeLCI).EndInit();
            ((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorLCI).EndInit();
            ((System.ComponentModel.ISupportInitialize)MoedaAtualLCI).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineradorAtivoLCI).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DevExpress.XtraEditors.TextEdit MineradorAtivoTE;
        private DevExpress.XtraLayout.LayoutControlItem MineradorAtivoLCI;
    }
}
