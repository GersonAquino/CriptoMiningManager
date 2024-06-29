using Modelos.Classes;

namespace CryptoMiningManager.Helpers
{
	/// <summary>
	/// Classe com variáveis estáticas globais (apenas dentro deste projeto)
	/// </summary>
	internal static class Global
	{
		public static ConfiguracaoGeral ConfigGeralAtiva { get; set; }

		public static bool ConfirmacoesExtraEditores { get => ConfigGeralAtiva?.ConfirmacoesExtraNosEditores == true; }
	}
}
