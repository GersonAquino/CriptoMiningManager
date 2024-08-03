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
	public partial class ConfiguracaoGeralEditorUserControl : XtraUserControl
	{
		private IEntidadesHelper<ConfiguracaoGeral> EntidadesHelper { get; }

		private ConfiguracaoGeral Entidade { get; set; }

		public ConfiguracaoGeralEditorUserControl(ConfiguracaoGeral entidade, IEntidadesHelper<ConfiguracaoGeral> entidadesHelper)
		{
			InitializeComponent();

			Entidade = entidade;
			EntidadesHelper = entidadesHelper;

			ConfigGeralBindingSource.Add(Entidade);
		}

		private async void GravarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (!BaseDLC.Validate())
					return;

				if (string.IsNullOrWhiteSpace(Entidade.Descricao))
				{
					DescricaoMemoEdit.Focus();
					throw new CustomException("Descrição não deve ficar vazia!");
				}

				int idGerado = await EntidadesHelper.GravarEntidade_GetIdGerado(Entidade);

				if (idGerado != -1)
				{
					if (Entidade.Ativo)
						Global.ConfigGeralAtiva = Entidade;

					MessageBoxesHelper.MostraInformacao("Configuração Geral gravado com sucesso.", "Sucesso");

					if (this.Parent is DocumentContainer docContainer)
					{
						if (Global.ConfirmacoesExtraEditores &&
							MessageBoxesHelper.PerguntaSimples("Pretende criar novas configurações gerais?", "Criar novas configurações gerais"))
						{
							Entidade = new ConfiguracaoGeral();
							ConfigGeralBindingSource.Clear();
							ConfigGeralBindingSource.Add(Entidade);

							docContainer.Document.Caption = "Nova Configuração Geral";
						}
						else
						{
							Entidade.Id = idGerado;
							docContainer.Document.Caption = $"Editar Configuração Geral {Entidade.Id}";
						}
					}
				}
				else
					MessageBoxesHelper.MostraAviso("Configuração Geral não gravada!", "Falhou");
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
