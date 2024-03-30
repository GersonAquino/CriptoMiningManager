using CryptoMiningManager.Helpers;
using CryptoMiningManager.Helpers.Dados;
using DevExpress.XtraEditors;
using Modelos.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    internal partial class MineradoresUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        internal EntidadesHelper EntidadesHelper { get; }
        internal MineradorHelper MineradorHelper { get; }

        public MineradoresUserControl(EntidadesHelper entidadesHelper, MineradorHelper mineradorHelper)
        {
            InitializeComponent();

            EntidadesHelper = entidadesHelper;
            MineradorHelper = mineradorHelper;
        }

        private async void MineradoresUserControl_Load(object sender, EventArgs e)
        {
            await AtualizarDados();
        }

        private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await AtualizarDados();
        }

        private void NovoBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EntidadesHelper.AbrirEditorUC(new Minerador(), "Novo Minerador", ActiveControl);
        }

        private void MineradoresGV_DoubleClick(object sender, EventArgs e)
        {
            EntidadesHelper.DuploCliqueEntidade<Minerador>(e, MineradoresGV, ActiveControl);
        }

        private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EntidadesHelper.EditarEntidade<Minerador>(MineradoresGV, ActiveControl);
        }

        private async void EliminarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MineradoresGV.SelectedRowsCount == 0 || 
                    XtraMessageBox.Show("Pretende eliminar os mineradores selecionados?", "Eliminar mineradores", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                    return;

                int[] linhasSelecionadas = MineradoresGV.GetSelectedRows();
                int[] idMineradores = new int[linhasSelecionadas.Length];

                for (int i = 0; i < linhasSelecionadas.Length; i++)
                {
                    idMineradores[i] = (int)MineradoresGV.GetRowCellValue(linhasSelecionadas[i], colIdMinerador);
                }

                if (await MineradorHelper.EliminarMineradores(idMineradores) == linhasSelecionadas.Length)
                    XtraMessageBox.Show("Mineradores eliminados com sucesso!", "Mineradores eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Alguns mineradores não foram eliminados.", "Mineradores eliminados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Erro ao eliminar os mineradores selecionados.{Environment.NewLine}{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //FUNÇÕES AUXILIARES
        private async Task AtualizarDados()
        {
            MineradoresGV.BeginDataUpdate();
            try
            {
                MineradoresBindingSource.Clear();
                foreach (KeyValuePair<int, Minerador> minerador in await MineradorHelper.GetMineradoresComMoedas(ordenacao: "mi.Id, mo.ID"))
                {
                    MineradoresBindingSource.Add(minerador.Value);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Erro ao carregar form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MineradoresGV.EndDataUpdate();
            }
        }
    }
}
