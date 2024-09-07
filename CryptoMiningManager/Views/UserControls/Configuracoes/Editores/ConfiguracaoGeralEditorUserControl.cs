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
					if (XtraMessageBox.Show($"{ItemForLocalizacaoLogsMineracao.Text} está vazio, isto fará com que não sejam gravados logs! Pretende continuar?",
						"Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
						return;
				}

				int idGerado = await EntidadesHelper.GravarEntidade_GetIdGerado(Entidade);

				if (idGerado != -1)
				{
					if (Entidade.Ativo)
						Global.ConfigGeralAtiva = Entidade;

					XtraMessageBox.Show("Configuração Geral gravada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

					if (this.Parent is DocumentContainer docContainer)
					{
						if (Global.ConfirmacoesExtraEditores &&
							XtraMessageBox.Show("Pretende criar novas configurações gerais?", "Criar novas configurações gerais", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
					XtraMessageBox.Show("Configuração Geral não gravada!", "Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				XtraMessageBox.Show(ex.GetBaseException().Message, $"Erro ao definir localização dos logs de mineração!{Environment.NewLine}{ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
