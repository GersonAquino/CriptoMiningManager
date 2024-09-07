using CryptoMiningManager.Helpers;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System;
using System.Windows.Forms;

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

			if (Entidade.Id == -1 && string.IsNullOrWhiteSpace(Entidade.LocalizacaoLogsMineracao))
				Entidade.LocalizacaoLogsMineracao = "LogsMineração";

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

				if (string.IsNullOrWhiteSpace(Entidade.LocalizacaoLogsMineracao))
				{
					Entidade.LocalizacaoLogsMineracao = null;
					if (!MessageBoxesHelper.PerguntaSimples($"{ItemForLocalizacaoLogsMineracao.Text} está vazio, isto fará com que não sejam gravados logs! Pretende continuar?",
						"Aviso", MessageBoxIcon.Warning))
						return;
				}

				int idGerado = await EntidadesHelper.GravarEntidade_GetIdGerado(Entidade);

				if (idGerado != -1)
				{
					if (Entidade.Ativo)
						Global.ConfigGeralAtiva = Entidade;

					MessageBoxesHelper.MostraInformacao("Configuração Geral gravada com sucesso.", "Sucesso");

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

		private void LocalizacaoLogsMineracaoBE_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			try
			{
				string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
				using (FolderBrowserDialog fbd = new() { SelectedPath = baseDirectory })
				{
					if (fbd.ShowDialog() != DialogResult.OK)
						return;

					//Se o caminho escolhido começar no caminho da aplicação usa-se o caminho relativo
					if (fbd.SelectedPath.StartsWith(baseDirectory))
						LocalizacaoLogsMineracaoBE.EditValue = fbd.SelectedPath[baseDirectory.Length..]; //Substring(baseDirectory.Length)
					else
						LocalizacaoLogsMineracaoBE.EditValue = fbd.SelectedPath;

					//Por alguma razão, alterar diretamente a Entidade não resulta aqui, portanto altera-se o EditValue do ButtonEdit e força-se a escrita imediata no Binding
					LocalizacaoLogsMineracaoBE.DataBindings["EditValue"].WriteValue();
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao definir localização dos logs de mineração!");
				MessageBoxesHelper.MostraErro("Erro ao definir localização dos logs de mineração!", ex: ex);
			}
		}
	}
}
