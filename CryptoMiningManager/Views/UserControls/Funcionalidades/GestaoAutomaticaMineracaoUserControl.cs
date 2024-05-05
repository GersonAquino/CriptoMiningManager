using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GestorDados.Helpers;
using Modelos.Classes;
using Modelos.Enums;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadState = System.Threading.ThreadState;

namespace CryptoMiningManager.Views.UserControls.Funcionalidades
{
    public partial class GestaoAutomaticaMineracaoUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        //private readonly string URLRentabilidade;

        private int TempoEntreVerificacoes;

        private CancellationTokenSource CancelarThread = null;
        private Minerador MineradorAtivo = null;
        private Moeda MoedaMaisRentavel;
        private Process ProcessoAtivo = null;
        private Semaphore SemaforoLogsMineracao = new(1, 1);
        private Thread RentabilidadeThread = null;

        private readonly Regex EscapedSequences = new(@"\x1B\[[0-9;]*[mGKH]", RegexOptions.Compiled);

        private readonly IEntidadesHelper<Minerador> MineradoresHelper;
        private readonly IEntidadesHelper<Moeda> MoedasHelper;

        public GestaoAutomaticaMineracaoUserControl(IEntidadesHelper<Minerador> mineradoresHelper, IEntidadesHelper<Moeda> moedasHelper)
        {
            InitializeComponent();
            MineradoresHelper = mineradoresHelper;
            MoedasHelper = moedasHelper;

            //URLRentabilidade = ConfigurationManager.AppSettings["URLRentabilidade"];

            //Este método aparentemente vai buscar o DescriptionAttribute sozinho, então já fica com uma Caption decente
            AlgoritmoRIDG.Items.AddEnum<Algoritmo>();
            AlgoritmoBEI.EditValue = Algoritmo.MaisRentavel;

            TempoEntreVerificacoes = 60000; //10 minutos
        }

        private async void GestaoAutomaticaMineracaoUserControl_Load(object sender, EventArgs e)
        {
            await AtualizarMineradores();
        }

