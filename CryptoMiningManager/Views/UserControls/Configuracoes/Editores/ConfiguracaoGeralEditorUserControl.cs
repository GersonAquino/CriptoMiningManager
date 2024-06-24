using Autofac;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
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
		private ILifetimeScope Scope { get; }

		private ConfiguracaoGeral Entidade { get; set; }

		public ConfiguracaoGeralEditorUserControl(ConfiguracaoGeral entidade, IEntidadesHelper<ConfiguracaoGeral> entidadesHelper, ILifetimeScope scope)
		{
			InitializeComponent();

			Entidade = entidade;
			EntidadesHelper = entidadesHelper;
			Scope = scope;

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
						Scope.Resolve<MainForm>().ConfigGeralAtiva = Entidade;

					XtraMessageBox.Show("Configuração Geral gravado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

					if (this.Parent is DocumentContainer docContainer)
					{
						if (XtraMessageBox.Show("Pretende criar novas configurações gerais?", "Criar novas configurações gerais", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
	}
}
