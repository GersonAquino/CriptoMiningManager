using Autofac;
using Autofac.Core;
using CryptoMiningManager.CustomControls;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views;
using DevExpress.XtraEditors;
using GestorDados;
using GestorDados.Helpers;
using Modelos.Interfaces;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMiningManager
{
	internal static class Program
	{
		/// <summary>   
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static async Task Main(string[] args)
		{
			#region JIT Improve
			Assembly assembly = Assembly.GetExecutingAssembly();

			ProfileOptimization.SetProfileRoot(Path.GetDirectoryName(assembly.Location));
			ProfileOptimization.StartProfile(assembly.GetName().Name);
			#endregion JIT Improve

			string connectionString = ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString;
			LogHelper.StartLogger(connectionString.Split('=', 3)[1]);

			try
			{
				bool isBackgroundOnly = args?.Length == 1 && args[0].ToLower() == "-backgroundonly"; //TODO: Melhorar a forma de ler parâmetros
				using (IContainer container = isBackgroundOnly ? ContainerConfig_SemUI(connectionString) : ContainerConfig_ComUI(connectionString)) //TODO: Por agora registam-se todas as classes na mesma, mas devem-se reduzir as classes depois
				using (ILifetimeScope scope = container.BeginLifetimeScope())
				{
					scope.Resolve<CustomNotifyIcon>().NotifyIcon.Icon = Icon.ExtractAssociatedIcon(assembly.Location);
					if (isBackgroundOnly)
					{
						SemUIHelper semUi = scope.Resolve<SemUIHelper>();
						await semUi.Inicializar();

						Application.Run(semUi);
					}
					else
					{
						Application.EnableVisualStyles();
						Application.SetCompatibleTextRenderingDefault(false);

						Application.Run(scope.Resolve<MainForm>());
					}
				}
			}
			finally
			{
				LogHelper.StopLogger();
			}
		}

		private static ContainerBuilder ContainerConfig_Base(string connectionString)
		{
			ContainerBuilder builder = new();
			Type tipoString = typeof(string);
			//Modelos
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(Modelos))).Where(t => t.Namespace != null).InstancePerDependency();

			//SQL e dados
			builder.RegisterType<Dados>().WithParameters(new Parameter[] { new TypedParameter(tipoString, connectionString), TypedParameter.From(true) })
				.As<IDados>().InstancePerLifetimeScope();
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(GestorDados)))
				.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(GestorDados.Helpers.Entidades)))
				.AsImplementedInterfaces().InstancePerLifetimeScope();

			//Base Helpers
			builder.RegisterType<JsonHelper>().As<IJsonHelper>().SingleInstance();
			builder.RegisterType<HttpHelper>().WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["URLRentabilidade"]))
				.As<IHttpHelper>().InstancePerLifetimeScope();

			//Mining Helpers
			//TODO: Passar LocalizacaoLogsMineracao para Configurações Gerais, ou talvez criar Configurações Mineração e meter lá o URLRentabilidade também
			builder.RegisterType<MineracaoHelper>().WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["LocalizacaoLogsMineracao"])).SingleInstance();

			//Taskbar Icon
			builder.RegisterType<CustomNotifyIcon>().SingleInstance();

			//Utils
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(Utils))).Where(t => t.Namespace != null).SingleInstance();

			return builder;
		}

		private static IContainer ContainerConfig_ComUI(string connectionString)
		{
			ContainerBuilder builder = ContainerConfig_Base(connectionString);

			//Forms e UserControls
			builder.RegisterType<MainForm>().SingleInstance();

			//Regista os editores com o nome da classe correspondente //Nota: Os editores devem ser formados por NomeClasse + "EditorUserControl"
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
				.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls.Configuracoes.Editores)))
				.Keyed<XtraUserControl>((tipo) => tipo.Name.Replace("EditorUserControl", string.Empty)).InstancePerDependency().PreserveExistingDefaults();

			builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
				.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls))).InstancePerDependency().PreserveExistingDefaults();

			//UI Helpers
			builder.RegisterType<ConfiguracoesEntidadesHelper>().InstancePerLifetimeScope();


			return builder.Build();
		}

		private static IContainer ContainerConfig_SemUI(string connectionString)
		{
			ContainerBuilder builder = ContainerConfig_Base(connectionString);

			builder.RegisterType<SemUIHelper>().SingleInstance(); //TODO: Isto deve passar para um método exclusivo mais tarde

			return builder.Build();
		}
	}
}
