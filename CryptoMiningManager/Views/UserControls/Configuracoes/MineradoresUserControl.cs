using CryptoMiningManager.DadosHelpers;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager.Views.UserControls.Configuracoes
{
    public partial class MineradoresUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        public MineradoresUserControl()
        {
            InitializeComponent();
        }

        private async void MineradoresUserControl_Load(object sender, EventArgs e)
        {
            await AtualizarDados();
        }

        private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await AtualizarDados();
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
