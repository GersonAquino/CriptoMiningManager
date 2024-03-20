using CryptoMiningManager.Helpers;
using CryptoMiningManager.Helpers.Dados;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    internal partial class MineradoresUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        internal EntidadesHelper EntidadesHelper { get; }

        internal MineradoresUserControl(EntidadesHelper entidadesHelper)
        {
            InitializeComponent();

            EntidadesHelper = entidadesHelper;
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
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Erro ao criar novo Minerador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void EliminarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //FUNÇÕES AUXILIARES
        private async Task AtualizarDados()
        {
            MineradoresGV.BeginDataUpdate();
            try
            {
                MineradoresBindingSource.Clear();
                (await MineradorHelper.GetMineradoresComMoedas(ordenacao: "mi.Id, mo.ID")).ForEach(m => MineradoresBindingSource.Add(m.Value));

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
