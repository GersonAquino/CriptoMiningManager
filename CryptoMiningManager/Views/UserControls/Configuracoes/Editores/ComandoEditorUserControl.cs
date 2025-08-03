using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes.Editores;

public partial class ComandoEditorUserControl : XtraUserControl
{
	private IEntidadesHelper<Comando> EntidadesHelper { get; }

	private Comando Entidade { get; set; }

	public ComandoEditorUserControl(Comando entidade, IEntidadesHelper<Comando> entidadesHelper)
	{
		InitializeComponent();

		Entidade = entidade;
		EntidadesHelper = entidadesHelper;

		ComandoBindingSource.Add(Entidade);
	}

	private async void GravarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
	{
		try
		{
			if (!BaseDLC.Validate())
				return;

			if (string.IsNullOrWhiteSpace(Entidade.Comandos))
			{
				ComandosMemoEdit.Focus();
				throw new CustomException("Campo 'Comandos' não deve ficar vazio.", "Campos em falta");
			}

			int idGerado = await EntidadesHelper.GravarEntidade_GetIdGerado(Entidade);

			if (idGerado != -1)
			{
				//Entidade.DataAlteracao = DateTime.Now;
				XtraMessageBox.Show("Comando gravado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


				if (this.Parent is DocumentContainer docContainer)
				{
					if (XtraMessageBox.Show("Pretende criar novos comandos?", "Criar novos comandos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						Entidade = new Comando();
						ComandoBindingSource.Clear();
						ComandoBindingSource.Add(Entidade);

						docContainer.Document.Caption = "Novo Comando";
					}
					else
					{
						Entidade.Id = idGerado;
						docContainer.Document.Caption = $"Editar Comando {Entidade.Id}";
					}
				}
			}
			else
				XtraMessageBox.Show("Comando não gravado!", "Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		catch (CustomException ce)
		{
			XtraMessageBox.Show(ce.Message, string.IsNullOrWhiteSpace(ce.Detalhes) ? "Aviso" : ce.Detalhes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		catch (Exception ex)
		{
			LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao gravar dados.");
			XtraMessageBox.Show($"Erro ao gravar dados!{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
