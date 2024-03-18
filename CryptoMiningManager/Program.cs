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

            using (Dados = new Dados(ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString, true))
            {

                //SerilogHelper.StartLogger(ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString);

                //SerilogHelper.EscreveLog(GestorDados.Enums.SerilogLevel.Information, "TESTE");

                using (IContainer container = ContainerConfig())
                using (ILifetimeScope scope = container.BeginLifetimeScope())
                {
                    Application.Run(scope.Resolve<MainForm>());
                }
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

            //Regista todas as classes dentro do namespace LeadingIntegradorErp.*.Views.UserControls.* como Instance Per Dependency.
            //É o equivalente ao Transient da Microsoft e é a opção default, por isso não é preciso especificar com o método InstancePerDependency()
            //PreserveExistingDefaults() previne overrides aos registos anteriores (sem isso o registo do LoginUserControl como singleton seria substituído)
            //Usar o nameof() facilita no caso de se alterar o namespace e ajuda a prevenir erros de escrita (IntelliSense)
            //É preciso a validação "t.Namespace != null" por causa do Costura/Fody
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(LeadingIntegradorErp)))
                .Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views) + '.' + nameof(Views.UserControls))).InstancePerDependency().PreserveExistingDefaults();

            // Views Helpers
            builder.RegisterType<EntidadesHelper>().InstancePerDependency();

            //É possível juntar isto ao código de cima, mas caso haja alguma alteração de namespaces ou
            //algo parecido a uma alteração geral nos parâmetros dos helpers, tornam-se menos claros os ajustes que se têm de fazer
            //Poderia ser: Where(t => t.Namespace.Contains("Views.UserControls") || t.Namespace.EndsWith("Helpers"));
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(LeadingIntegradorErp)))
                .Where(t => t.Namespace != null && t.Namespace.EndsWith(nameof(Helpers))).InstancePerDependency().PreserveExistingDefaults();

            // Utils
            builder.Register((context, parameters) => new StringEnum(parameters.TypedAs<Type>())).InstancePerDependency();

            // Comparadores (maioritariamente para ser usado nos Dictionary<TKey, TValue> com classes Xpo)
            builder.RegisterType<PagamentoEqualityComparer>().As<IEqualityComparer<Pagamento>>().SingleInstance();

            return builder.Build();
        }
    }
}
