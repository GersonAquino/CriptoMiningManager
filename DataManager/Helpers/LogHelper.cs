using Models.Enums;
using Serilog;
using Serilog.Debugging;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace DataManager.Helpers;

public class LogHelper
{
	private static readonly Semaphore FileSemaphore = new(1, 1);

	/// <summary>
	/// Instancia o Logger e define como lidar com erros internos (do Serilog)
	/// </summary>
	/// <param name="connectionString"></param>
	public static void StartLogger(string connectionString)
	{
		SelfLog.Enable(msg =>
		{
			//Espera até 1 minuto para escrever a mensagem
			if (!FileSemaphore.WaitOne(60000))
				return;

			try
			{
				//Escreve os erros do próprio Serilog para o ficheiro SerilogExceptions
				using StreamWriter streamWriter = new("SerilogExceptions.txt", true);
				try
				{
					StringBuilder sbProperties = new();
					foreach (object property in SetProperties())
					{
						sbProperties.Append($"{property} ");
					}
					streamWriter.WriteLine($"{sbProperties}{Environment.NewLine}{msg}{Environment.NewLine}");
				}
				catch (Exception ex)
				{
					streamWriter.WriteLine($"{msg}{Environment.NewLine}Erro a construir mensagem de erro interno: {ex.Message}{Environment.NewLine}");
				}
			}
			finally
			{
				FileSemaphore.Release();
			}

			//Se não se limpar o logger, ele vai continuar a tentar escrever o mesmo log periodicamente e a ter sempre o mesmo erro,
			//logo vai encher o ficheiro com informação repetida e desnecessária
			if (msg.Contains("Unable to write batch"))
			{
				Log.CloseAndFlush();
				InstantiateLogger(connectionString);
			}
		});

		InstantiateLogger(connectionString);
	}

	public static void StopLogger()
	{
		Log.CloseAndFlush();
	}

	/// <summary>
	/// Escreve um log na base de dados. Não regista <see cref="Exception"/>.
	/// <para>Caso <see cref="Enums.LogLevel"/> recebido não exista faz throw de <see cref="ArgumentException"/> e escreve um log com a mensagem recebida e <see cref="Enums.LogLevel.Fatal"/></para>
	/// </summary>
	/// <param name="level"></param>
	/// <param name="messageTemplate"></param>
	/// <param name="extraProperties"></param>
	/// <exception cref="ArgumentException"></exception>
	public static void WriteLog(LogLevel level, string messageTemplate, params object[] extraProperties)
	{
		string finalMessageTemplate = messageTemplate + " - {Modulo} | {NameMaquina} | {Versao}";
		object[] properties = SetProperties(extraProperties);

		switch (level)
		{
			case LogLevel.Debug:
#if DEBUG
				Log.Debug(finalMessageTemplate, properties);
#endif
				break;

			case LogLevel.Information:
				Log.Information(finalMessageTemplate, properties);
				break;
			case LogLevel.Warning:
				Log.Warning(finalMessageTemplate, properties);
				break;
			case LogLevel.Error:
				Log.Error(finalMessageTemplate, properties);
				break;
			case LogLevel.Fatal:
				Log.Fatal(finalMessageTemplate, properties);
				break;
			default:
				WriteLog(LogLevel.Fatal, string.Concat("SerilogLevel inválido introduzido!",
					"Será escrito um log com SerilogLevel.Error e mensagem recebida, de seguida será feito o throw de ArgumentException."));
				WriteLog(LogLevel.Error, finalMessageTemplate, properties);
				throw new ArgumentException("SerilogLevel inválido!");
		}
	}

	/// <summary>
	/// Escreve um log na base de dados. Regista a <see cref="Exception"/> recebida. 
	/// <para>Caso <see cref="Enums.LogLevel"/> recebido não exista faz throw de <see cref="ArgumentException"/> e escreve um log com <see cref="Enums.LogLevel.Fatal"/></para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="level"></param>
	/// <param name="exception"></param>
	/// <param name="messageTemplate"></param>
	/// <param name="extraProperties"></param>
	/// <exception cref="ArgumentException"></exception>
	public static void WriteExceptionLog<T>(LogLevel level, T exception, string messageTemplate, params object[] extraProperties) where T : Exception
	{
		string finalMessageTemplate = string.Concat(messageTemplate, " - {Modulo} | {NameMaquina} | {Versao}");
		object[] properties = SetProperties(extraProperties);

		switch (level)
		{
			case LogLevel.Debug:
#if DEBUG
				Log.Debug(exception.GetBaseException(), finalMessageTemplate, properties);
#endif
				break;
			case LogLevel.Information:
				Log.Information(exception.GetBaseException(), finalMessageTemplate, properties);
				break;
			case LogLevel.Warning:
				Log.Warning(exception.GetBaseException(), finalMessageTemplate, properties);
				break;
			case LogLevel.Error:
				Log.Error(exception.GetBaseException(), finalMessageTemplate, properties);
				break;
			case LogLevel.Fatal:
				Log.Fatal(exception.GetBaseException(), finalMessageTemplate, properties);
				break;
			default:
				WriteLog(LogLevel.Fatal, string.Concat("SerilogLevel inválido introduzido!",
					"Será escrito um log com SerilogLevel.Error e a exceção e mensagem recebidas, de seguida será feito o throw de ArgumentException."));

				WriteExceptionLog(LogLevel.Error, exception, finalMessageTemplate, properties);
				throw new ArgumentException("SerilogLevel inválido!");
		}
	}

	//MÉTODOS AUXILIARES
	private static void InstantiateLogger(string connectionString)
	{
		Log.Logger = new LoggerConfiguration()
#if DEBUG
			.MinimumLevel.Debug() //MinimumLevel.Debug() serve para escrever os Log.Debug() na BD tbm, mais nada
#endif
			//.ReadFrom.AppSettings()
			.WriteTo.SQLite(connectionString)
			.CreateLogger();
	}

	/// <summary>
	/// Define as propriedades default a serem guardadas no log: módulo, nome da máquina, utilizador e versão da aplicação. 
	/// Devolve object[] em vez de string[] para facilitar o uso dos métodos de log do Serilog
	/// </summary>
	/// <param name="extraProperties"></param>
	/// <returns>object[propriedadesExtra.Length + 3] -> 0: Modulo 1: NameMaquina 2: Versao</returns>
	private static object[] SetProperties(object[] extraProperties = null)
	{
		Type classType = new StackTrace().GetFrame(2).GetMethod().DeclaringType;
		string[] assembly = Assembly.GetAssembly(classType).FullName.Split(',');

		int extraPropsLength = extraProperties?.Length ?? 0;
		object[] properties = new object[extraPropsLength + 3];

		extraProperties?.CopyTo(properties, 0);

		new object[] {
			$"{assembly[0]}.{classType.Name}",
			Environment.MachineName,
			assembly[1].Split('=')[1] }.CopyTo(properties, extraPropsLength);

		return properties;
	}
}
