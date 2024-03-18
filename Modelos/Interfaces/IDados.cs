using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelos.Interfaces
{
    public interface IDados
    {
        void DesfazTransacao();
        void Dispose();
        Task<int> ExecuteOpenAsync(string query);
        Task<T> ExecuteScalarOpenAsync<T>(string query);
        void FecharConexao();
        Task<T> GetValorOpenAsync<T>(string query);
        void IniciarConexao(string connectionString = null);
        void IniciarTransacao();
        Task<IEnumerable<T>> QueryOpenAsync<Entidade1, Entidade2, T>(string query, Func<Entidade1, Entidade2, T> mapeamento, string splitOn = "Id");
        Task<IEnumerable<T>> QueryOpenAsync<T>(string query);
        void TerminaTransacao();
    }
}