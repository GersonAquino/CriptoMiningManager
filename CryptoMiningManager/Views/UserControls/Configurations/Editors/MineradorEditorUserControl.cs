using DataManager.Helpers;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using Models.Classes;
using Models.Enums;
using Models.Exceptions;
using Models.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configurations.Editors;

public partial class MineradorEditorUserControl : XtraUserControl
{
	private IEntityHelper<Miner> EntityHelper { get; }
	private IEntityHelper<Coin> CoinHelper { get; }

	private Miner Entity { get; set; }

	public MineradorEditorUserControl(Miner entity, IEntityHelper<Miner> entityHelper, IEntityHelper<Coin> coinHelper)
	{
		InitializeComponent();

		Entity = entity;
		EntityHelper = entityHelper;
		CoinHelper = coinHelper;

		MinerBindingSource.Add(Entity);
	}

	private async void MinerEditorUserControl_Load(object sender, EventArgs e)
	{
		try
		{
			//Se o minerador não tiver moeda, só adiciona as moedas ao binding source
			//Caso tenha moeda vai verificar se a moeda da iteração atual é a correspondente
			//Caso a encontre, atribui-a ao EditValue e para de fazer a verificação
			Action<Coin> iteration = Entity.Coin != null ? m =>
			{
				CoinBindingSource.Add(m);

				if (m.Id == Entity.Coin.Id)
				{
					CoinSearchLookUpEdit.EditValue = m;
					iteration = m => CoinBindingSource.Add(m);
				}
			}
			: m => CoinBindingSource.Add(m);

			foreach (Coin coin in await CoinHelper.GetEntities(sorting: "Name DESC"))
			{
				iteration(coin);
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro");
			XtraMessageBox.Show("Erro ao carregar editor de minerador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private async void SaveBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			if (!MinerDLC.Validate())
				return;

			if (string.IsNullOrWhiteSpace(Entity.Location))
			{
				LocationButtonEdit.Focus();
				throw new CustomException("Campo 'Localização' não deve ficar vazio.", "Campos em falta");
			}

			if (!File.Exists(Entity.Location) &&
				XtraMessageBox.Show("Inseriu uma localização inválida. Isto pode originar erros, pretender continuar?.",
				"Localização inexistente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
			{
				LocationButtonEdit.Focus();
				return;
			}

			int savedEntityId = await EntityHelper.SaveEntity_GetId(Entity);

			if (savedEntityId != -1)
			{
				XtraMessageBox.Show("Minerador gravado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (this.Parent is DocumentContainer docContainer)
				{
					if (XtraMessageBox.Show("Pretende criar novos mineradores?", "Criar novos mineradores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Entity = new Miner();
						MinerBindingSource.Clear();
						MinerBindingSource.Add(Entity);

						docContainer.Document.Caption = "Novo Minerador";
					}
					else
					{
						Entity.Id = savedEntityId;
						docContainer.Document.Caption = $"Editar Minerador {Entity.Id}";
					}
				}
			}
			else
				XtraMessageBox.Show("Minerador não gravado!", "Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		catch (CustomException ce)
		{
			XtraMessageBox.Show(ce.Message, string.IsNullOrWhiteSpace(ce.Details) ? "Aviso" : ce.Details, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao gravar dados.");
			XtraMessageBox.Show($"Erro ao gravar dados!{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void LocationButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
	{
		try
		{
			using OpenFileDialog ofd = new()
			{
				CheckFileExists = true,
				Filter = "cmd files (*.bat)|*.bat|powershell files (*.ps1)|*.ps1|All files (*.*)|*.*",
				//InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				Multiselect = false,
				RestoreDirectory = true,
				ValidateNames = true
			};

			if (ofd.ShowDialog() != DialogResult.OK)
				return;

			//Por alguma razão, alterar diretamente a Entidade não resulta aqui, portanto altera-se o EditValue do ButtonEdit e força-se a escrita imediata no Binding
			LocationButtonEdit.EditValue = ofd.FileName;
			LocationButtonEdit.DataBindings["EditValue"].WriteValue();
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao selecionar localização.");
			XtraMessageBox.Show($"Erro ao selecionar localização!{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
