using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelos.Interfaces
{
	public interface IDados : IDisposable
	{
		/// <summary>
		/// Desfaz a <see cref="Transacao"/> descartando todas as alterações (fazendo rollback)
		/// </summary>
		void DesfazTransacao();

		/// <summary>
		/// Faz um merge de vários <typeparamref name="T"/> ao mesmo tempo
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parametros"></param>
		/// <returns>Número de linhas afetadas</returns>
		Task<int> BulkMerge<T>(List<T> parametros) where T : class, new();

		/// <summary>
		/// Executa um comando SQL e devolve o número de linhas afetadas
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		int ExecuteOpen(string query);

		/// <summary>
		/// Executa um comando SQL e devolve o número de linhas afetadas
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="parametros"></param>
		/// <returns></returns>
		int ExecuteOpen<T>(string query, T parametros);

		/// <summary>
		/// Executa um comando SQL e devolve o número de linhas afetadas
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		Task<int> ExecuteOpenAsync(string query);

		/// <summary>
		/// Executa um comando SQL e devolve o número de linhas afetadas
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="parametros"></param>
		/// <returns></returns>
		Task<int> ExecuteOpenAsync<T>(string query, T parametros);

		/// <summary>
		/// Devolve o valor da primeira coluna devolvida pela <paramref name="query"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <returns></returns>
		T ExecuteScalarOpen<T>(string query);

		/// <summary>
		/// Devolve o valor da primeira coluna devolvida pela <paramref name="query"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="parametros"></param>
		/// <returns></returns>
		T ExecuteScalarOpen<T, P>(string query, P parametros);

		/// <summary>
		/// Devolve o valor da primeira coluna devolvida pela <paramref name="query"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <returns></returns>
		Task<T> ExecuteScalarOpenAsync<T>(string query);

		/// <summary>
		/// Devolve o valor da primeira coluna devolvida pela <paramref name="query"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="parametros"></param>
		/// <returns></returns>
		Task<T> ExecuteScalarOpenAsync<T, P>(string query, P parametros);

		/// <summary>
		/// Desfaz a <see cref="Transacao"/> e fecha a <see cref="Conexao"/>
		/// </summary>
		void FecharConexao();

		T GetValorOpen<T>(string query);

		Task<T> GetValorOpenAsync<T>(string query);

		/// <summary>
		/// Fecha a <see cref="Conexao"/> e inicia uma nova com a connection string recebida ou com <see cref="ConnectionString"/> caso não se tenha recebido nenhuma.
		/// <para>Altera a <see cref="ConnectionString"/> com a recebida</para>
		/// </summary>
		/// <param name="connectionString"></param>
		/// <exception cref="ArgumentException">Se ambas as connection strings estiverem vazias</exception>
		void IniciarConexao(string connectionString = null);

		/// <summary>
		/// Desfaz a <see cref="Transacao"/> e inicia uma nova com <see cref="Conexao"/>
		/// </summary>
		void IniciarTransacao();

		/// <summary>
		/// Executa e devolve os resultados de <paramref name="query"/> recebendo uma <see cref="Func{T1, T2, TResult}"/> para permitir preencher uma lista por exemplo
		/// </summary>
		/// <typeparam name="Entidade1"></typeparam>
		/// <typeparam name="Entidade2"></typeparam>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="mapeamento"></param>
		/// <param name="splitOn"></param>
		/// <returns></returns>
		Task<IEnumerable<T>> QueryOpenAsync<Entidade1, Entidade2, T>(string query, Func<Entidade1, Entidade2, T> mapeamento, string splitOn = "Id");

		/// <summary>
		/// Executa e devolve os resultados de <paramref name="query"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="parametros"></param>
		/// <returns></returns>
		Task<IEnumerable<T>> QueryOpenAsync<T>(string query, object parametros = null);

		/// <summary>
		/// Aplica todas as alterações existentes na <see cref="Transacao"/>
		/// </summary>
		void TerminaTransacao();
	}
}