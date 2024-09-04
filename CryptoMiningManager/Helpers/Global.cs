using Modelos.Classes;
using System.Windows.Forms;

namespace CryptoMiningManager.Helpers
{
	/// <summary>
	/// Classe com variáveis estáticas globais (apenas dentro deste projeto)
	/// </summary>
	internal static class Global
	{
		internal static bool AppVisivel { get; set; }
		internal static ConfiguracaoGeral ConfigGeralAtiva { get; set; }
		internal static bool ConfirmacoesExtraEditores { get => ConfigGeralAtiva?.ConfirmacoesExtraNosEditores == true; }

		/// <summary>
		/// Item Algoritmos do TaskbarIcon
		/// </summary>
		internal static ToolStripMenuItem AlgoritmosTB { get; set; }

		/// <summary>
		/// Item Mineradores do TaskbarIcon
		/// </summary>
		internal static ToolStripMenuItem MineradoresRB { get; set; }
	}
}
