using CryptoMiningManager.Views;
using GestorDados;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace CryptoMiningManager
{
    internal static class Program
    {
        internal static Dados Dados;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Dados = new Dados(ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString, true))
            {

                //SerilogHelper.StartLogger(ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString);

                //SerilogHelper.EscreveLog(GestorDados.Enums.SerilogLevel.Information, "TESTE");

                Application.Run(new MainForm());
            }
        }
    }
}
