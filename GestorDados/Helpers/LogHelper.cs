using Modelos.Enums;
using Serilog;
using Serilog.Debugging;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace GestorDados.Helpers
{
	public class LogHelper
	{
		private static readonly Semaphore SemaforoFicheiro = new(1, 1);

		/// <summary>
		/// Instancia o Logger e define como lidar com erros internos (do Serilog)
		/// </summary>
		/// <param name="connectionString"></param>
		public static void StartLogger()
		{
			SelfLog.Enable(msg =>
			{
				//Espera até 1 minuto para escrever a mensagem
				if (msg.Contains("Sending batch of ") || !SemaforoFicheiro.WaitOne(60000))
					return;

				try
				{
					//Escreve os erros do próprio Serilog para o ficheiro SerilogExceptions
					using (StreamWriter streamWriter = new("SerilogExceptions.txt", true))
					{
						try
						{
							StringBuilder sbPropriedades = new();
							object[] propriedades = SetPropriedades();
							for (int i = 0; i < propriedades.Length; i++)
							{
								sbPropriedades.Append(propriedades[i]).Append(' ');
							}

							streamWriter.WriteLine(sbPropriedades.AppendLine().AppendLine(msg));
						}
						catch (Exception ex)
						{
							streamWriter.WriteLine($"{msg}{Environment.NewLine}Erro a construir mensagem de erro interno: {ex.Message}{Environment.NewLine}");
						}
					}
				}
				finally
				{
					SemaforoFicheiro.Release();
				}

				//Se não se limpar o logger, ele vai continuar a tentar escrever o mesmo log periodicamente e a ter sempre o mesmo erro,
				//logo vai encher o ficheiro com informação repetida e desnecessária
				if (msg.Contains("Unable to write batch"))
				{
					Log.CloseAndFlush();
					InstanciarLogger();
				}
			});

			InstanciarLogger();
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
		/// <param name="propriedadesExtra"></param>
		/// <exception cref="ArgumentException"></exception>
		public static void EscreveLog(LogLevel level, string messageTemplate, params object[] propriedadesExtra)
		{
			string messageTemplateFinal = messageTemplate + " - {Modulo} | {NomeMaquina} | {Versao}";
			object[] propriedades = SetPropriedades(propriedadesExtra);

			switch (level)
			{
				case LogLevel.Debug:
#if DEBUG
					Log.Debug(messageTemplateFinal, propriedades);
#endif
					break;

				case LogLevel.Information:
					Log.Information(messageTemplateFinal, propriedades);
					break;
				case LogLevel.Warning:
					Log.Warning(messageTemplateFinal, propriedades);
					break;
				case LogLevel.Error:
					Log.Error(messageTemplateFinal, propriedades);
					break;
				case LogLevel.Fatal:
					Log.Fatal(messageTemplateFinal, propriedades);
					break;
				default:
					EscreveLog(LogLevel.Fatal, string.Concat("SerilogLevel inválido introduzido!",
						"Será escrito um log com SerilogLevel.Error e mensagem recebida, de seguida será feito o throw de ArgumentException."));
					EscreveLog(LogLevel.Error, messageTemplateFinal, propriedades);
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
		/// <param name="propriedadesExtra"></param>
		/// <exception cref="ArgumentException"></exception>
		public static void EscreveLogException<T>(LogLevel level, T exception, string messageTemplate, params object[] propriedadesExtra) where T : Exception
		{
			string messageTemplateFinal = string.Concat(messageTemplate, " - {Modulo} | {NomeMaquina} | {Versao}");
			object[] propriedades = SetPropriedades(propriedadesExtra);

			switch (level)
			{
				case LogLevel.Debug:
#if DEBUG
					Log.Debug(exception.GetBaseException(), messageTemplateFinal, propriedades);
#endif
					break;
				case LogLevel.Information:
					Log.Information(exception.GetBaseException(), messageTemplateFinal, propriedades);
					break;
				case LogLevel.Warning:
					Log.Warning(exception.GetBaseException(), messageTemplateFinal, propriedades);
					break;
				case LogLevel.Error:
					Log.Error(exception.GetBaseException(), messageTemplateFinal, propriedades);
					break;
				case LogLevel.Fatal:
					Log.Fatal(exception.GetBaseException(), messageTemplateFinal, propriedades);
					break;
				default:
					EscreveLog(LogLevel.Fatal, string.Concat("SerilogLevel inválido introduzido!",
						"Será escrito um log com SerilogLevel.Error e a exceção e mensagem recebidas, de seguida será feito o throw de ArgumentException."));

					EscreveLogException(LogLevel.Error, exception, messageTemplateFinal, propriedades);
					throw new ArgumentException("SerilogLevel inválido!");
			}
		}

		//MÉTODOS AUXILIARES
		private static void InstanciarLogger()
		{
			Log.Logger = new LoggerConfiguration()
#if DEBUG
				.MinimumLevel.Debug() //MinimumLevel.Debug() serve para escrever os Log.Debug() na BD tbm, mais nada
#endif
				.ReadFrom.AppSettings()
				.CreateLogger();
		}

		/// <summary>
		/// Define as propriedades default a serem guardadas no log: módulo, nome da máquina, utilizador e versão da aplicação. 
		/// Devolve object[] em vez de string[] para facilitar o uso dos métodos de log do Serilog
		/// </summary>
		/// <param name="propriedadesExtra"></param>
		/// <returns>object[propriedadesExtra.Length + 3] -> 0: Modulo 1: NomeMaquina 2: Versao</returns>
		private static object[] SetPropriedades(object[] propriedadesExtra = null)
		{
			Type classe = new StackTrace().GetFrame(2).GetMethod().DeclaringType;
			string[] assembly = Assembly.GetAssembly(classe).FullName.Split(',');

			int propsExtraLength = propriedadesExtra?.Length ?? 0;
			object[] propriedades = new object[propsExtraLength + 3];

			propriedadesExtra?.CopyTo(propriedades, 0);

			new object[] {
				$"{assembly[0]}.{classe.Name}",
				Environment.MachineName,
				assembly[1].Split('=')[1] }.CopyTo(propriedades, propsExtraLength);

			return propriedades;
		}
	}
}
