using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes.Editores
{
	public partial class MineradorEditorUserControl : XtraUserControl
	{
		private IEntidadesHelper<Minerador> EntidadesHelper { get; }
		private IEntidadesHelper<Moeda> MoedasHelper { get; }

		private Minerador Entidade { get; set; }

		public MineradorEditorUserControl(Minerador entidade, IEntidadesHelper<Minerador> entidadesHelper, IEntidadesHelper<Moeda> moedasHelper)
		{
			InitializeComponent();

			Entidade = entidade;
			EntidadesHelper = entidadesHelper;
			MoedasHelper = moedasHelper;

			MineradorBindingSource.Add(Entidade);
		}

		private async void MineradorEditorUserControl_Load(object sender, EventArgs e)
		{
			try
			{
				//Se o minerador não tiver moeda, só adiciona as moedas ao binding source
				//Caso tenha moeda vai verificar se a moeda da iteração atual é a correspondente
				//Caso a encontre, atribui-a ao EditValue e para de fazer a verificação
				Action<Moeda> iteracao = Entidade.Moeda != null ? m =>
				{
					MoedasBindingSource.Add(m);

					if (m.Id == Entidade.Moeda.Id)
					{
						MoedaSearchLookUpEdit.EditValue = m;
						iteracao = m => MoedasBindingSource.Add(m);
					}
				}
				: m => MoedasBindingSource.Add(m);

				foreach (Moeda moeda in await MoedasHelper.GetEntidades(ordenacao: "Nome ASC"))
				{
					iteracao(moeda);
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro");
				XtraMessageBox.Show("Erro ao carregar editor de minerador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void GravarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (!MineradorDLC.Validate())
					return;

				if (string.IsNullOrWhiteSpace(Entidade.Localizacao))
				{
					LocalizacaoButtonEdit.Focus();
					throw new CustomException("Campo 'Localização' não deve ficar vazio.", "Campos em falta");
				}

				if (!File.Exists(Entidade.Localizacao) &&
					XtraMessageBox.Show("Inseriu uma localização inválida. Isto pode originar erros, pretender continuar?.",
					"Localização inexistente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				{
					LocalizacaoButtonEdit.Focus();
					return;
				}

				int idGerado = await EntidadesHelper.GravarEntidade_GetIdGerado(Entidade);

				if (idGerado != -1)
				{
					XtraMessageBox.Show("Minerador gravado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

					if (this.Parent is DocumentContainer docContainer)
					{
						if (XtraMessageBox.Show("Pretende criar novos mineradores?", "Criar novos mineradores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							Entidade = new Minerador();
							MineradorBindingSource.Clear();
							MineradorBindingSource.Add(Entidade);

							docContainer.Document.Caption = "Novo Minerador";
						}
						else
						{
							Entidade.Id = idGerado;
							docContainer.Document.Caption = $"Editar Minerador {Entidade.Id}";
						}
					}
				}
				else
					XtraMessageBox.Show("Minerador não gravado!", "Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		private void LocalizacaoButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			try
			{
				using (OpenFileDialog ofd = new OpenFileDialog()
				{
					CheckFileExists = true,
					Filter = "cmd files (*.bat)|*.bat|powershell files (*.ps1)|*.ps1|All files (*.*)|*.*",
					//InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
					Multiselect = false,
					RestoreDirectory = true,
					ValidateNames = true
				})
				{
					if (ofd.ShowDialog() != DialogResult.OK)
						return;

					//Por alguma razão, alterar diretamente a Entidade não resulta aqui, portanto altera-se o EditValue do ButtonEdit e força-se a escrita imediata no Binding
					LocalizacaoButtonEdit.EditValue = ofd.FileName;
					LocalizacaoButtonEdit.DataBindings["EditValue"].WriteValue();
				}
			}
			catch (Exception ex)
			{
				LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao selecionar localização.");
				XtraMessageBox.Show($"Erro ao selecionar localização!{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
