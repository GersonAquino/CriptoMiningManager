using DataManager.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Models.Classes;
using Models.Enums;
using Models.Exceptions;
using Models.Interfaces;
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

namespace CryptoMiningManager.Views.UserControls.Main;

public partial class AutomaticMiningManagerUserControl : DevExpress.XtraEditors.XtraUserControl
{
	private int MillisecondsBetweenChecks { get; set; }

	private string MinerLogFullPath { get; set; }
	private string MinerLogsPath { get; set; }

	private CancellationTokenSource CancelThread { get; set; } = null;
	private Command PreMining { get; set; } = null;
	private Command AfterMining { get; set; } = null;
	private Miner ActiveMiner { get; set; } = null;
	private Process ActiveProcess { get; set; } = null;
	private Thread ProfitabilityThread { get; set; } = null;

	private Regex EscapedSequences { get; } = new(@"\x1B\[[0-9;]*[mGKH]", RegexOptions.Compiled);
	private Semaphore MinerLogsSemaphore { get; } = new(1, 1);

	private IEntityHelper<Command> CommandHelper { get; }
	private IEntityHelper<Miner> MinerHelper { get; }
	private IEntityHelper<Coin> CoinHelper { get; }

	public AutomaticMiningManagerUserControl(IEntityHelper<Command> commandHelper, IEntityHelper<Miner> minerHelper,
		IEntityHelper<Coin> coinHelper, string minerLogsPath)
	{
		InitializeComponent();

		CommandHelper = commandHelper;

		//Caso apareça mais algum caso como este (dados da configuração que precisem de ser lidos), talvez faça sentido criar algum tipo de classe estática ou algo parecido
		MinerLogsPath = minerLogsPath;

		MinerHelper = minerHelper;
		CoinHelper = coinHelper;

		//Este método aparentemente vai buscar o DescriptionAttribute sozinho, então já fica com uma Caption decente
		AlgorithmRIDG.Items.AddEnum<Algorithm>();
		AlgorithmBEI.EditValue = Algorithm.MostProfitable;

		MillisecondsBetweenChecks = 180000; //30 minutos
		TimerBEI.EditValue = new DateTime(0);
	}

	private async void AutomaticMiningManagerUserControl_Load(object sender, EventArgs e)
	{
		await RefreshData();
	}

	#region Operations
	private async void RefreshBBI_ItemClick(object sender, ItemClickEventArgs e)
	{
		await RefreshData();
	}

