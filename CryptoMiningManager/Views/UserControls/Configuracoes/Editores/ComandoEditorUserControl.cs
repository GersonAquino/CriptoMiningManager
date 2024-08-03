using CryptoMiningManager.Helpers;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System;

namespace CryptoMiningManager.Views.UserControls.Configuracoes.Editores
{
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
					throw new CustomException($"Campo '{ItemForComandos.Text}' não deve ficar vazio.", "Campos em falta");
				}

				int idGerado = await EntidadesHelper.GravarEntidade_GetIdGerado(Entidade);

				if (idGerado != -1)
				{
					//Entidade.DataAlteracao = DateTime.Now;
					MessageBoxesHelper.MostraInformacao("Comando gravado com sucesso.", "Sucesso");


					if (this.Parent is DocumentContainer docContainer)
					{
						if (Global.ConfirmacoesExtraEditores && MessageBoxesHelper.PerguntaSimples("Pretende criar novos comandos?", "Criar novos comandos"))
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
					MessageBoxesHelper.MostraAviso("Comando não gravado!", "Falhou");
			}
			catch (CustomException ce)
			{
				MessageBoxesHelper.MostraAviso(ce.Message, string.IsNullOrWhiteSpace(ce.Detalhes) ? "Aviso" : ce.Detalhes);
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao gravar dados.");
				MessageBoxesHelper.MostraErro("Erro ao gravar dados!", ex: ex);
			}
		}
	}
}
