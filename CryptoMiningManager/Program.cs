using Autofac;
using CryptoMiningManager.CustomControls;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views;
using DevExpress.XtraEditors;
using GestorDados;
using GestorDados.Helpers;
using Modelos.Interfaces;
using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
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
		[RequiresAssemblyFiles("Calls System.Reflection.Assembly.Location")]
		private static async Task Main(string[] args)
		{
			#region JIT Improve
			Assembly assembly = Assembly.GetExecutingAssembly();

			ProfileOptimization.SetProfileRoot(Path.GetDirectoryName(assembly.Location));
			ProfileOptimization.StartProfile(assembly.GetName().Name);
			#endregion JIT Improve

			LogHelper.StartLogger();

			try
			{
				bool isBackgroundOnly = args?.Length == 1 && args[0].Equals("-backgroundonly", StringComparison.CurrentCultureIgnoreCase);
				if (!isBackgroundOnly)
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
				}

				using (IContainer container = isBackgroundOnly ? ContainerConfig_SemUI() : ContainerConfig_ComUI())
				await using (ILifetimeScope scope = container.BeginLifetimeScope())
				{
					scope.Resolve<CustomNotifyIcon>().NotifyIcon.Icon = Icon.ExtractAssociatedIcon(assembly.Location);
					if (isBackgroundOnly)
					{
						SemUIHelper semUi = scope.Resolve<SemUIHelper>();
						await semUi.Inicializar();

						Application.Run(semUi);
					}
					else
						Application.Run(scope.Resolve<MainForm>());
				}
			}
			finally
			{
				LogHelper.StopLogger();
			}
		}

		private static ContainerBuilder ContainerConfig_Base()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString;

			ContainerBuilder builder = new();
			Type tipoString = typeof(string);
			//Modelos
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(Modelos))).Where(t => t.Namespace != null).InstancePerDependency();

			//SQL e dados
			builder.RegisterType<Dados>().WithParameters([new TypedParameter(tipoString, connectionString), TypedParameter.From(true)])
				.As<IDados>().InstancePerLifetimeScope();
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(GestorDados)))
				.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(GestorDados.Helpers.Entidades)))
				.AsImplementedInterfaces().InstancePerLifetimeScope();

			//Helpers Base
			builder.RegisterType<JsonHelper>().As<IJsonHelper>().SingleInstance();
			builder.RegisterType<HttpHelper>().WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["URLRentabilidade"]))
				.As<IHttpHelper>().InstancePerLifetimeScope();
			builder.RegisterType<Inicializador>().SingleInstance();

			//Helpers Mineração
			//TODO: Passar LocalizacaoLogsMineracao para Configurações Gerais, ou talvez criar Configurações Mineração e meter lá o URLRentabilidade também
			builder.RegisterType<MineracaoHelper>().WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["LocalizacaoLogsMineracao"])).SingleInstance();

			//Taskbar Icon
			builder.RegisterType<CustomNotifyIcon>().SingleInstance();

			//Utils
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(Utils))).Where(t => t.Namespace != null).SingleInstance();

			return builder;
		}

		private static IContainer ContainerConfig_ComUI()
		{
			ContainerBuilder builder = ContainerConfig_Base();

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

		private static IContainer ContainerConfig_SemUI()
		{
			ContainerBuilder builder = ContainerConfig_Base();

			builder.RegisterType<SemUIHelper>().SingleInstance();

			return builder.Build();
		}
	}
}
