using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CryptoMiningManager.Helpers
{
	public static class WindowsAPIHelper
	{
		[StructLayout(LayoutKind.Sequential)]
		private struct LASTINPUTINFO
		{
			internal uint cbSize;
			internal uint dwTime;
		}

		[DllImport("user32.dll")]
		private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

		[DllImport("kernel32.dll")]
		private static extern uint GetTickCount();

		[DllImport("powrprof.dll", SetLastError = true)]
		private static extern uint PowerSetActiveScheme(IntPtr UserRootPowerKey, ref Guid SchemeGuid);

		//Planos de energia
		internal static readonly Guid PoupancaEnergia = new("a1841308-3541-4fab-bc81-f71556f20b4a"); // Power Saver
		internal static readonly Guid Equilibrado = new("381b4222-f694-41f0-9685-ff5bb260df2e"); // Balanced
		internal static readonly Guid AltoDesempenho = new("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c"); // High Performance


		/// <summary>
		/// Devolve o tempo (em segundos) desde a última interação do utilizador com o sistema
		/// </summary>
		/// <returns></returns>
		internal static uint GetTempoInativo()
		{
			LASTINPUTINFO lastInputInfo = new();
			lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
			lastInputInfo.dwTime = 0;

			if (!GetLastInputInfo(ref lastInputInfo))
				throw new Win32Exception(Marshal.GetLastWin32Error());

			uint tickCount = (uint)Environment.TickCount;
			uint idleTime = tickCount - lastInputInfo.dwTime;
			if (tickCount < lastInputInfo.dwTime) //Ocorreu um rollover - Após ~50 dias o nº de ticks volta a 0, portanto, para fazer os cálculos corretamente, é preciso forçar o overflow e voltar pra trás
				unchecked { idleTime += uint.MaxValue + 1; }

			return idleTime / 1000;
		}

		internal static void MudarPlanoEnergia(Guid planoEnergia)
		{
			uint resultado = PowerSetActiveScheme(IntPtr.Zero, ref planoEnergia);
			if (resultado != 0)
				throw new Win32Exception((int)resultado, "Não foi possível alterar o plano de energia!");
		}
	}
}
