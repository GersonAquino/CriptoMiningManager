using CryptoMiningManager.Views;
using System;
using System.Windows.Forms;

namespace CryptoMiningManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SerilogHelper.StartLogger(ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString);

            //SerilogHelper.EscreveLog(GestorDados.Enums.SerilogLevel.Information, "TESTE");

            Application.Run(new MainForm());
        }
    }
}
