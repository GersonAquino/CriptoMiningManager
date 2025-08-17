using Autofac;
using Autofac.Core;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views;
using CryptoMiningManager.Views.UserControls.Main;
using DataManager;
using DataManager.Helpers;
using DevExpress.XtraEditors;
using Models.Interfaces;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Windows.Forms;

namespace CryptoMiningManager;

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

		string connectionString = ConfigurationManager.ConnectionStrings["CriptoManager"].ConnectionString;

		LogHelper.StartLogger(connectionString.Split('=')[1]);

		try
		{
			using IContainer container = ContainerConfig(connectionString);
			using ILifetimeScope scope = container.BeginLifetimeScope();
			Application.Run(scope.Resolve<MainForm>());
		}
		finally
		{
			LogHelper.StopLogger();
		}
	}

	private static IContainer ContainerConfig(string connectionString)
	{
		ContainerBuilder builder = new();

		Type tipoString = typeof(string);

		//Models
		builder.RegisterAssemblyTypes(Assembly.Load(nameof(Models))).Where(t => t.Namespace != null).InstancePerDependency();

		// SQL e dados
		builder.RegisterType<Dados>().WithParameters(new Parameter[] { new TypedParameter(tipoString, connectionString), TypedParameter.From(true) })
			.As<IData>().InstancePerLifetimeScope();
		builder.Register(context => new Dados(connectionString, true)).As<IData>().InstancePerLifetimeScope();
		builder.RegisterAssemblyTypes(Assembly.Load(nameof(DataManager)))
			.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(DataManager.Helpers.Entities)))
			.AsImplementedInterfaces().InstancePerLifetimeScope();

		// Base Helpers
		builder.RegisterType<JsonHelper>().As<IJsonHelper>().SingleInstance();
		builder.RegisterType<HttpHelper>().WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["URLRentabilidade"]))
			.As<IHttpHelper>().InstancePerLifetimeScope();

		// Forms e UserControls
		builder.RegisterType<MainForm>().SingleInstance();

		//Regista os editores com o nome da classe correspondente //Nota: Os editores devem ser formados por NameClasse + "EditorUserControl"
		builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
			.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls.Configurations.Editors)))
			.Keyed<XtraUserControl>((tipo) => tipo.Name.Replace("EditorUserControl", string.Empty)).InstancePerDependency().PreserveExistingDefaults();

		builder.RegisterType<AutomaticMiningManagerUserControl>()
			.WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["LocationLogsMineracao"])).InstancePerDependency();

		builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
			.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls))).InstancePerDependency().PreserveExistingDefaults();

		//Helpers
		builder.RegisterType<EntityConfigurationHelper>().InstancePerLifetimeScope();

		//Utils
		builder.RegisterAssemblyTypes(Assembly.Load(nameof(Utils))).Where(t => t.Namespace != null).SingleInstance();

		return builder.Build();
	}
}
