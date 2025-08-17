using DataManager.Helpers;
using Models.Enums;
using System;

namespace CryptoMiningManager.Views.UserControls.Main
{
    partial class AutomaticMiningManagerUserControl
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
            //try
            //{
            //    PararTudo(true).GetAwaiter().GetResult();
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
            //}

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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomaticMiningManagerUserControl));
			MoedasGV = new DevExpress.XtraGrid.Views.Grid.GridView();
			colCoinIds = new DevExpress.XtraGrid.Columns.GridColumn();
			colExternalIdMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
			colNameMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
			colBtc_revenueMoedas = new DevExpress.XtraGrid.Columns.GridColumn();
			MinersGC = new DevExpress.XtraGrid.GridControl();
			MinersBindingSource = new System.Windows.Forms.BindingSource(components);
			MinersGV = new DevExpress.XtraGrid.Views.Grid.GridView();
			colId = new DevExpress.XtraGrid.Columns.GridColumn();
			colName = new DevExpress.XtraGrid.Columns.GridColumn();
			colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
			colParameters = new DevExpress.XtraGrid.Columns.GridColumn();
			colActive = new DevExpress.XtraGrid.Columns.GridColumn();
			colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
			colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
			GestaoAutomaticaMineracaoRC = new DevExpress.XtraBars.Ribbon.RibbonControl();
			StartBBI = new DevExpress.XtraBars.BarButtonItem();
			StopBBI = new DevExpress.XtraBars.BarButtonItem();
			AlgorithmBEI = new DevExpress.XtraBars.BarEditItem();
			AlgorithmRIDG = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
			ProfitabilityCheckIntervalBEI = new DevExpress.XtraBars.BarEditItem();
			IntervaloVerificacaoRentabilidadeRISE = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			AtualizarBBI = new DevExpress.XtraBars.BarButtonItem();
			TimerBEI = new DevExpress.XtraBars.BarEditItem();
			TemporizadorRITE = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			rpBase = new DevExpress.XtraBars.Ribbon.RibbonPage();
			OperacoresRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			OpcoesRPG = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			LateralDireitaLC = new DevExpress.XtraLayout.LayoutControl();
			ActiveMinerTE = new DevExpress.XtraEditors.TextEdit();
			LastProfitabilityCheckDE = new DevExpress.XtraEditors.DateEdit();
			LastMinerChangeDE = new DevExpress.XtraEditors.DateEdit();
			CurrentCoinTE = new DevExpress.XtraEditors.TextEdit();
			MostProfitableCoinTE = new DevExpress.XtraEditors.TextEdit();
			LateralDireitaLCG = new DevExpress.XtraLayout.LayoutControlGroup();
			UltimaVerificacaoRentabilidadeLCI = new DevExpress.XtraLayout.LayoutControlItem();
			UltimaAlteracaoMineradorLCI = new DevExpress.XtraLayout.LayoutControlItem();
			MineradorActiveLCI = new DevExpress.XtraLayout.LayoutControlItem();
			emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			MoedaMaisRentavelLCI = new DevExpress.XtraLayout.LayoutControlItem();
			MoedaAtualLCI = new DevExpress.XtraLayout.LayoutControlItem();
			gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			RootLC = new DevExpress.XtraLayout.LayoutControl();
			ExecutionME = new DevExpress.XtraEditors.MemoEdit();
			RootLCG = new DevExpress.XtraLayout.LayoutControlGroup();
			MineradoresLCI = new DevExpress.XtraLayout.LayoutControlItem();
			ExecucaoLCI = new DevExpress.XtraLayout.LayoutControlItem();
			Timer = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)MoedasGV).BeginInit();
			((System.ComponentModel.ISupportInitialize)MinersGC).BeginInit();
			((System.ComponentModel.ISupportInitialize)MinersBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)MinersGV).BeginInit();
			((System.ComponentModel.ISupportInitialize)GestaoAutomaticaMineracaoRC).BeginInit();
			((System.ComponentModel.ISupportInitialize)AlgorithmRIDG).BeginInit();
			((System.ComponentModel.ISupportInitialize)IntervaloVerificacaoRentabilidadeRISE).BeginInit();
			((System.ComponentModel.ISupportInitialize)TemporizadorRITE).BeginInit();
			((System.ComponentModel.ISupportInitialize)LateralDireitaLC).BeginInit();
			LateralDireitaLC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ActiveMinerTE.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)LastProfitabilityCheckDE.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)LastProfitabilityCheckDE.Properties.CalendarTimeProperties).BeginInit();
			((System.ComponentModel.ISupportInitialize)LastMinerChangeDE.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)LastMinerChangeDE.Properties.CalendarTimeProperties).BeginInit();
			((System.ComponentModel.ISupportInitialize)CurrentCoinTE.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)MostProfitableCoinTE.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)LateralDireitaLCG).BeginInit();
			((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeLCI).BeginInit();
			((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorLCI).BeginInit();
			((System.ComponentModel.ISupportInitialize)MineradorActiveLCI).BeginInit();
			((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
			((System.ComponentModel.ISupportInitialize)MoedaMaisRentavelLCI).BeginInit();
			((System.ComponentModel.ISupportInitialize)MoedaAtualLCI).BeginInit();
			((System.ComponentModel.ISupportInitialize)RootLC).BeginInit();
			RootLC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ExecutionME.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)RootLCG).BeginInit();
			((System.ComponentModel.ISupportInitialize)MineradoresLCI).BeginInit();
			((System.ComponentModel.ISupportInitialize)ExecucaoLCI).BeginInit();
			SuspendLayout();
			// 
			// MoedasGV
			// 
			MoedasGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colCoinIds, colExternalIdMoedas, colNameMoedas, colBtc_revenueMoedas });
			MoedasGV.GridControl = MinersGC;
			MoedasGV.Name = "MoedasGV";
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
			// colBtc_revenueMoedas
			// 
			colBtc_revenueMoedas.FieldName = "Btc_revenue";
			colBtc_revenueMoedas.Name = "colBtc_revenueMoedas";
			colBtc_revenueMoedas.Visible = true;
			colBtc_revenueMoedas.VisibleIndex = 3;
			// 
			// MineradoresGC
			// 
			MinersGC.DataSource = MinersBindingSource;
			MinersGC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			gridLevelNode2.LevelTemplate = MoedasGV;
			gridLevelNode2.RelationName = "Moedas";
			MinersGC.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode2 });
			MinersGC.Location = new System.Drawing.Point(12, 12);
			MinersGC.MainView = MinersGV;
			MinersGC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MinersGC.Name = "MineradoresGC";
			MinersGC.Size = new System.Drawing.Size(962, 307);
			MinersGC.TabIndex = 4;
			MinersGC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { MinersGV, MoedasGV });
			// 
			// MineradoresBindingSource
			// 
			MinersBindingSource.DataSource = typeof(Models.Classes.Miner);
			// 
			// MineradoresGV
			// 
			MinersGV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colName, colLocation, colParameters, colActive, colCreatedDate, colUpdatedDate });
			MinersGV.GridControl = MinersGC;
			MinersGV.Name = "MineradoresGV";
			// 
			// colId
			// 
			colId.FieldName = "Id";
			colId.Name = "colId";
			// 
			// colName
			// 
			colName.FieldName = "Name";
			colName.Name = "colName";
			colName.Visible = true;
			colName.VisibleIndex = 0;
			// 
			// colLocation
			// 
			colLocation.Caption = "Localização";
			colLocation.FieldName = "Location";
			colLocation.Name = "colLocation";
			colLocation.Visible = true;
			colLocation.VisibleIndex = 1;
			// 
			// colParameters
			// 
			colParameters.Caption = "Parâmetros";
			colParameters.FieldName = "Parameters";
			colParameters.Name = "colParameters";
			colParameters.Visible = true;
			colParameters.VisibleIndex = 2;
			// 
			// colActive
			// 
			colActive.FieldName = "Active";
			colActive.Name = "colActive";
			// 
			// colCreatedDate
			// 
			colCreatedDate.FieldName = "CreatedDate";
			colCreatedDate.Name = "colCreatedDate";
			// 
			// colUpdatedDate
			// 
			colUpdatedDate.FieldName = "UpdatedDate";
			colUpdatedDate.Name = "colUpdatedDate";
			// 
			// GestaoAutomaticaMineracaoRC
			// 
			GestaoAutomaticaMineracaoRC.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 39, 35, 39);
			GestaoAutomaticaMineracaoRC.ExpandCollapseItem.Id = 0;
			GestaoAutomaticaMineracaoRC.Items.AddRange(new DevExpress.XtraBars.BarItem[] { GestaoAutomaticaMineracaoRC.ExpandCollapseItem, StartBBI, StopBBI, AlgorithmBEI, ProfitabilityCheckIntervalBEI, AtualizarBBI, TimerBEI });
			GestaoAutomaticaMineracaoRC.Location = new System.Drawing.Point(0, 0);
			GestaoAutomaticaMineracaoRC.Margin = new System.Windows.Forms.Padding(4);
			GestaoAutomaticaMineracaoRC.MaxItemId = 7;
			GestaoAutomaticaMineracaoRC.Name = "GestaoAutomaticaMineracaoRC";
			GestaoAutomaticaMineracaoRC.OptionsMenuMinWidth = 385;
			GestaoAutomaticaMineracaoRC.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpBase });
			GestaoAutomaticaMineracaoRC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { AlgorithmRIDG, IntervaloVerificacaoRentabilidadeRISE, TemporizadorRITE });
			GestaoAutomaticaMineracaoRC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
			GestaoAutomaticaMineracaoRC.Size = new System.Drawing.Size(1441, 186);
			// 
			// IniciarBBI
			// 
			StartBBI.Caption = "Iniciar";
			StartBBI.Id = 1;
			StartBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("IniciarBBI.ImageOptions.SvgImage");
			StartBBI.Name = "IniciarBBI";
			StartBBI.ItemClick += StartBBI_ItemClick;
			// 
			// PararBBI
			// 
			StopBBI.Caption = "Parar";
			StopBBI.Id = 2;
			StopBBI.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("PararBBI.ImageOptions.SvgImage");
			StopBBI.Name = "PararBBI";
			StopBBI.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			StopBBI.ItemClick += StopBBI_ItemClick;
			// 
			// AlgoritmoBEI
			// 
			AlgorithmBEI.Caption = "Algoritmo";
			AlgorithmBEI.Edit = AlgorithmRIDG;
			AlgorithmBEI.EditHeight = 85;
			AlgorithmBEI.EditWidth = 140;
			AlgorithmBEI.Id = 3;
			AlgorithmBEI.Name = "AlgoritmoBEI";
			// 
			// AlgoritmoRIDG
			// 
			AlgorithmRIDG.Columns = 1;
			AlgorithmRIDG.Name = "AlgoritmoRIDG";
			// 
			// IntervaloVerificacaoRentabilidadeBEI
			// 
			ProfitabilityCheckIntervalBEI.Caption = "Verificação Rentabilidade (m)";
			ProfitabilityCheckIntervalBEI.Edit = IntervaloVerificacaoRentabilidadeRISE;
			ProfitabilityCheckIntervalBEI.EditValue = new decimal(new int[] { 30, 0, 0, 0 });
			ProfitabilityCheckIntervalBEI.Id = 4;
			ProfitabilityCheckIntervalBEI.Name = "IntervaloVerificacaoRentabilidadeBEI";
			ProfitabilityCheckIntervalBEI.EditValueChanged += ProfitabilityCheckIntervalBEI_EditValueChanged;
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
			AtualizarBBI.ItemClick += RefreshBBI_ItemClick;
			// 
			// TemporizadorBEI
			// 
			TimerBEI.Caption = "Temporizador";
			TimerBEI.Edit = TemporizadorRITE;
			TimerBEI.EditWidth = 152;
			TimerBEI.Id = 6;
			TimerBEI.Name = "TemporizadorBEI";
			// 
			// TemporizadorRITE
			// 
			TemporizadorRITE.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			TemporizadorRITE.AutoHeight = false;
			TemporizadorRITE.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			TemporizadorRITE.EditValueChangedDelay = 1000;
			TemporizadorRITE.Name = "TemporizadorRITE";
			// 
			// rpBase
			// 
			rpBase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { OperacoresRPG, OpcoesRPG });
			rpBase.Name = "rpBase";
			rpBase.Text = "Gestão automática de mineração";
			// 
			// OperacoresRPG
			// 
			OperacoresRPG.ItemLinks.Add(AtualizarBBI);
			OperacoresRPG.ItemLinks.Add(StartBBI);
			OperacoresRPG.ItemLinks.Add(StopBBI);
			OperacoresRPG.Name = "OperacoresRPG";
			OperacoresRPG.Text = "Operações";
			// 
			// OpcoesRPG
			// 
			OpcoesRPG.ItemLinks.Add(TimerBEI);
			OpcoesRPG.ItemLinks.Add(ProfitabilityCheckIntervalBEI);
			OpcoesRPG.ItemLinks.Add(AlgorithmBEI);
			OpcoesRPG.Name = "OpcoesRPG";
			OpcoesRPG.Text = "Opções";
			// 
			// LateralDireitaLC
			// 
			LateralDireitaLC.BackColor = System.Drawing.Color.White;
			LateralDireitaLC.Controls.Add(ActiveMinerTE);
			LateralDireitaLC.Controls.Add(LastProfitabilityCheckDE);
			LateralDireitaLC.Controls.Add(LastMinerChangeDE);
			LateralDireitaLC.Controls.Add(CurrentCoinTE);
			LateralDireitaLC.Controls.Add(MostProfitableCoinTE);
			LateralDireitaLC.Dock = System.Windows.Forms.DockStyle.Right;
			LateralDireitaLC.Location = new System.Drawing.Point(986, 186);
			LateralDireitaLC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			LateralDireitaLC.Name = "LateralDireitaLC";
			LateralDireitaLC.Root = LateralDireitaLCG;
			LateralDireitaLC.Size = new System.Drawing.Size(455, 588);
			LateralDireitaLC.TabIndex = 1;
			LateralDireitaLC.Text = "layoutControl1";
			// 
			// MineradorActiveTE
			// 
			ActiveMinerTE.Location = new System.Drawing.Point(227, 72);
			ActiveMinerTE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ActiveMinerTE.MenuManager = GestaoAutomaticaMineracaoRC;
			ActiveMinerTE.Name = "MineradorActiveTE";
			ActiveMinerTE.Properties.ReadOnly = true;
			ActiveMinerTE.Size = new System.Drawing.Size(216, 26);
			ActiveMinerTE.StyleController = LateralDireitaLC;
			ActiveMinerTE.TabIndex = 3;
			// 
			// UltimaVerificacaoRentabilidadeDE
			// 
			LastProfitabilityCheckDE.EditValue = null;
			LastProfitabilityCheckDE.Location = new System.Drawing.Point(227, 12);
			LastProfitabilityCheckDE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			LastProfitabilityCheckDE.MenuManager = GestaoAutomaticaMineracaoRC;
			LastProfitabilityCheckDE.Name = "UltimaVerificacaoRentabilidadeDE";
			LastProfitabilityCheckDE.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
			LastProfitabilityCheckDE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			LastProfitabilityCheckDE.Properties.CalendarTimeProperties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
			LastProfitabilityCheckDE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			LastProfitabilityCheckDE.Properties.DisplayFormat.FormatString = "G";
			LastProfitabilityCheckDE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			LastProfitabilityCheckDE.Properties.EditFormat.FormatString = "G";
			LastProfitabilityCheckDE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			LastProfitabilityCheckDE.Properties.MaskSettings.Set("mask", "G");
			LastProfitabilityCheckDE.Properties.ReadOnly = true;
			LastProfitabilityCheckDE.Size = new System.Drawing.Size(216, 26);
			LastProfitabilityCheckDE.StyleController = LateralDireitaLC;
			LastProfitabilityCheckDE.TabIndex = 0;
			// 
			// UltimaAlteracaoMineradorDE
			// 
			LastMinerChangeDE.EditValue = null;
			LastMinerChangeDE.Location = new System.Drawing.Point(227, 42);
			LastMinerChangeDE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			LastMinerChangeDE.MenuManager = GestaoAutomaticaMineracaoRC;
			LastMinerChangeDE.Name = "UltimaAlteracaoMineradorDE";
			LastMinerChangeDE.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
			LastMinerChangeDE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			LastMinerChangeDE.Properties.CalendarTimeProperties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
			LastMinerChangeDE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
			LastMinerChangeDE.Properties.DisplayFormat.FormatString = "G";
			LastMinerChangeDE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			LastMinerChangeDE.Properties.EditFormat.FormatString = "G";
			LastMinerChangeDE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			LastMinerChangeDE.Properties.MaskSettings.Set("mask", "G");
			LastMinerChangeDE.Properties.ReadOnly = true;
			LastMinerChangeDE.Size = new System.Drawing.Size(216, 26);
			LastMinerChangeDE.StyleController = LateralDireitaLC;
			LastMinerChangeDE.TabIndex = 2;
			// 
			// MoedaAtualTE
			// 
			CurrentCoinTE.Location = new System.Drawing.Point(227, 102);
			CurrentCoinTE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			CurrentCoinTE.MenuManager = GestaoAutomaticaMineracaoRC;
			CurrentCoinTE.Name = "MoedaAtualTE";
			CurrentCoinTE.Properties.ReadOnly = true;
			CurrentCoinTE.Size = new System.Drawing.Size(216, 26);
			CurrentCoinTE.StyleController = LateralDireitaLC;
			CurrentCoinTE.TabIndex = 4;
			// 
			// MoedaMaisRentavelTE
			// 
			MostProfitableCoinTE.Location = new System.Drawing.Point(227, 132);
			MostProfitableCoinTE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MostProfitableCoinTE.MenuManager = GestaoAutomaticaMineracaoRC;
			MostProfitableCoinTE.Name = "MoedaMaisRentavelTE";
			MostProfitableCoinTE.Properties.ReadOnly = true;
			MostProfitableCoinTE.Size = new System.Drawing.Size(216, 26);
			MostProfitableCoinTE.StyleController = LateralDireitaLC;
			MostProfitableCoinTE.TabIndex = 5;
			// 
			// LateralDireitaLCG
			// 
			LateralDireitaLCG.AppearanceGroup.BackColor = System.Drawing.Color.White;
			LateralDireitaLCG.AppearanceGroup.Options.UseBackColor = true;
			LateralDireitaLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			LateralDireitaLCG.GroupBordersVisible = false;
			LateralDireitaLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { UltimaVerificacaoRentabilidadeLCI, UltimaAlteracaoMineradorLCI, MineradorActiveLCI, emptySpaceItem1, MoedaMaisRentavelLCI, MoedaAtualLCI });
			LateralDireitaLCG.Name = "LateralDireitaLCG";
			LateralDireitaLCG.Size = new System.Drawing.Size(455, 588);
			LateralDireitaLCG.TextVisible = false;
			// 
			// UltimaVerificacaoRentabilidadeLCI
			// 
			UltimaVerificacaoRentabilidadeLCI.Control = LastProfitabilityCheckDE;
			UltimaVerificacaoRentabilidadeLCI.Location = new System.Drawing.Point(0, 0);
			UltimaVerificacaoRentabilidadeLCI.Name = "UltimaVerificacaoRentabilidadeLCI";
			UltimaVerificacaoRentabilidadeLCI.Size = new System.Drawing.Size(435, 30);
			UltimaVerificacaoRentabilidadeLCI.Text = "Última verificação de rentabilidade";
			UltimaVerificacaoRentabilidadeLCI.TextSize = new System.Drawing.Size(203, 17);
			// 
			// UltimaAlteracaoMineradorLCI
			// 
			UltimaAlteracaoMineradorLCI.Control = LastMinerChangeDE;
			UltimaAlteracaoMineradorLCI.Location = new System.Drawing.Point(0, 30);
			UltimaAlteracaoMineradorLCI.Name = "UltimaAlteracaoMineradorLCI";
			UltimaAlteracaoMineradorLCI.Size = new System.Drawing.Size(435, 30);
			UltimaAlteracaoMineradorLCI.Text = "Última alteração de minerador";
			UltimaAlteracaoMineradorLCI.TextSize = new System.Drawing.Size(203, 17);
			// 
			// MineradorActiveLCI
			// 
			MineradorActiveLCI.Control = ActiveMinerTE;
			MineradorActiveLCI.Location = new System.Drawing.Point(0, 60);
			MineradorActiveLCI.Name = "MineradorActiveLCI";
			MineradorActiveLCI.Size = new System.Drawing.Size(435, 30);
			MineradorActiveLCI.Text = "Minerador ativo";
			MineradorActiveLCI.TextSize = new System.Drawing.Size(203, 17);
			// 
			// emptySpaceItem1
			// 
			emptySpaceItem1.AllowHotTrack = false;
			emptySpaceItem1.Location = new System.Drawing.Point(0, 150);
			emptySpaceItem1.Name = "emptySpaceItem1";
			emptySpaceItem1.Size = new System.Drawing.Size(435, 418);
			emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// MoedaMaisRentavelLCI
			// 
			MoedaMaisRentavelLCI.Control = MostProfitableCoinTE;
			MoedaMaisRentavelLCI.Location = new System.Drawing.Point(0, 120);
			MoedaMaisRentavelLCI.Name = "MoedaMaisRentavelLCI";
			MoedaMaisRentavelLCI.Size = new System.Drawing.Size(435, 30);
			MoedaMaisRentavelLCI.Text = "Moeda mais rentável";
			MoedaMaisRentavelLCI.TextSize = new System.Drawing.Size(203, 17);
			// 
			// MoedaAtualLCI
			// 
			MoedaAtualLCI.Control = CurrentCoinTE;
			MoedaAtualLCI.Location = new System.Drawing.Point(0, 90);
			MoedaAtualLCI.Name = "MoedaAtualLCI";
			MoedaAtualLCI.Size = new System.Drawing.Size(435, 30);
			MoedaAtualLCI.Text = "Moeda atual";
			MoedaAtualLCI.TextSize = new System.Drawing.Size(203, 17);
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
			// RootLC
			// 
			RootLC.Controls.Add(MinersGC);
			RootLC.Controls.Add(ExecutionME);
			RootLC.Dock = System.Windows.Forms.DockStyle.Fill;
			RootLC.Location = new System.Drawing.Point(0, 186);
			RootLC.Margin = new System.Windows.Forms.Padding(4);
			RootLC.Name = "RootLC";
			RootLC.Root = RootLCG;
			RootLC.Size = new System.Drawing.Size(986, 588);
			RootLC.TabIndex = 6;
			RootLC.Text = "layoutControl1";
			// 
			// ExecucaoME
			// 
			ExecutionME.Location = new System.Drawing.Point(12, 344);
			ExecutionME.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ExecutionME.MenuManager = GestaoAutomaticaMineracaoRC;
			ExecutionME.Name = "ExecucaoME";
			ExecutionME.Properties.Appearance.BackColor = System.Drawing.Color.Black;
			ExecutionME.Properties.Appearance.ForeColor = System.Drawing.Color.White;
			ExecutionME.Properties.Appearance.Options.UseBackColor = true;
			ExecutionME.Properties.Appearance.Options.UseForeColor = true;
			ExecutionME.Properties.ReadOnly = true;
			ExecutionME.Size = new System.Drawing.Size(962, 232);
			ExecutionME.StyleController = RootLC;
			ExecutionME.TabIndex = 5;
			// 
			// RootLCG
			// 
			RootLCG.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			RootLCG.GroupBordersVisible = false;
			RootLCG.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { MineradoresLCI, ExecucaoLCI });
			RootLCG.Name = "RootLCG";
			RootLCG.Size = new System.Drawing.Size(986, 588);
			RootLCG.TextVisible = false;
			// 
			// MineradoresLCI
			// 
			MineradoresLCI.Control = MinersGC;
			MineradoresLCI.Location = new System.Drawing.Point(0, 0);
			MineradoresLCI.Name = "MineradoresLCI";
			MineradoresLCI.Size = new System.Drawing.Size(966, 311);
			MineradoresLCI.TextSize = new System.Drawing.Size(0, 0);
			MineradoresLCI.TextVisible = false;
			// 
			// ExecucaoLCI
			// 
			ExecucaoLCI.Control = ExecutionME;
			ExecucaoLCI.Location = new System.Drawing.Point(0, 311);
			ExecucaoLCI.Name = "ExecucaoLCI";
			ExecucaoLCI.Size = new System.Drawing.Size(966, 257);
			ExecucaoLCI.Text = "Execução";
			ExecucaoLCI.TextLocation = DevExpress.Utils.Locations.Top;
			ExecucaoLCI.TextSize = new System.Drawing.Size(54, 17);
			// 
			// Temporizador
			// 
			Timer.Interval = 1000;
			Timer.Tick += Timer_Tick;
			// 
			// GestaoAutomaticaMineracaoUserControl
			// 
			Appearance.BackColor = System.Drawing.Color.White;
			Appearance.Options.UseBackColor = true;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(RootLC);
			Controls.Add(LateralDireitaLC);
			Controls.Add(GestaoAutomaticaMineracaoRC);
			Margin = new System.Windows.Forms.Padding(4);
			Name = "GestaoAutomaticaMineracaoUserControl";
			Size = new System.Drawing.Size(1441, 774);
			Load += AutomaticMiningManagerUserControl_Load;
			((System.ComponentModel.ISupportInitialize)MoedasGV).EndInit();
			((System.ComponentModel.ISupportInitialize)MinersGC).EndInit();
			((System.ComponentModel.ISupportInitialize)MinersBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)MinersGV).EndInit();
			((System.ComponentModel.ISupportInitialize)GestaoAutomaticaMineracaoRC).EndInit();
			((System.ComponentModel.ISupportInitialize)AlgorithmRIDG).EndInit();
			((System.ComponentModel.ISupportInitialize)IntervaloVerificacaoRentabilidadeRISE).EndInit();
			((System.ComponentModel.ISupportInitialize)TemporizadorRITE).EndInit();
			((System.ComponentModel.ISupportInitialize)LateralDireitaLC).EndInit();
			LateralDireitaLC.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ActiveMinerTE.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)LastProfitabilityCheckDE.Properties.CalendarTimeProperties).EndInit();
			((System.ComponentModel.ISupportInitialize)LastProfitabilityCheckDE.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)LastMinerChangeDE.Properties.CalendarTimeProperties).EndInit();
			((System.ComponentModel.ISupportInitialize)LastMinerChangeDE.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)CurrentCoinTE.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)MostProfitableCoinTE.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)LateralDireitaLCG).EndInit();
			((System.ComponentModel.ISupportInitialize)UltimaVerificacaoRentabilidadeLCI).EndInit();
			((System.ComponentModel.ISupportInitialize)UltimaAlteracaoMineradorLCI).EndInit();
			((System.ComponentModel.ISupportInitialize)MineradorActiveLCI).EndInit();
			((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
			((System.ComponentModel.ISupportInitialize)MoedaMaisRentavelLCI).EndInit();
			((System.ComponentModel.ISupportInitialize)MoedaAtualLCI).EndInit();
			((System.ComponentModel.ISupportInitialize)RootLC).EndInit();
			RootLC.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ExecutionME.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)RootLCG).EndInit();
			((System.ComponentModel.ISupportInitialize)MineradoresLCI).EndInit();
			((System.ComponentModel.ISupportInitialize)ExecucaoLCI).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl GestaoAutomaticaMineracaoRC;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpBase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OperacoresRPG;
        private DevExpress.XtraBars.BarButtonItem StartBBI;
        private DevExpress.XtraBars.BarButtonItem StopBBI;
        private DevExpress.XtraLayout.LayoutControl LateralDireitaLC;
        private DevExpress.XtraLayout.LayoutControlGroup LateralDireitaLCG;
        private DevExpress.XtraBars.BarEditItem AlgorithmBEI;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup AlgorithmRIDG;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup OpcoesRPG;
        private DevExpress.XtraBars.BarEditItem ProfitabilityCheckIntervalBEI;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit IntervaloVerificacaoRentabilidadeRISE;
        private DevExpress.XtraEditors.DateEdit LastProfitabilityCheckDE;
        private DevExpress.XtraLayout.LayoutControlItem UltimaVerificacaoRentabilidadeLCI;
        private DevExpress.XtraEditors.DateEdit LastMinerChangeDE;
        private DevExpress.XtraLayout.LayoutControlItem UltimaAlteracaoMineradorLCI;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit CurrentCoinTE;
        private DevExpress.XtraLayout.LayoutControlItem MoedaAtualLCI;
        private DevExpress.XtraGrid.GridControl MinersGC;
        private DevExpress.XtraGrid.Views.Grid.GridView MinersGV;
        private System.Windows.Forms.BindingSource MinersBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colParameters;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.BarButtonItem AtualizarBBI;
        private DevExpress.XtraGrid.Views.Grid.GridView MoedasGV;
        private DevExpress.XtraGrid.Columns.GridColumn colCoinIds;
        private DevExpress.XtraGrid.Columns.GridColumn colExternalIdMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colNameMoedas;
        private DevExpress.XtraGrid.Columns.GridColumn colBtc_revenueMoedas;
        private DevExpress.XtraEditors.TextEdit ActiveMinerTE;
        private DevExpress.XtraLayout.LayoutControlItem MineradorActiveLCI;
        private DevExpress.XtraEditors.TextEdit MostProfitableCoinTE;
        private DevExpress.XtraLayout.LayoutControlItem MoedaMaisRentavelLCI;
        private DevExpress.XtraLayout.LayoutControl RootLC;
        private DevExpress.XtraEditors.MemoEdit ExecutionME;
        private DevExpress.XtraLayout.LayoutControlGroup RootLCG;
        private DevExpress.XtraLayout.LayoutControlItem MineradoresLCI;
        private DevExpress.XtraLayout.LayoutControlItem ExecucaoLCI;
		private DevExpress.XtraBars.BarEditItem TimerBEI;
		private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit TemporizadorRITE;
		private System.Windows.Forms.Timer Timer;
	}
}
