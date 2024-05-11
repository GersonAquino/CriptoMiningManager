using Autofac;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views;
using DevExpress.XtraEditors;
using GestorDados;
using GestorDados.Helpers;
using Modelos.Interfaces;
using Serilog;
using System;
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
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region JIT Improve
            Assembly assembly = Assembly.GetExecutingAssembly();

            ProfileOptimization.SetProfileRoot(Path.GetDirectoryName(assembly.Location));
            ProfileOptimization.StartProfile(assembly.GetName().Name);
            #endregion JIT Improve

            LogHelper.StartLogger(ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString.Split('=')[1]);

            try
            {
                using (IContainer container = ContainerConfig())
                using (ILifetimeScope scope = container.BeginLifetimeScope())
                {
                    Application.Run(scope.Resolve<MainForm>());
                }
            }
            finally
            {
                LogHelper.StopLogger();
            }
        }

        private static IContainer ContainerConfig()
        {
            ContainerBuilder builder = new();

            string connectionString = ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString;
            string urlBase = ConfigurationManager.AppSettings["URLRentabilidade"];

            //Modelos
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Modelos))).Where(t => t.Namespace != null).InstancePerDependency();

            // SQL e dados
            builder.Register(context => new Dados(connectionString, true)).As<IDados>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(GestorDados)))
                .Where(t => t.Namespace != null && t.Namespace.Contains(nameof(GestorDados.Helpers.Entidades)))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Base Helpers
            builder.RegisterType<JsonHelper>().As<IJsonHelper>().SingleInstance();
            builder.Register(c => new HttpHelper(c.Resolve<IJsonHelper>(), urlBase)).As<IHttpHelper>().InstancePerLifetimeScope();

            // Forms e UserControls
            builder.RegisterType<MainForm>().SingleInstance();

            //Regista os editores com o nome da classe correspondente
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
                .Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls.Configuracoes.Editores)))
                .Keyed<XtraUserControl>((tipo) =>
                {
                    return tipo.Name.Replace("EditorUserControl", string.Empty);
                }).InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
                .Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls))).InstancePerDependency().PreserveExistingDefaults();

            //Helpers
            builder.RegisterType<ConfiguracoesEntidadesHelper>().InstancePerLifetimeScope();

            //Utils
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Utils))).Where(t => t.Namespace != null).SingleInstance();

            return builder.Build();
        }
    }
}