	private async void StartBBI_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this);
			await StopActiveProcess();
			StopProfitabilityThread();

			if (TimerBEI.EditValue is DateTime time && time.TimeOfDay.Ticks != 0)
			{
				ToggleStartAndStopButtons(false);
				Timer.Enabled = true;
			}
			else
				StartMining();
		}
		catch (CustomException ce)
		{
			XtraMessageBox.Show(ce.Message, ce.Details ?? "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro a ler dados.");
			XtraMessageBox.Show("Erro a ler dados: " + ex.Message, "Erro a tentar ler dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private async void StopBBI_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(this);
			await StopEverything();
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao parar minerador.");
			XtraMessageBox.Show("Erro ao parar minerador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
	#endregion

	private void ProfitabilityCheckIntervalBEI_EditValueChanged(object sender, EventArgs e)
	{
		try
		{
			int profitabilityCheckInterval = decimal.ToInt32((decimal)ProfitabilityCheckIntervalBEI.EditValue);
			MillisecondsBetweenChecks = profitabilityCheckInterval * 60000; //*1000 por serem milisegundos e *60 para passar a minutos
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao alterar intervalo de verificação de rentabilidade.");
			XtraMessageBox.Show("Erro ao alterar intervalo de verificação de rentabilidade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	#region ActiveProcess Output
	private void ActiveProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
	{
		if (e.Data == null) //Terminou o processo
		{
			LogHelper.WriteLog(LogLevel.Information, $"A terminar o minerador {ActiveMiner}");
			return;
		}

		ExecutionME.AppendLine("ERRO: " + RemoveEscapeSequences(e.Data));
		LogHelper.WriteLog(LogLevel.Warning, $"Erro no minerador {ActiveMiner}: {e.Data}");

		ScrollToTheEnd();
	}

	private void ActiveProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
	{
		try
		{
			//Prevenir textos infinitos e excesso de utilização de memória com strings infinitas
			if (ExecutionME.Text.Length > 50000)
				WriteMiningLogs();

			ExecutionME.AppendLine(RemoveEscapeSequences(e.Data));
			ScrollToTheEnd();
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao tratar output");
		}
	}
	#endregion

	private void Timer_Tick(object sender, EventArgs e)
	{
		try
		{
			if (TimerBEI.EditValue is DateTime time)
			{
				//Subtrai 1 segundo da forma mais eficiente que há, ainda que seja praticamente insignificante
				DateTime newTime = time.AddTicks(-TimeSpan.TicksPerSecond);
				TimerBEI.EditValue = newTime;

				if (newTime.TimeOfDay.Ticks == 0)
					StopTimer();
			}
			else
				StopTimer();
		}
		catch (Exception ex)
		{
			//Em caso de falha, regista-se o erro e inicia-se a mineração
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro no temporizador");
			StopTimer();
		}
	}

	//MÉTODOS AUXILIARES
	private async Task RefreshData()
	{
		try
		{
			using IOverlaySplashScreenHandle splashScreenHandler = SplashScreenManager.ShowOverlayForm(MinersGC);
			MinersGV.BeginDataUpdate();

			//Atualizar mineradores
			await CoinHelper.SaveEntities();

			MinersBindingSource.Clear();
			foreach (KeyValuePair<int, Miner> record in await MinerHelper.GetEntitiesWithList("mi.Active = 1", "mi.Name ASC"))
			{
				if (record.Value.Coin != null)
					MinersBindingSource.Add(record.Value);
			}

			PreMining = null;
			AfterMining = null;
			//Atualizar comandos
			foreach (Command command in await CommandHelper.GetEntities("Active = 1"))
			{
				if (command.PreMining)
					PreMining = command;

				if (command.PosMining)
					AfterMining = command;
			}
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao atualizar lista de mineradores.");
			XtraMessageBox.Show("Erro ao atualizar lista de mineradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			MinersGV.EndDataUpdate();
		}
	}

	private void WriteMiningLogs()
	{
		//O semáforo garante que nunca se vai tentar escrever no ficheiro 2 vezes (ou mais) em simultâneo
		MinerLogsSemaphore.WaitOne();
		using (StreamWriter streamWriter = new(MinerLogFullPath, true))
		{
			streamWriter.WriteLine($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}{Environment.NewLine}{ExecutionME.Text}");
			streamWriter.Flush();
			streamWriter.Close();
		}

		Invoke(() => ExecutionME.Clear());
		MinerLogsSemaphore.Release();
	}

	private Miner GetMostProfitableMiner(List<Coin> coins)
	{
		coins.Sort(Coins.ProfitabilityComparison_Descending);

		Invoke(() => MostProfitableCoinTE.Text = string.IsNullOrWhiteSpace(coins[0].Name) ? coins[0].ExternalName : coins[0].Name);

		Func<Coin, bool> IsCurrentCoin = ActiveMiner == null ? m => false : m => m.Id == ActiveMiner.Coin.Id;

		Dictionary<int, Miner> minersPerCoin = ((BindingList<Miner>)MinersBindingSource.List).ToDictionary(m => m.Coin.Id);

		foreach (Coin coin in coins)
		{
			//Se se chegar à moeda do MineradorAtual, então não vale a pena continuar a procurar.
			//Já estamos a minerar a moeda mais rentável para a qual foi configurado um minerador.
			if (IsCurrentCoin(coin))
				return ActiveMiner;

			if (minersPerCoin.TryGetValue(coin.Id, out Miner miner))
				return miner;
		}

		return null;
	}

	private void StartMining()
	{
		if (!Directory.Exists(MinerLogsPath))
			Directory.CreateDirectory(MinerLogsPath);

		int i = 1;
		string nomeBase = $"Log_{DateTime.Now:yyyy-MM-dd HH-mm-ss}";
		MinerLogFullPath = Path.Combine(MinerLogsPath, $"{nomeBase}.txt");
		while (File.Exists(MinerLogFullPath))
		{
			MinerLogFullPath = Path.Combine(MinerLogsPath, $"{nomeBase}_{i++}.txt");
		}

		Miner miner;
		switch ((Algorithm)AlgorithmBEI.EditValue)
		{
			case Algorithm.Coin:

				break;
			case Algorithm.MostProfitable:
				CancelThread = new CancellationTokenSource();
				ProfitabilityThread = new Thread(async () => await ProfitabilityMining(CancelThread.Token)) { IsBackground = true };
				ProfitabilityThread.Start();
				break;
			case Algorithm.Selected:
				if (MinersGV.IsDataRow(MinersGV.FocusedRowHandle) && MinersGV.FocusedRowObject is Miner mineradorAux)
					miner = mineradorAux;
				else
					throw new CustomException("Não há nenhum minerador selecionado!");

				StartMiner(miner);
				break;
			default:
				throw new ArgumentException("Algoritmo inválido!");
		}
	}

	private async void StartMiner(Miner miner)
	{
		await StopActiveProcess();

		if (PreMining != null)
		{
			using Process process = new();
			process.StartInfo = new("cmd.exe", PreMining.CommandLineCommands)
			{
				CreateNoWindow = true,
				UseShellExecute = false
			};

			if (process.Start())
				await process.WaitForExitAsync();
			else
				Invoke(() => LogHelper.WriteLog(LogLevel.Warning, "Não foi possível iniciar o comando pré-mineração {idComando}", PreMining.Id));
		}


		ActiveProcess = new()
		{
			StartInfo = new(miner.Location, miner.Parameters)
			{
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			}
		};


		if (!ActiveProcess.Start())
			throw new Exception($"Não foi possível iniciar o minerador {miner}");

		ActiveProcess.ErrorDataReceived += ActiveProcess_ErrorDataReceived;
		ActiveProcess.OutputDataReceived += ActiveProcess_OutputDataReceived;

		ActiveProcess.BeginErrorReadLine();
		ActiveProcess.BeginOutputReadLine();

		if (ActiveMiner != null)
			Invoke(() => LogHelper.WriteLog(LogLevel.Information, $"A mudar do minerador {ActiveMiner} para o minerador {miner}." +
				$"Moedas: Antes: {ActiveMiner.Coin} | Depois: {miner.Coin}"));

		if (ActiveMiner?.Id != miner.Id)
		{
			ActiveMiner = miner;
			BeginInvoke(() =>
			{
				LastMinerChangeDE.DateTime = DateTime.Now;
				ActiveMinerTE.Text = ActiveMiner.Name;
				CurrentCoinTE.Text = ActiveMiner.Coin.Name;
			});
		}

		ToggleStartAndStopButtons(false);
	}

	private async Task ProfitabilityMining(CancellationToken cancelar)
	{
		try
		{
			Invoke(() => LogHelper.WriteLog(LogLevel.Information, "A iniciar mineração por rentabilidade"));
			while (!cancelar.IsCancellationRequested)
			{
				List<Coin> coins = await CoinHelper.SaveEntities();

				Miner miner = GetMostProfitableMiner(coins);

				if (miner != null && ActiveMiner?.Id != miner.Id)
					StartMiner(miner);

				BeginInvoke(() => LastProfitabilityCheckDE.DateTime = DateTime.Now);
				Thread.Sleep(MillisecondsBetweenChecks);
			}
		}
		catch (ThreadInterruptedException) { }
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao verificar rentabilidade.");
			XtraMessageBox.Show($"Erro ao verificar rentabilidade: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private async Task StopActiveProcess()
	{
		if (ActiveProcess == null)
			return;

		ActiveProcess.Kill(true);
		ActiveProcess.Dispose();
		ActiveProcess = null;
		ActiveMiner = null;

		try
		{
			WriteMiningLogs();
		}
		catch (Exception ex)
		{
			LogHelper.WriteExceptionLog(LogLevel.Error, ex, "Erro ao guardar logs de mineração.");
		}

		if (AfterMining != null)
		{
			using Process process = new();
			process.StartInfo = new("cmd.exe", AfterMining.CommandLineCommands)
			{
				CreateNoWindow = true,
				UseShellExecute = false
			};

			if (process.Start())
				await process.WaitForExitAsync();
			else
				Invoke(() => LogHelper.WriteLog(LogLevel.Warning, "Não foi possível iniciar o comando pós-mineração {idComando}", AfterMining.Id));
		}

		ToggleStartAndStopButtons(true);
	}

	private void StopProfitabilityThread()
	{
		if (ProfitabilityThread == null)
			return;

		if (ProfitabilityThread.ThreadState == ThreadState.WaitSleepJoin)
			ProfitabilityThread.Interrupt();
		else
			CancelThread.Cancel();

		if (!ProfitabilityThread.Join(10000))
			XtraMessageBox.Show("O processo está a levar mais tempo para parar do que o esperado.", "Possível falha", MessageBoxButtons.OK, MessageBoxIcon.Warning);

		CancelThread.Dispose();
		CancelThread = null;
		ProfitabilityThread = null;
	}

	public async Task StopEverything()
	{
		if (Timer.Enabled)
		{
			Timer.Enabled = false;
			ToggleStartAndStopButtons(true);
		}
		else
		{
			await StopActiveProcess();
			StopProfitabilityThread();
			ExecutionME.Text = string.Empty;
		}
	}

	private string RemoveEscapeSequences(string str)
	{
		return EscapedSequences.Replace(str, "");
	}

	private void ScrollToTheEnd()
	{
		Invoke(() =>
		{
			ExecutionME.SelectionStart = ExecutionME.Text.Length;
			ExecutionME.SelectionLength = 0;
			ExecutionME.ScrollToCaret();
		});
	}

	/// <summary>
	/// Para o temporizador e inicia a mineração
	/// </summary>
	private void StopTimer()
	{
		Timer.Enabled = false;
		StartMining();
	}

	/// <summary>
	/// Alterna o botão visível entre o Iniciar e o Parar
	/// </summary>
	/// <param name="showStartBtn">true para mostrar o botão Iniciar e esconder o Parar, false para o inverso</param>
	private void ToggleStartAndStopButtons(bool showStartBtn)
	{
		Invoke(() =>
		{
			if (showStartBtn)
			{
				StartBBI.Visibility = BarItemVisibility.Always;
				StopBBI.Visibility = BarItemVisibility.Never;
			}
			else
			{
				StartBBI.Visibility = BarItemVisibility.Never;
				StopBBI.Visibility = BarItemVisibility.Always;
			}
		});
	}
}
