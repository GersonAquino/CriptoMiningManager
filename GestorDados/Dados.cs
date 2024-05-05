using Dapper;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestorDados
{
    public class Dados : IDados
    {
        private IDbConnection Conexao = null;
        private IDbTransaction Transacao = null;
        private string ConnectionString;

        public Dados(string connectionString = null, bool iniciarConexao = false)
        {
            ConnectionString = connectionString;

            if (iniciarConexao)
            {
                Conexao = new SQLiteConnection(connectionString);
                Conexao.Open();
            }
        }

        #region Conexões
        ///<inheritdoc/>
        public void IniciarConexao(string connectionString = null)
        {
            FecharConexao();

            if (!string.IsNullOrWhiteSpace(connectionString))
                ConnectionString = connectionString;
            else if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new ArgumentException("Não é possível inicar uma conexão sem uma connection string!");

            Conexao = new SQLiteConnection(ConnectionString);
            Conexao.Open();
        }

        ///<inheritdoc/>
        public void FecharConexao()
        {
            if (Conexao != null)
            {
                DesfazTransacao();

                Conexao.Close();
                Conexao.Dispose();
            }
        }
        #endregion

        #region Transações
        ///<inheritdoc/>
        public void IniciarTransacao()
        {
            DesfazTransacao();

            Transacao = Conexao.BeginTransaction();
        }

        ///<inheritdoc/>
        public void DesfazTransacao()
        {
            if (Transacao != null)
            {
                Transacao.Rollback();
                Transacao.Dispose();
            }
        }

        ///<inheritdoc/>
        public void TerminaTransacao()
        {
            if (Transacao != null)
            {
                Transacao.Commit();
                Transacao.Dispose();
            }
        }
        #endregion

        ///<inheritdoc/>
        public async Task<int> ExecuteOpenAsync(string query)
        {
            return await Conexao.ExecuteAsync(query, transaction: Transacao);
        }

        ///<inheritdoc/>
        public async Task<int> ExecuteOpenAsync<T>(string query, T parametros)
        {
            return await Conexao.ExecuteAsync(query, parametros, transaction: Transacao);
        }

        ///<inheritdoc/>
        public async Task<T> ExecuteScalarOpenAsync<T>(string query)
        {
            return await Conexao.ExecuteScalarAsync<T>(query, transaction: Transacao);
        }

        ///<inheritdoc/>
        public async Task<T> ExecuteScalarOpenAsync<T, P>(string query, P parametros)
        {
            return await Conexao.ExecuteScalarAsync<T>(query, parametros, Transacao);
        }

        ///<inheritdoc/>
        public async Task<T> GetValorOpenAsync<T>(string query)
        {
            return await Conexao.QueryFirstOrDefaultAsync<T>(query, transaction: Transacao);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<T>> QueryOpenAsync<T>(string query, object parametros = null)
        {
            return await Conexao.QueryAsync<T>(query, parametros, transaction: Transacao);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<T>> QueryOpenAsync<Entidade1, Entidade2, T>(string query, Func<Entidade1, Entidade2, T> mapeamento, string splitOn = "Id")
        {
            return await Conexao.QueryAsync(query, mapeamento, transaction: Transacao, splitOn: splitOn);
        }

        ///<inheritdoc/>
        public async Task<int> BulkMerge<T>(params T[] entidades) where T : class, new()
        {
            //Obter tabela alvo
            Type tipo = typeof(T);
            string tabela = tipo.GetCustomAttribute<TableAttribute>().Name ??
                throw new NotImplementedException($"{tipo.Name} não tem o atributo 'Table' implementado!");

            //Obter informação sobre chave primária - É autoincrement?
            string query =
                $@"SELECT CASE
                        WHEN sql LIKE '%AUTOINCREMENT%' THEN 1 ELSE 0
                    END AS 'Autoincrement'
                FROM sqlite_master
                WHERE type = 'table'
                AND name = '{tabela}'
                LIMIT 1";

            Task<bool> isAutoIncrementTask = ExecuteScalarOpenAsync<bool>(query);
            //isAutoIncrementTask.Start(); //Aparentemente o Start() já deve ser chamado pelo Dapper automaticamente e não é preciso chamá-lo aqui

            //Preparar variáveis usadas para o comando sql final
            StringBuilder sbFinal = new();
            DynamicParameters parametros = new();
            PropertyInfo[] propriedades = tipo.GetProperties();

            //Guardar todas as colunas exceto a chave primária
            List<PropertyInfo> colunas = new(propriedades.Length - 1);
            PropertyInfo chavePrimaria = null;
            Type notMapped = typeof(NotMappedAttribute);
            Type key = typeof(KeyAttribute);
            string baseUpdate = $"UPDATE {tabela} SET ";

            //Obter chave primária e definir colunas a inserir no Insert
            bool isAutoIncrement = await isAutoIncrementTask;
            StringBuilder sbInsertBase = new(isAutoIncrement ? "INSERT INTO " : "REPLACE INTO "); //REPLACE INTO é o mesmo que INSERT OR REPLACE INTO

            sbInsertBase.Append(tabela).Append(" (");

            for (int i = 0; i < propriedades.Length; i++)
            {
                PropertyInfo prop = propriedades[i];

                if (prop.IsDefined(notMapped) ||
                    !prop.PropertyType.IsPrimitive &&
                    prop.PropertyType != typeof(string) &&
                    prop.PropertyType != typeof(decimal) &&
                    prop.PropertyType != typeof(DateTime) &&
                    prop.PropertyType != typeof(char))
                {
                    continue;
                }

                //Se for chave primária
                if (prop.IsDefined(key))
                {
                    if (!isAutoIncrement)
                        sbInsertBase.Append(prop.Name).Append(", ");

                    chavePrimaria = prop;
                }
                else
                {
                    colunas.Add(prop);
                    sbInsertBase.Append(prop.Name).Append(", ");
                }
            }

            if (chavePrimaria == null)
                throw new NoNullAllowedException($"Chave primária da classe {tipo.Name} não encontrada!");

            string baseInsert = sbInsertBase.Remove(sbInsertBase.Length - 2, 2).Append(") VALUES (").ToString();
            object valorDefeitoChavePrimaria = chavePrimaria.GetValue(new T());

            Action<T, StringBuilder, DynamicParameters, string, List<PropertyInfo>, PropertyInfo, string, object, int> TratarIteracao =
                isAutoIncrement ? CriarComandoInsertOuUpdate : CriarComandoReplace_Aux;

            for (int i = 0; i < entidades.Length; i++)
            {
                TratarIteracao(entidades[i], sbFinal, parametros, baseUpdate, colunas, chavePrimaria, baseInsert, valorDefeitoChavePrimaria, i);
            }

            return await Conexao.ExecuteAsync(sbFinal.ToString(), parametros);
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            FecharConexao();
        }

        //MÉTODOS AUXILIARES
        /// <summary>
        /// Atribuir valor de uma coluna com base na <paramref name="propriedade"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        /// <param name="sbFinal"></param>
        /// <param name="parametros"></param>
        /// <param name="indice"></param>
        /// <param name="propriedade"></param>
        private static void AtribuirValorInsertOuReplace<T>(T entidade, StringBuilder sbFinal, DynamicParameters parametros, int indice, PropertyInfo propriedade) where T : class, new()
        {
            string parametro = $"@{propriedade.Name}{indice}";
            parametros.Add(parametro, propriedade.GetValue(entidade));
            sbFinal.Append(parametro).Append(", ");
        }

        /// <summary>
        /// Atribui todos os valores de <paramref name="colunas"/> às colunas SQL e termina o comando sql de <paramref name="sbFinal"/> com ");"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        /// <param name="sbFinal"></param>
        /// <param name="parametros"></param>
        /// <param name="colunas"></param>
        /// <param name="indice"></param>
        private static void AtribuirValoresInsertOuReplace<T>(T entidade, StringBuilder sbFinal, DynamicParameters parametros, List<PropertyInfo> colunas, int indice) where T : class, new()
        {
            colunas.ForEach(c => AtribuirValorInsertOuReplace(entidade, sbFinal, parametros, indice, c));
            sbFinal.Remove(sbFinal.Length - 2, 2).AppendLine(");");
        }

        /// <summary>
        /// Cria um comando INSERT ou UPDATE conforme o valor da chave primária.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade">Entidade a usar para os dados do comando</param>
        /// <param name="sbFinal">StringBuilder onde se vai acrescentar o comando</param>
        /// <param name="parametros">Objeto onde se registarão os parâmetros do comando</param>
        /// <param name="baseUpdate">String $"UPDATE {tabela} SET" para evitar criar uma nova string a cada iteração</param>
        /// <param name="colunas">A propriedade <see cref="MemberInfo.Name"/> será usada como nome das colunas da base de dados</param>
        /// <param name="chavePrimaria">A propriedade que guarda os dados da chave primária</param>
        /// <param name="baseInsert">String base do INSERT (tudo até à parte "VALUES (" inclusive)</param>
        /// <param name="valorDefeitoChavePrimaria"></param>
        /// <param name="indice">Indice da iteração para acrescentar aos nomes dos <paramref name="parametros"/> que serão criados</param>
        private static void CriarComandoInsertOuUpdate<T>(T entidade, StringBuilder sbFinal, DynamicParameters parametros, string baseUpdate, List<PropertyInfo> colunas,
            PropertyInfo chavePrimaria, string baseInsert, object valorDefeitoChavePrimaria, int indice) where T : class, new()
        {
            object valorChavePrimaria = chavePrimaria.GetValue(entidade);
            //Se a chave primária for o valor por defeito, faz um INSERT
            if (valorChavePrimaria.Equals(valorDefeitoChavePrimaria))
            {
                sbFinal.Append(baseInsert);

                //Isto só se faz se não for Autoincrement
                //sbFinal.Append(chavePrimaria.Name).Append(", ");
                //parametros.Add($"@{chavePrimaria.Name}{indice}", valorChavePrimaria);

                AtribuirValoresInsertOuReplace(entidade, sbFinal, parametros, colunas, indice);
            }
            else //Caso contrário faz um UPDATE
            {
                sbFinal.Append(baseUpdate);

                colunas.ForEach(c =>
                {
                    string parametro = $"@{c.Name}{indice}";
                    parametros.Add(parametro, c.GetValue(entidade));
                    sbFinal.Append(c.Name).Append(" = ").Append(parametro).Append(", ");
                });

                string parametro = $"@{chavePrimaria.Name}{indice}";
                sbFinal.Remove(sbFinal.Length - 2, 2)
                    .Append(" WHERE ")
                    .Append(chavePrimaria.Name)
                    .Append(" = ")
                    .Append(parametro)
                    .AppendLine(";");

                parametros.Add(parametro, valorChavePrimaria);
            }
        }

        /// <summary>
        /// Cria comando (INSERT OR) REPLACE INTO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        /// <param name="sbFinal"></param>
        /// <param name="parametros"></param>
        /// <param name="colunas"></param>
        /// <param name="chavePrimaria"></param>
        /// <param name="baseInsert"></param>
        /// <param name="i"></param>
        private static void CriarComandoReplace<T>(T entidade, StringBuilder sbFinal, DynamicParameters parametros,
            List<PropertyInfo> colunas, PropertyInfo chavePrimaria, string baseInsert, int i) where T : class, new()
        {
            sbFinal.Append(baseInsert);

            AtribuirValorInsertOuReplace(entidade, sbFinal, parametros, i, chavePrimaria);
            AtribuirValoresInsertOuReplace(entidade, sbFinal, parametros, colunas, i);
        }

        /// <summary>
        /// Método que serve apenas para se poder criar um <see cref="Delegate"/> com uma assinatura comum entre <see cref="CriarComandoReplace"/> e <seealso cref="CriarComandoInsertOuUpdate"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entidade"></param>
        /// <param name="sbFinal"></param>
        /// <param name="parametros"></param>
        /// <param name="baseUpdate"></param>
        /// <param name="colunas"></param>
        /// <param name="chavePrimaria"></param>
        /// <param name="baseInsert"></param>
        /// <param name="valorDefeitoChavePrimaria"></param>
        /// <param name="indice"></param>
        private static void CriarComandoReplace_Aux<T>(T entidade, StringBuilder sbFinal, DynamicParameters parametros, string baseUpdate, List<PropertyInfo> colunas,
            PropertyInfo chavePrimaria, string baseInsert, object valorDefeitoChavePrimaria, int indice) where T : class, new()
        {
            CriarComandoReplace(entidade, sbFinal, parametros, colunas, chavePrimaria, baseInsert, indice);
        }
    }
}