        #region Operações
        private async void AtualizarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await AtualizarMineradores();
        }

        private void IniciarBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this))
                {
                    PararProcessoAtivo();
                    PararThreadRentabilidade();

                    Minerador minerador;
                    switch ((Algoritmo)AlgoritmoBEI.EditValue)
                    {
                        case Algoritmo.Moeda:

                            break;
                        case Algoritmo.MaisRentavel:
                            CancelarThread = new CancellationTokenSource();
                            RentabilidadeThread = new Thread(async () => await MinerarPorRentabilidade(CancelarThread.Token)) { IsBackground = true };
                            RentabilidadeThread.Start();

                            break;
                        case Algoritmo.Selecionado:
                            if (MineradoresGV.IsDataRow(MineradoresGV.FocusedRowHandle) && MineradoresGV.FocusedRowObject is Minerador mineradorAux)
                                minerador = mineradorAux;
                            else
                                throw new CustomException("Não há nenhum minerador selecionado!");

                            IniciarMinerador(minerador);
                            break;
                        default:
                            throw new ArgumentException("Algoritmo inválido!");
                    }
                }
            }
            catch (CustomException ce)
            {
                XtraMessageBox.Show(ce.Message, ce.Detalhes ?? "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro a ler dados.");
                XtraMessageBox.Show("Erro a ler dados: " + ex.Message, "Erro a tentar ler dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PararBBI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this))
                {
                    PararProcessoAtivo();
                    PararThreadRentabilidade();
                    ExecucaoME.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao parar minerador.");
                XtraMessageBox.Show("Erro ao parar minerador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void IntervaloVerificacaoRentabilidadeBEI_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int intervaloVerificacaoRentabilidade = decimal.ToInt32((decimal)IntervaloVerificacaoRentabilidadeBEI.EditValue);
                TempoEntreVerificacoes = intervaloVerificacaoRentabilidade * 60000; //*1000 por serem milisegundos e *60 para passar a minutos
            }
            catch (Exception ex)
            {
                LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao alterar intervalo de verificação de rentabilidade.");
                XtraMessageBox.Show("Erro ao alterar intervalo de verificação de rentabilidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessoAtivo_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null) //Terminou o processo
            {
                LogHelper.EscreveLog(LogLevel.Information, $"A terminar o minerador {MineradorAtivo}");
                return;
            }

            ExecucaoME.AppendLine("ERRO: " + RemoveEscapeSequences(e.Data));
            LogHelper.EscreveLog(LogLevel.Warning, $"Erro no minerador {MineradorAtivo}: {e.Data}");

            ScrollFim();
        }

        private async void ProcessoAtivo_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Prevenir textos infinitos e excesso de utilização de memória com strings infinitas
            if (ExecucaoME.Text.Length > 10000)
            {
                try
                {
                    SemaforoLogsMineracao.WaitOne();
                    using (StreamWriter streamWriter = new("LogsMineração.txt", true))
                    {
                        await streamWriter.WriteLineAsync($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}{Environment.NewLine}{ExecucaoME.Text}");
                        await streamWriter.FlushAsync();
                        streamWriter.Close();
                    }

                    SemaforoLogsMineracao.Release();
                    Invoke(() => ExecucaoME.Clear());
                }
                catch (Exception ex)
                {
                    LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao guardar logs de mineração.");
                }
            }

            ExecucaoME.AppendLine(RemoveEscapeSequences(e.Data));
            ScrollFim();
        }

        //MÉTODOS AUXILIARES
        private async Task AtualizarMineradores()
        {
            IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MineradoresGC);
            try
            {
                MineradoresGV.BeginDataUpdate();

                await MoedasHelper.GravarEntidades();

                MineradoresBindingSource.Clear();
                foreach (KeyValuePair<int, Minerador> registo in await MineradoresHelper.GetEntidadesComLista("mi.Ativo = 1", "mi.Nome ASC"))
                {
                    if (registo.Value.Moeda != null)
                        MineradoresBindingSource.Add(registo.Value);
                }
            }
            catch (Exception ex)
            {
                LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao atualizar lista de mineradores.");
                XtraMessageBox.Show("Erro ao atualizar lista de mineradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MineradoresGV.EndDataUpdate();
                splashScreenHandler.Dispose();
            }
        }

        private Minerador GetMineradorMaisRentavel(List<Moeda> moedas)
        {
            moedas.Sort(Moedas.MaiorRentabilidade_Descendente);

            Invoke(() => MoedaMaisRentavelTE.Text = string.IsNullOrWhiteSpace(moedas[0].Nome) ? moedas[0].NomeExterno : moedas[0].Nome);

            Func<Moeda, bool> IsMoedaAtual = MineradorAtivo == null ? m => false :
                m => m.Id == MineradorAtivo.Moeda.Id;

            Dictionary<int, Minerador> mineradoresPorMoeda = ((BindingList<Minerador>)MineradoresBindingSource.List).ToDictionary(m => m.Moeda.Id);

            foreach (Moeda moeda in moedas)
            {
                //Se se chegar à moeda do MineradorAtual, então não vale a pena continuar a procurar.
                //Já estamos a minerar a moeda mais rentável para a qual foi configurado um minerador.
                if (IsMoedaAtual(moeda))
                    return MineradorAtivo;

                if (mineradoresPorMoeda.TryGetValue(moeda.Id, out Minerador minerador))
                    return minerador;
            }

            return null;
        }

        private void IniciarMinerador(Minerador minerador)
        {
            PararProcessoAtivo();

            ProcessoAtivo = new();

            ProcessoAtivo.StartInfo = new(minerador.Localizacao, minerador.Parametros)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            ProcessoAtivo.Start();

            ProcessoAtivo.ErrorDataReceived += ProcessoAtivo_ErrorDataReceived;
            ProcessoAtivo.OutputDataReceived += ProcessoAtivo_OutputDataReceived;

            ProcessoAtivo.BeginErrorReadLine();
            ProcessoAtivo.BeginOutputReadLine();

            if (MineradorAtivo != null)
                LogHelper.EscreveLog(LogLevel.Information, $"A mudar do minerador {MineradorAtivo} para o minerador {minerador}." +
                    $"Moedas: Antes: {MineradorAtivo.Moeda} | Depois: {minerador.Moeda}");

            if (MineradorAtivo?.Id != minerador.Id)
            {
                MineradorAtivo = minerador;
                Invoke(() =>
                {
                    UltimaAlteracaoMineradorDE.DateTime = DateTime.Now;
                    MineradorAtivoTE.Text = MineradorAtivo.Nome;
                    MoedaAtualTE.Text = MineradorAtivo.Moeda.Nome;
                });
            }
        }

        private async Task MinerarPorRentabilidade(CancellationToken cancelar)
        {
            try
            {
                while (!cancelar.IsCancellationRequested)
                {
                    List<Moeda> moedas = await MoedasHelper.GravarEntidades();

                    Minerador minerador = GetMineradorMaisRentavel(moedas);

                    if (minerador != null && MineradorAtivo?.Id != minerador.Id)
                        IniciarMinerador(minerador);

                    Invoke(() => UltimaVerificacaoRentabilidadeDE.DateTime = DateTime.Now);
                    Thread.Sleep(TempoEntreVerificacoes);
                }
            }
            catch (ThreadInterruptedException) { }
            catch (Exception ex)
            {
                LogHelper.EscreveLogException(LogLevel.Error, ex, "Erro ao verificar rentabilidade.");
                XtraMessageBox.Show("Erro ao verificar rentabilidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PararProcessoAtivo()
        {
            if (ProcessoAtivo == null)
                return;

            ProcessoAtivo.Kill(true);
            ProcessoAtivo.Dispose();
            ProcessoAtivo = null;
        }

        private void PararThreadRentabilidade()
        {
            if (RentabilidadeThread == null)
                return;

            if (RentabilidadeThread.ThreadState == ThreadState.WaitSleepJoin)
                RentabilidadeThread.Interrupt();
            else
                CancelarThread.Cancel();

            if (!RentabilidadeThread.Join(10000))
                XtraMessageBox.Show("O processo está a levar mais tempo para parar do que o esperado.", "Possível falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            CancelarThread.Dispose();
            CancelarThread = null;
            RentabilidadeThread = null;
        }

        private string RemoveEscapeSequences(string str)
        {
            return EscapedSequences.Replace(str, "");
        }

        private void ScrollFim()
        {
            Invoke(() =>
            {
                ExecucaoME.SelectionStart = ExecucaoME.Text.Length;
                ExecucaoME.SelectionLength = 0;
                ExecucaoME.ScrollToCaret();
            });
        }
    }
}
