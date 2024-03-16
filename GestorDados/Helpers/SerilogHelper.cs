using GestorDados.Enums;
using Serilog;
using Serilog.Debugging;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace GestorDados.Helpers
{
    public class SerilogHelper
    {
        /// <summary>
        /// Instancia o Logger e define como lidar com erros internos (do Serilog)
        /// </summary>
        /// <param name="connectionString"></param>
        public static void StartLogger(string connectionString)
        {
            SelfLog.Enable(msg =>
            {
                //Escreve os erros do próprio Serilog para o ficheiro SerilogExceptions
                using (StreamWriter streamWriter = new StreamWriter("SerilogExceptions.txt", true))
                {
                    try
                    {
                        StringBuilder sbPropriedades = new StringBuilder();
                        foreach (object propriedade in SetPropriedades())
                        {
                            sbPropriedades.Append($"{propriedade} ");
                        }
                        streamWriter.WriteLine($"{sbPropriedades}{Environment.NewLine}{msg}{Environment.NewLine}");
                    }
                    catch (Exception ex)
                    {
                        streamWriter.WriteLine($"{msg}{Environment.NewLine}Erro a construir mensagem de erro interno: {ex.Message}{Environment.NewLine}");
                    }
                }
                //Se não se limpar o logger, ele vai continuar a tentar escrever o mesmo log periodicamente e a ter sempre o mesmo erro,
                //logo vai encher o ficheiro com informação repetida e desnecessária
                if (msg.Contains("Unable to write batch"))
                {
                    Log.CloseAndFlush();
                    InstanciarLogger(connectionString);
                }
            });

            InstanciarLogger(connectionString);
        }

        public static void StopLogger()
        {
            Log.CloseAndFlush();
        }

        /// <summary>
        /// Escreve um log na base de dados. Não regista <see cref="Exception"/>.
        /// <para>Caso <see cref="SerilogLevel"/> recebido não exista faz throw de <see cref="ArgumentException"/> e escreve um log com a mensagem recebida e <see cref="SerilogLevel.Fatal"/></para>
        /// </summary>
        /// <param name="level"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="propriedadesExtra"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void EscreveLog(SerilogLevel level, string messageTemplate, params object[] propriedadesExtra)
        {
            string messageTemplateFinal = messageTemplate + " - {Modulo} | {NomeMaquina} | {User} | {Versao}";
            object[] propriedades = SetPropriedades(propriedadesExtra);

            switch (level)
            {
                case SerilogLevel.Debug:
#if DEBUG
                    Log.Debug(messageTemplateFinal, propriedades);
#endif
                    break;

                case SerilogLevel.Information:
                    Log.Information(messageTemplateFinal, propriedades);
                    break;
                case SerilogLevel.Warning:
                    Log.Warning(messageTemplateFinal, propriedades);
                    break;
                case SerilogLevel.Error:
                    Log.Error(messageTemplateFinal, propriedades);
                    break;
                case SerilogLevel.Fatal:
                    Log.Fatal(messageTemplateFinal, propriedades);
                    break;
                default:
                    EscreveLog(SerilogLevel.Fatal, string.Concat("SerilogLevel inválido introduzido!",
                        "Será escrito um log com SerilogLevel.Error e mensagem recebida, de seguida será feito o throw de ArgumentException."));
                    EscreveLog(SerilogLevel.Error, messageTemplateFinal, propriedades);
                    throw new ArgumentException("SerilogLevel inválido!");
            }
        }

        /// <summary>
        /// Escreve um log na base de dados. Regista a <see cref="Exception"/> recebida. 
        /// <para>Caso <see cref="SerilogLevel"/> recebido não exista faz throw de <see cref="ArgumentException"/> e escreve um log com <see cref="SerilogLevel.Fatal"/></para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="propriedadesExtra"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void EscreveLogException<T>(SerilogLevel level, T exception, string messageTemplate, params object[] propriedadesExtra) where T : Exception
        {
            string messageTemplateFinal = string.Concat(messageTemplate, " - {Modulo} | {NomeMaquina} | {Versao}");
            object[] propriedades = SetPropriedades(propriedadesExtra);

            switch (level)
            {
                case SerilogLevel.Debug:
#if DEBUG
                    Log.Debug(exception.GetBaseException(), messageTemplateFinal, propriedades);
#endif
                    break;

                case SerilogLevel.Information:
                    Log.Information(exception.GetBaseException(), messageTemplateFinal, propriedades);
                    break;
                case SerilogLevel.Warning:
                    Log.Warning(exception.GetBaseException(), messageTemplateFinal, propriedades);
                    break;
                case SerilogLevel.Error:
                    Log.Error(exception.GetBaseException(), messageTemplateFinal, propriedades);
                    break;
                case SerilogLevel.Fatal:
                    Log.Fatal(exception.GetBaseException(), messageTemplateFinal, propriedades);
                    break;
                default:
                    EscreveLog(SerilogLevel.Fatal, string.Concat("SerilogLevel inválido introduzido!",
                        "Será escrito um log com SerilogLevel.Error e a exceção e mensagem recebidas, de seguida será feito o throw de ArgumentException."));

                    EscreveLogException(SerilogLevel.Error, exception, messageTemplateFinal, propriedades);
                    throw new ArgumentException("SerilogLevel inválido!");
            }
        }

        //FUNÇÕES AUXILIARES
        private static void InstanciarLogger(string connectionString)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug() //MinimumLevel.Debug() serve para escrever os Log.Debug() na BD tbm, mais nada
#endif
                //.ReadFrom.()
                .WriteTo.SQLite(connectionString)
                .CreateLogger();
        }

        /// <summary>
        /// Define as propriedades default a serem guardadas no log: módulo, nome da máquina, utilizador e versão da aplicação. 
        /// Devolve object[] em vez de string[] para facilitar o uso dos métodos de log do Serilog
        /// </summary>
        /// <param name="propriedadesExtra"></param>
        /// <returns>object[4] -> 0: Modulo 1: NomeMaquina 2: User 3: Versao</returns>
        private static object[] SetPropriedades(object[] propriedadesExtra = null)
        {
            Type classe = new StackTrace().GetFrame(2).GetMethod().DeclaringType;
            string[] assembly = Assembly.GetAssembly(classe).FullName.Split(',');

            int propsExtraLength = propriedadesExtra?.Length ?? 0;
            object[] propriedades = new object[propsExtraLength + 4];

            propriedadesExtra?.CopyTo(propriedades, 0);

            new object[] {
                assembly[0] + '.' + classe.Name,
                Environment.MachineName,
                assembly[1].Split('=')[1] }.CopyTo(propriedades, propsExtraLength);

            return propriedades;
        }
    }
}
