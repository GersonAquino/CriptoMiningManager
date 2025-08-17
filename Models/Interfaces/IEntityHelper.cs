using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interfaces;

public interface IEntityHelper<T> //: IDisposable //Não se implementa IDisposable porque o Autofac já trata do Dispose do IDados sozinho, então tentar fazer dispose manualmente dá origem a um erro ao fechar o separador
{
	/// <summary>
	/// Elimina da base de dados todas as entidades (<typeparamref name="T"/>) com os <paramref name="ids"/> recebidos
	/// </summary>
	/// <param name="ids"></param>
	/// <returns></returns>
	Task<int> DeleteEntities(IEnumerable<int> ids);

	/// <summary>
	/// Obtém todas entidades (<typeparamref name="T"/>)
	/// </summary>
	/// <param name="conditions"></param>
	/// <param name="sorting"></param>
	/// <returns></returns>
	Task<IEnumerable<T>> GetEntities(string conditions = null, string sorting = null);

	/// <summary>
	/// Obtém todas entidades (<typeparamref name="T"/>) com uma query parametrizada
	/// </summary>
	/// <param name="parameters"></param>
	/// <param name="conditions"></param>
	/// <param name="sorting"></param>
	/// <returns></returns>
	Task<IEnumerable<T>> GetEntities(string conditions, string sorting, params (string parameter, object value)[] parameters);

	/// <summary>
	/// Obtém todas entidades (<typeparamref name="T"/>) e preenche uma propriedade que seja uma <see cref="List{P}"/>
	/// </summary>
	/// <param name="conditions"></param>
	/// <param name="sorting"></param>
	/// <returns>Dicionário de <see cref="int"/> e <typeparamref name="T"/> em que a chave é o Id de <typeparamref name="T"/></returns>
	Task<Dictionary<int, T>> GetEntitiesWithList(string conditions = null, string sorting = null);

	/// <summary>
	/// Grava a entidade (<typeparamref name="T"/>) na base de dados
	/// </summary>
	/// <param name="entity"></param>
	/// <returns></returns>
	Task<bool> SaveEntity(T entity);

	/// <summary>
	/// Grava a entidade (<typeparamref name="T"/>) na base de dados.
	/// </summary>
	/// <param name="entity"></param>
	/// <returns>Id da entidade gravada ou -1 em caso de falha</returns>
	Task<int> SaveEntity_GetId(T entity);

	Task<List<T>> SaveEntities(IEnumerable<T> entities = null);
}
