using CryptoMiningManager.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    public partial class ComandosUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        private ConfiguracoesEntidadesHelper ConfiguracoesEntidadesHelper { get; }
        private IEntidadesHelper<Comando> EntidadesHelper { get; }

        public ComandosUserControl(ConfiguracoesEntidadesHelper configuracoesEntidadesHelper, IEntidadesHelper<Comando> entidadesHelper)
        {
            InitializeComponent();

            ConfiguracoesEntidadesHelper = configuracoesEntidadesHelper;
            EntidadesHelper = entidadesHelper;
        }

        private async void ComandosUserControl_Load(object sender, EventArgs e)
        {
            await AtualizarDados();
            ComandosGV.BestFitColumns(true);
        }

        private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await AtualizarDados();
        }

        private void NovoBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfiguracoesEntidadesHelper.AbrirEditorUC<Comando>("Novo Comando", ActiveControl);
        }

        private void ComandosGV_DoubleClick(object sender, EventArgs e)
        {
            ConfiguracoesEntidadesHelper.DuploCliqueEntidade<Comando>(e, ComandosGV, ActiveControl);
        }

        private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfiguracoesEntidadesHelper.EditarEntidade<Comando>(ComandosGV, ActiveControl);
        }

        private async void EliminarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (ComandosGV.SelectedRowsCount == 0 ||
                    XtraMessageBox.Show("Pretende eliminar os comandos selecionados?", "Eliminar comandos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                    return;

                int[] linhasSelecionadas = ComandosGV.GetSelectedRows();
                int[] idComandos = new int[linhasSelecionadas.Length];

                for (int i = 0; i < linhasSelecionadas.Length; i++)
                {
                    idComandos[i] = (int)ComandosGV.GetRowCellValue(linhasSelecionadas[i], colId);
                }

                ComandosGV.BeginUpdate();
                if (await EntidadesHelper.EliminarEntidades(idComandos) == linhasSelecionadas.Length)
                {
                    ComandosGV.DeleteSelectedRows();

                    XtraMessageBox.Show("Comandos eliminados com sucesso!", "Comandos eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Atualizam-se os dados todos porque não se sabe exatamente quais as entidades eliminadas
                    await AtualizarDados();
                    XtraMessageBox.Show("Alguns comandos não foram eliminados.", "Comandos eliminados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao eliminar os comandos selecionados.");
                XtraMessageBox.Show($"Erro ao eliminar os comandos selecionados.{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ComandosGV.EndUpdate();
            }
        }

        //FUNÇÕES AUXILIARES
        private async Task AtualizarDados()
        {

            IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(ComandosGC);
            ComandosGV.BeginDataUpdate();
            try
            {
                ComandosBindingSource.Clear();
                foreach (Comando comando in await EntidadesHelper.GetEntidades())
                {
                    ComandosBindingSource.Add(comando);
                }
            }
            catch (Exception ex)
            {
                LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao carregar dados.");
                XtraMessageBox.Show(ex.Message, "Erro ao carregar dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ComandosGV.EndDataUpdate();
                splashScreenHandler.Dispose();
            }
        }
    }
}
