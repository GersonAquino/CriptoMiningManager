using Autofac;
using Autofac.Core;
using CryptoMiningManager.CustomControls;
using CryptoMiningManager.Helpers;
using CryptoMiningManager.Views;
using CryptoMiningManager.Views.UserControls.Funcionalidades;
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
using System.Windows.Forms;

namespace CryptoMiningManager
{
	internal static class Program
	{
		/// <summary>   
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main() //string[] args
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
				using (IContainer container = ContainerConfig(connectionString))
				using (ILifetimeScope scope = container.BeginLifetimeScope())
				{
					scope.Resolve<CustomNotifyIcon>().NotifyIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

					Application.Run(scope.Resolve<MainForm>());
				}
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

			//Modelos
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(Modelos))).Where(t => t.Namespace != null).InstancePerDependency();

			//SQL e dados
			builder.RegisterType<Dados>().WithParameters(new Parameter[] { new TypedParameter(tipoString, connectionString), TypedParameter.From(true) })
				.As<IDados>().InstancePerLifetimeScope();
			builder.Register(context => new Dados(connectionString, true)).As<IDados>().InstancePerLifetimeScope();
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(GestorDados)))
				.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(GestorDados.Helpers.Entidades)))
				.AsImplementedInterfaces().InstancePerLifetimeScope();

			//Base Helpers
			builder.RegisterType<JsonHelper>().As<IJsonHelper>().SingleInstance();
			builder.RegisterType<HttpHelper>().WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["URLRentabilidade"]))
				.As<IHttpHelper>().InstancePerLifetimeScope();

			//Forms e UserControls
			builder.RegisterType<MainForm>().SingleInstance();

			//Regista os editores com o nome da classe correspondente //Nota: Os editores devem ser formados por NomeClasse + "EditorUserControl"
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
				.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls.Configuracoes.Editores)))
				.Keyed<XtraUserControl>((tipo) => tipo.Name.Replace("EditorUserControl", string.Empty)).InstancePerDependency().PreserveExistingDefaults();

			//builder.RegisterType<GestaoAutomaticaMineracaoUserControl>().InstancePerDependency();

			builder.RegisterAssemblyTypes(Assembly.Load(nameof(CryptoMiningManager)))
				.Where(t => t.Namespace != null && t.Namespace.Contains(nameof(Views.UserControls))).InstancePerDependency().PreserveExistingDefaults();

			//Helpers
			builder.RegisterType<ConfiguracoesEntidadesHelper>().InstancePerLifetimeScope();
			builder.RegisterType<MineracaoHelper>().WithParameter(new TypedParameter(tipoString, ConfigurationManager.AppSettings["LocalizacaoLogsMineracao"])).SingleInstance();

			//Taskbar Icon
			builder.RegisterType<CustomNotifyIcon>().SingleInstance();

			//Utils
			builder.RegisterAssemblyTypes(Assembly.Load(nameof(Utils))).Where(t => t.Namespace != null).SingleInstance();

			return builder.Build();
		}
	}
}
