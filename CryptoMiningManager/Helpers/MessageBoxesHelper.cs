using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace CryptoMiningManager.Helpers
{
	internal static class MessageBoxesHelper
	{
		internal static void MostraAviso(string texto, string titulo = "Aviso")
		{
			if (Global.AppVisivel)
				XtraMessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		internal static void MostraErro(string texto, string titulo = "Erro", Exception ex = null)
		{
			if (Global.AppVisivel)
				MostraErroCritico(texto, titulo, ex);
		}

		/// <summary>
		/// Este método é igual ao <see cref="MostraErro(string, string, Exception)"/> mas não valida a variável <see cref="Global.AppVisivel"/>
		/// </summary>
		/// <param name="texto"></param>
		/// <param name="titulo"></param>
		internal static void MostraErroCritico(string texto, string titulo = "Erro", Exception ex = null)
		{
			if (ex != null)
				texto += Environment.NewLine + ex.ToString();

			XtraMessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		internal static void MostraInformacao(string texto, string titulo = "Informação")
		{
			if (Global.AppVisivel)
				XtraMessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Faz uma pergunta de resposta "Sim" ou "Não".
		/// <para>Este método não valida a variável <see cref="Global.AppVisivel"/></para>
		/// </summary>
		/// <param name="texto"></param>
		/// <param name="titulo"></param>
		internal static bool PerguntaSimples(string texto, string titulo, MessageBoxIcon icon = MessageBoxIcon.Question)
		{
			return XtraMessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, icon) == DialogResult.Yes;
		}
	}
}
