using Dapper;
using Models.Classes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Helpers.Entities;

public class MoedasHelper : IEntityHelper<Coin>
{
	private const string Tabela = "Moedas";

	private IData Dados { get; set; }
	private IHttpHelper HttpHelper { get; set; }

	public MoedasHelper(IData dados, IHttpHelper httpHelper)
	{
		Dados = dados;
		HttpHelper = httpHelper;
	}

	public async Task<int> EliminarEntidades(IEnumerable<int> ids)
	{
		string query = QueryHelper.Delete(Tabela, "Id IN @Ids");

		return await Dados.ExecuteOpenAsync(query, new { Ids = ids });
	}

	public async Task<IEnumerable<Coin>> GetEntidades(string condicoes = null, string ordenacao = null)
	{
		string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);

		return await Dados.QueryOpenAsync<Coin>(query);
	}

	public async Task<IEnumerable<Coin>> GetEntidades(string condicoes, string ordenacao, params (string parametro, object valor)[] parametros)
	{
		string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);

		DynamicParameters parametrosDapper = new DynamicParameters();
		for (int i = 0; i < parametros.Length; i++)
		{
			parametrosDapper.Add(parametros[i].parametro, parametros[i].valor);
		}

		return await Dados.QueryOpenAsync<Coin>(query, parametrosDapper);
	}

	public async Task<Dictionary<int, Coin>> GetEntidadesComLista(string condicoes = null, string ordenacao = null)
	{
		return (await GetEntidades(condicoes, ordenacao)).ToDictionary(m => m.Id);
	}

	public async Task<bool> GravarEntidade(Coin moeda)
	{
		return await Dados.ExecuteOpenAsync(GravarEntidade_Base(moeda), moeda) == 1;
	}

	public async Task<int> GravarEntidade_GetIdGerado(Coin moeda)
	{
		if (moeda.Id == -1)
		{
			string query = GravarEntidade_Base(moeda) + "; SELECT LAST_INSERT_ROWID();";
			return await Dados.ExecuteScalarOpenAsync<int, Coin>(query, moeda);
		}

		return await GravarEntidade(moeda) ? moeda.Id : -1;
	}

	public async Task<List<Coin>> GravarEntidades(IEnumerable<Coin> entidades = null)
	{
		if (entidades == null)
		{
			List<Coin> moedasAPI = (await HttpHelper.PedidoGETHttpSingle<Coins>(null)).GetMoedas();
			Dictionary<int, Coin> moedasExistentes = (await GetEntidades("IdExterno IN @IdsExternos", null,
				("IdsExternos", moedasAPI.Select(m => m.IdExterno)))).ToDictionary(m => m.IdExterno);

			moedasAPI.ForEach(moeda =>
			{
				if (moedasExistentes.TryGetValue(moeda.IdExterno, out Coin moedaExistente))
				{
					moeda.Id = moedaExistente.Id;
					moeda.Nome = moedaExistente.Nome;
				}
				else
				{
					moeda.Id = -1;
					moeda.Nome = null;
				}
			});

			int resultado = await Dados.BulkMerge(moedasAPI.ToArray());

			return moedasAPI;
		}

		await Dados.BulkMerge(entidades.ToArray());

		return null;
	}

	//FUNÇÕES AUXILIARES
	private static string GravarEntidade_Base(Coin moeda)
	{
		if (moeda.Id < -1)
			throw new ArgumentException($"Moeda tem Id inválido ({moeda.Id}).");

		string query;

		//Inserir caso Id seja um valor inválido mas esperado
		if (moeda.Id == -1)
		{
			query = QueryHelper.InsertParametrizado(Tabela, "IdExterno", "Nome", "NomeExterno");
		}
		else //Atualizar caso tenha Id válido
		{
			query = QueryHelper.UpdateParametrizado(Tabela, "Id = @Id", "IdExterno", "Nome", "NomeExterno");

			//moeda.DataAlteracao = DateTime.Now;
		}
		return query;
	}
}
