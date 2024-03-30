using Dapper;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace GestorDados
{
    public class Dados : IDisposable, IDados
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
        /// <summary>
        /// Fecha a <see cref="Conexao"/> e inicia uma nova com a connection string recebida ou com <see cref="ConnectionString"/> caso não se tenha recebido nenhuma.
        /// <para>Altera a <see cref="ConnectionString"/> com a recebida</para>
        /// </summary>
        /// <param name="connectionString"></param>
        /// <exception cref="ArgumentException">Se ambas as connection strings estiverem vazias</exception>
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

        /// <summary>
        /// Desfaz a <see cref="Transacao"/> e fecha a <see cref="Conexao"/>
        /// </summary>
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
        /// <summary>
        /// Desfaz a <see cref="Transacao"/> e inicia uma nova com <see cref="Conexao"/>
        /// </summary>
        public void IniciarTransacao()
        {
            DesfazTransacao();

            Transacao = Conexao.BeginTransaction();
        }

        /// <summary>
        /// Desfaz a <see cref="Transacao"/> descartando todas as alterações (fazendo rollback)
        /// </summary>
        public void DesfazTransacao()
        {
            if (Transacao != null)
            {
                Transacao.Rollback();
                Transacao.Dispose();
            }
        }

        /// <summary>
        /// Aplica todas as alterações existentes na <see cref="Transacao"/>
        /// </summary>
        public void TerminaTransacao()
        {
            if (Transacao != null)
            {
                Transacao.Commit();
                Transacao.Dispose();
            }
        }
        #endregion

        /// <summary>
        /// Executa um comando SQL e devolve o número de linhas afetadas
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<int> ExecuteOpenAsync(string query)
        {
            return await Conexao.ExecuteAsync(query, transaction: Transacao);
        }

        /// <summary>
        /// Devolve o valor da primeira coluna devolvida pela <paramref name="query"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<T> ExecuteScalarOpenAsync<T>(string query)
        {
            return await Conexao.ExecuteScalarAsync<T>(query, transaction: Transacao);
        }

        public async Task<T> GetValorOpenAsync<T>(string query)
        {
            return await Conexao.QueryFirstOrDefaultAsync<T>(query, transaction: Transacao);
        }

        /// <summary>
        /// Executa e devolve os resultados de <paramref name="query"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryOpenAsync<T>(string query)
        {
            return await Conexao.QueryAsync<T>(query, transaction: Transacao);
        }

        public async Task<IEnumerable<T>> QueryOpenAsync<Entidade1, Entidade2, T>(string query, Func<Entidade1, Entidade2, T> mapeamento, string splitOn = "Id")
        {
            return await Conexao.QueryAsync(query, mapeamento, transaction: Transacao, splitOn: splitOn);
        }

        public void Dispose()
        {
            FecharConexao();
        }
    }
}
