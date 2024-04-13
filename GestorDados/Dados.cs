using Dapper;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
        public async Task<IEnumerable<T>> QueryOpenAsync<T>(string query)
        {
            return await Conexao.QueryAsync<T>(query, transaction: Transacao);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<T>> QueryOpenAsync<Entidade1, Entidade2, T>(string query, Func<Entidade1, Entidade2, T> mapeamento, string splitOn = "Id")
        {
            return await Conexao.QueryAsync(query, mapeamento, transaction: Transacao, splitOn: splitOn);
        }

        ///<inheritdoc/>
        public void Dispose()
        {
            FecharConexao();
        }
    }
}
