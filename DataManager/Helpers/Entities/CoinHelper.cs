using Dapper;
using Models.Classes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Helpers.Entities;

public class CoinHelper : IEntityHelper<Coin>
{
	private const string Table = "Coins";

	private IData Data { get; set; }
	private IHttpHelper HttpHelper { get; set; }

	public CoinHelper(IData data, IHttpHelper httpHelper)
	{
		Data = data;
		HttpHelper = httpHelper;
	}

	public async Task<int> DeleteEntities(IEnumerable<int> ids)
	{
		string query = QueryHelper.Delete(Table, "Id IN @Ids");

		return await Data.ExecuteOpenAsync(query, new { Ids = ids });
	}

	public async Task<IEnumerable<Coin>> GetEntities(string conditions = null, string sorting = null)
	{
		string query = QueryHelper.Select("*", Table, conditions, sorting);

		return await Data.QueryOpenAsync<Coin>(query);
	}

	public async Task<IEnumerable<Coin>> GetEntities(string conditions, string sorting, params (string parameter, object value)[] parameters)
	{
		string query = QueryHelper.Select("*", Table, conditions, sorting);

		DynamicParameters dapperParameters = new();
		for (int i = 0; i < parameters.Length; i++)
		{
			dapperParameters.Add(parameters[i].parameter, parameters[i].value);
		}

		return await Data.QueryOpenAsync<Coin>(query, dapperParameters);
	}

	public async Task<Dictionary<int, Coin>> GetEntitiesWithList(string conditions = null, string sorting = null)
	{
		return (await GetEntities(conditions, sorting)).ToDictionary(m => m.Id);
	}

	public async Task<bool> SaveEntity(Coin coin)
	{
		return await Data.ExecuteOpenAsync(SaveEntity_Base(coin), coin) == 1;
	}

	public async Task<int> SaveEntity_GetId(Coin coin)
	{
		if (coin.Id == -1)
		{
			string query = SaveEntity_Base(coin) + "; SELECT LAST_INSERT_ROWID();";
			return await Data.ExecuteScalarOpenAsync<int, Coin>(query, coin);
		}

		return await SaveEntity(coin) ? coin.Id : -1;
	}

	public async Task<List<Coin>> SaveEntities(IEnumerable<Coin> entidades = null)
	{
		if (entidades == null)
		{
			List<Coin> coinsAPI = (await HttpHelper.GETRequestHttpSingle<Coins>(null)).GetCoins();

			IEnumerable<Coin> filteredCoins = await GetEntities("ExternalId IN @IdsExternos", null, ("IdsExternos", coinsAPI.Select(m => m.ExternalId)));
			Dictionary<int, Coin> moedasExistentes = filteredCoins.ToDictionary(m => m.ExternalId);

			coinsAPI.ForEach(coin =>
			{
				if (moedasExistentes.TryGetValue(coin.ExternalId, out Coin existentCoin))
				{
					coin.Id = existentCoin.Id;
					coin.Name = existentCoin.Name;
				}
				else
				{
					coin.Id = -1;
					coin.Name = null;
				}
			});

			int resultado = await Data.BulkMerge(coinsAPI.ToArray());

			return coinsAPI;
		}

		await Data.BulkMerge(entidades.ToArray());

		return null;
	}

	//FUNÇÕES AUXILIARES
	private static string SaveEntity_Base(Coin moeda)
	{
		if (moeda.Id < -1)
			throw new ArgumentException($"Moeda tem Id inválido ({moeda.Id}).");

		string query;

		//Inserir caso Id seja um valor inválido mas esperado
		if (moeda.Id == -1)
		{
			query = QueryHelper.ParameterizedInsert(Table, "ExternalId", "Name", "ExternalName");
		}
		else //Atualizar caso tenha Id válido
		{
			query = QueryHelper.ParameterizedUpdate(Table, "Id = @Id", "ExternalId", "Name", "ExternalName");

			//moeda.UpdatedDate = DateTime.Now;
		}
		return query;
	}
}
