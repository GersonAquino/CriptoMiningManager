using DataManager.Helpers;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using Models.Classes;
using Models.Enums;
using Models.Exceptions;
using Models.Interfaces;
using System;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configurations.Editors;

public partial class ComandoEditorUserControl : XtraUserControl
{
	private IEntityHelper<Command> EntityHelper { get; }

	private Command Entity { get; set; }

	public ComandoEditorUserControl(Command entity, IEntityHelper<Command> entityHelper)
	{
		InitializeComponent();

		Entity = entity;
		EntityHelper = entityHelper;

		ComamandBindingSource.Add(Entity);
	}

	private async void SaveBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			if (!BaseDLC.Validate())
				return;

			if (string.IsNullOrWhiteSpace(Entity.Commands))
			{
				CommandMemoEdit.Focus();
				throw new CustomException("Campo 'Comandos' não deve ficar vazio.", "Campos em falta");
			}

			int savedEntityId = await EntityHelper.SaveEntity_GetId(Entity);

			if (savedEntityId != -1)
			{
				//Entidade.UpdatedDate = DateTime.Now;
				XtraMessageBox.Show("Comando gravado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


				if (this.Parent is DocumentContainer docContainer)
				{
					if (XtraMessageBox.Show("Pretende criar novos comandos?", "Criar novos comandos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Entity = new Command();
						ComamandBindingSource.Clear();
						ComamandBindingSource.Add(Entity);

						docContainer.Document.Caption = "Novo Comando";
					}
					else
					{
						Entity.Id = savedEntityId;
						docContainer.Document.Caption = $"Editar Comando {Entity.Id}";
					}
				}
			}
			else
				XtraMessageBox.Show("Comando não gravado!", "Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
}
