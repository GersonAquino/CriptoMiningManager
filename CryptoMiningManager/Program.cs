using Autofac;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views;
using DevExpress.Xpf.Core.Native;
using GestorDados;
using GestorDados.Helpers;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime;
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

            #region JIT Improve
            Assembly assembly = Assembly.GetExecutingAssembly();
            string directoriaAplicacao = Path.GetDirectoryName(assembly.Location);

            ProfileOptimization.SetProfileRoot(directoriaAplicacao);
            ProfileOptimization.StartProfile(assembly.GetName().Name);
            #endregion JIT Improve

            //SerilogHelper.StartLogger(ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString);

            //SerilogHelper.EscreveLog(GestorDados.Enums.SerilogLevel.Information, "TESTE");

            using (IContainer container = ContainerConfig())
            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                Application.Run(scope.Resolve<MainForm>());
            }
        }


        private static IContainer ContainerConfig()
        {
            ContainerBuilder builder = new ContainerBuilder();

            string connectionString = ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString;

            // SQL e dados
            //O Register pode ter uma lambda expression com 1 ou 2 parâmetros, IComponentContext e IEnumerable<Parameter> respetivamente.
            //Pode-se usar o IComponentContext para fazer o Resolve de dependências registadas
            builder.Register(context => new Dados(connectionString)).As<IDados>().InstancePerDependency();

            // Base Helpers
            builder.RegisterType<HttpHelper>().As<IHttpHelper>().InstancePerDependency();
            builder.RegisterType<JsonHelper>().As<IJsonHelper>().SingleInstance();

            // Forms
            builder.RegisterType<MainForm>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
                .Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls))).InstancePerDependency().PreserveExistingDefaults();

            //Helpers
            builder.RegisterType<EntidadesHelper>().InstancePerLifetimeScope();
            builder.RegisterType<Dados>().As<IDados>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
