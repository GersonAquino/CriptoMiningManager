using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using Modelos.Classes;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System;
using System.IO;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes.Editores
{
    public partial class MineradorEditorUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private IEntidadesHelper<Minerador> MineradorHelper { get; }

        private Minerador Entidade { get; set; }

        public MineradorEditorUserControl(Minerador entidade, IEntidadesHelper<Minerador> mineradorHelper)
        {
            InitializeComponent();

            Entidade = entidade;
            MineradorHelper = mineradorHelper;

            MineradorBindingSource.Add(Entidade);
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
                    throw new CustomException("Localização não deve ficar vazia.", "Campos em falta");
                }

                if (!File.Exists(Entidade.Localizacao) &&
                    XtraMessageBox.Show("Inseriu uma localização inválida. Isto pode originar erros, pretender continuar?.",
                    "Localização inexistente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    LocalizacaoButtonEdit.Focus();
                    return;
                }

                if (await MineradorHelper.GravarEntidade(Entidade))
                {
                    Entidade.DataAlteracao = DateTime.Now;
                    XtraMessageBox.Show("Minerador gravado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (this.Parent is DocumentContainer docContainer)
                    {
                        if (docContainer.Document.Caption.StartsWith("Novo") || docContainer.Document.Caption.StartsWith("Editar") &&
                            XtraMessageBox.Show("Pretende criar novos mineradores?", "Criar novos mineradores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Entidade = new Minerador();
                            MineradorBindingSource.Clear();
                            MineradorBindingSource.Add(Entidade);

                            docContainer.Document.Caption = "Novo Minerador";
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
                XtraMessageBox.Show($"Erro ao selecionar localização!{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
