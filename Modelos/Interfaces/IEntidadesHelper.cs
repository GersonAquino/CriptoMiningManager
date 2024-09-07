using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelos.Interfaces
{
	public interface IEntidadesHelper<T> //: IDisposable //Não se implementa IDisposable porque o Autofac já trata do Dispose do IDados sozinho, então tentar fazer dispose manualmente dá origem a um erro ao fechar o separador
	{
		/// <summary>
		/// Elimina da base de dados todas as entidades (<typeparamref name="T"/>) com os <paramref name="ids"/> recebidos
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		Task<int> EliminarEntidades(IEnumerable<int> ids);

		/// <summary>
		/// Obtém a primeira entidade (<typeparamref name="T"/>) que cumpra as <paramref name="condicoes"/> definidas
		/// </summary>
		/// <param name="condicoes"></param>
		/// <param name="ordenacao"></param>
		/// <returns></returns>
		T GetEntidade(string condicoes, string ordenacao = null);

		/// <summary>
		/// Obtém a primeira entidade (<typeparamref name="T"/>) que cumpra as <paramref name="condicoes"/> definidas
		/// </summary>
		/// <param name="condicoes"></param>
		/// <param name="ordenacao"></param>
		/// <returns></returns>
		Task<T> GetEntidadeAsync(string condicoes, string ordenacao = null);

		/// <summary>
		/// Obtém todas entidades (<typeparamref name="T"/>)
		/// </summary>
		/// <param name="condicoes"></param>
		/// <param name="ordenacao"></param>
		/// <returns></returns>
		Task<IEnumerable<T>> GetEntidades(string condicoes = null, string ordenacao = null);

		/// <summary>
		/// Obtém todas entidades (<typeparamref name="T"/>) com uma query parametrizada
		/// </summary>
		/// <param name="parametros"></param>
		/// <param name="condicoes"></param>
		/// <param name="ordenacao"></param>
		/// <returns></returns>
		Task<IEnumerable<T>> GetEntidades(string condicoes, string ordenacao, params (string parametro, object valor)[] parametros);

		/// <summary>
		/// Obtém todas entidades (<typeparamref name="T"/>) e preenche uma propriedade que seja uma <see cref="List{P}"/>
		/// </summary>
		/// <param name="condicoes"></param>
		/// <param name="ordenacao"></param>
		/// <returns>Dicionário de <see cref="int"/> e <typeparamref name="T"/> em que a chave é o Id de <typeparamref name="T"/></returns>
		Task<Dictionary<int, T>> GetEntidadesComLista(string condicoes = null, string ordenacao = null);

		/// <summary>
		/// Grava a entidade (<typeparamref name="T"/>) na base de dados
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns></returns>
		bool GravarEntidade(T entidade);

		/// <summary>
		/// Grava a entidade (<typeparamref name="T"/>) na base de dados
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns></returns>
		Task<bool> GravarEntidadeAsync(T entidade);

		/// <summary>
		/// Grava a entidade (<typeparamref name="T"/>) na base de dados.
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns>Id da entidade gravada ou -1 em caso de falha</returns>
		Task<int> GravarEntidade_GetIdGerado(T entidade);

		/// <summary>
		/// Grava todas as entidades recebidas
		/// </summary>
		/// <param name="entidades"></param>
		/// <returns>Entidades com a DataAlteracao atualizada</returns>
		Task<List<T>> GravarEntidades(IEnumerable<T> entidades = null);
	}
}
