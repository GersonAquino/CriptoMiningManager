using Dapper;
using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Utils;

namespace GestorDados.Helpers.Entidades
{
	//Esta classe pode gerar problemas com a implementação atual do Autofac, até agora parece que não, mas se algo parecer estranho pode ter a ver com isto
	public abstract class EntidadesHelper<T> : IEntidadesHelper<T> where T : Registo, new()
	{
		protected string[] ColunasSemId { get; }
		protected string Descricao { get; }
		protected string Tabela { get; }

		protected IDados Dados { get; }

		public EntidadesHelper(IDados dados)
		{
			Dados = dados;

			Type tipo = typeof(T);

			Descricao = tipo.GetDescricaoClasse();
			Tabela = tipo.GetCustomAttribute<TableAttribute>().Name;

			PropertyInfo[] propriedades = tipo.GetProperties();

			//Por agora subtrai apenas 1, porque descende de Configuracao e todas as classes descendentes dessa só têm o Id como chave primária, não há chaves compostas
			List<string> colunasList = new(propriedades.Length - 1);

			//Guardar todos os nomes das propriedades que não estejam marcadas como Key ou NotMapped
			Type key = typeof(KeyAttribute);
			Type notMapped = typeof(NotMappedAttribute);
			propriedades.ForEach((p, _) => { if (!p.IsDefined(key) && !p.IsDefined(notMapped)) colunasList.Add(p.Name); });

			ColunasSemId = colunasList.ToArray();
		}

		///<inheritdoc/>
		public virtual async Task<int> EliminarEntidades(IEnumerable<int> ids)
		{
			string query = QueryHelper.Delete(Tabela, "Id IN @Ids");

			return await Dados.ExecuteOpenAsync(query, new { Ids = ids });
		}

		///<inheritdoc/>
		public virtual async Task<T> GetEntidade(string condicoes = null, string ordenacao = null)
		{
			string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao, limit: 1);

			return await Dados.GetValorOpenAsync<T>(query);
		}

		///<inheritdoc/>
		public virtual async Task<IEnumerable<T>> GetEntidades(string condicoes = null, string ordenacao = null)
		{
			string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);

			return await Dados.QueryOpenAsync<T>(query);
		}

		///<inheritdoc/>
		public virtual async Task<IEnumerable<T>> GetEntidades(string condicoes, string ordenacao, params (string parametro, object valor)[] parametros)
		{
			string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);

			DynamicParameters parametrosDapper = new();
			for (int i = 0; i < parametros.Length; i++)
			{
				parametrosDapper.Add(parametros[i].parametro, parametros[i].valor);
			}

			return await Dados.QueryOpenAsync<T>(query, parametrosDapper);
		}

		///<inheritdoc/>
		public virtual async Task<Dictionary<int, T>> GetEntidadesComLista(string condicoes = null, string ordenacao = null)
		{
			return (await GetEntidades(condicoes, ordenacao)).ToDictionary(c => c.Id);
		}

		///<inheritdoc/>
		public virtual async Task<bool> GravarEntidade(T entidade)
		{
			if (entidade.Id == -1)
				return await GravarEntidadeNova(entidade) > 0;

			return await Dados.ExecuteOpenAsync(await GravarEntidade_QueryBase(entidade), entidade) == 1;
		}

		///<inheritdoc/>
		public virtual async Task<int> GravarEntidade_GetIdGerado(T entidade)
		{
			if (entidade.Id == -1)
				return await GravarEntidadeNova(entidade);

			return await GravarEntidade(entidade) ? entidade.Id : -1;
		}

		///<inheritdoc/>
		public virtual async Task<List<T>> GravarEntidades(IEnumerable<T> entidades = null)
		{
			ArgumentNullException.ThrowIfNull(entidades);

			List<T> entidadesList = entidades.ToList();
			entidadesList.ForEach(e => e.DataAlteracao = DateTime.Now);

			await Dados.BulkMerge(entidadesList);
			return entidadesList;
		}

		//MÉTODOS AUXILIARES
		protected virtual async Task<string> GravarEntidade_QueryBase(T entidade)
		{
			if (entidade.Id < -1)
				throw new ArgumentException($"{Descricao} tem Id inválido ({entidade.Id}).");

			GravarEntidade_ValidacoesExtra(entidade);

			Task task = GravarEntidade_ValidacoesExtra_Async(entidade);
			if (task != null)
				await task;

			string query;
			//Inserir caso Id seja um valor inválido mas esperado
			if (entidade.Id == -1)
			{
				query = QueryHelper.InsertParametrizado(Tabela, ColunasSemId);
			}
			else //Atualizar caso tenha Id válido
			{
				query = QueryHelper.UpdateParametrizado(Tabela, "Id = @Id", ColunasSemId);

				entidade.DataAlteracao = DateTime.Now;
			}
			return query;
		}

		#region Métodos para override
		//Estes métodos servem apenas para ser feito o override deles caso necessário.
		//Não foram marcados como abstratos para não obrigar a implementação deles em subclasses que não precisam.
		protected virtual void GravarEntidade_ValidacoesExtra(T entidade) { }
		protected virtual Task GravarEntidade_ValidacoesExtra_Async(T entidade) { return null; }
		#endregion

		/// <summary>
		/// Grava uma entidade (<typeparamref name="T"/>) nova e atualiza o Id da mesma
		/// </summary>
		/// <param name="entidade"></param>
		/// <returns>Id da entidade gerada</returns>
		private async Task<int> GravarEntidadeNova(T entidade)
		{
			string query = await GravarEntidade_QueryBase(entidade) + "; SELECT LAST_INSERT_ROWID();";

			entidade.Id = await Dados.ExecuteScalarOpenAsync<int, T>(query, entidade);

			return entidade.Id;
		}
	}
}
