using Dapper;
using Models.Classes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManager.Helpers.Entities;

public class MinerHelper : IEntityHelper<Miner>
{
	private const string Table = "Miners";

	private IData Data { get; set; }

	public MinerHelper(IData data)
	{
		Data = data;
	}

	///<inheritdoc/>
	public async Task<int> DeleteEntities(IEnumerable<int> ids)
	{
		string query = QueryHelper.Delete(Table, "Id IN @Ids");

		return await Data.ExecuteOpenAsync(query, new { Ids = ids });
	}

	///<inheritdoc/>
	public async Task<IEnumerable<Miner>> GetEntities(string condicoes = null, string ordenacao = null)
	{
		string query = QueryHelper.Select("*", Table, condicoes, ordenacao);
		return await Data.QueryOpenAsync<Miner>(query);
	}

	///<inheritdoc/>
	public async Task<IEnumerable<Miner>> GetEntities(string condicoes, string ordenacao, params (string parameter, object value)[] parameters)
	{
		string query = QueryHelper.Select("*", Table, condicoes, ordenacao);

		DynamicParameters dapperParameters = new();
		for (int i = 0; i < parameters.Length; i++)
		{
			dapperParameters.Add(parameters[i].parameter, parameters[i].value);
		}

		return await Data.QueryOpenAsync<Miner>(query, dapperParameters);
	}

	///<inheritdoc/>
	public async Task<Dictionary<int, Miner>> GetEntitiesWithList(string condicoes = null, string ordenacao = null)
	{
		string query = QueryHelper.Select("mi.*, mo.*",
			@"Mineradores mi
                            LEFT JOIN Moedas mo
                                ON mo.Id = mi.CoinId", condicoes, ordenacao);

		Dictionary<int, Miner> mineradores = new Dictionary<int, Miner>();

		//Função para mapear as moedas com os mineradores
		Func<Miner, Coin, Miner> mapping = (minerador, moeda) =>
		{
			if (!mineradores.TryGetValue(minerador.Id, out Miner mineradorExistente))
			{
				mineradorExistente = minerador;
				mineradores.Add(mineradorExistente.Id, mineradorExistente);
			}

			if (moeda != null)
				mineradorExistente.Coin = moeda;

			//O return aqui é o que vai ser devolvido para o IEnumerable<Minerador> que o Dapper está a criar
			//Como não vai ser usado, mais vale que fique cheio de nulls
			return null;
		};

		//Não se guarda o resultado porque os dados serão preenchidos corretamente no Dictionary<int, Minerador>
		await Data.QueryOpenAsync(query, mapping, "Id");
		return mineradores;
	}

	///<inheritdoc/>
	public async Task<bool> SaveEntity(Miner minerador)
	{
		return await Data.ExecuteOpenAsync(SaveEntity_Base(minerador), minerador) == 1;
	}

	public async Task<int> SaveEntity_GetId(Miner minerador)
	{
		if (minerador.Id == -1)
		{
			string query = SaveEntity_Base(minerador) + "; SELECT LAST_INSERT_ROWID();";
			return await Data.ExecuteScalarOpenAsync<int, Miner>(query, minerador);
		}

		return await SaveEntity(minerador) ? minerador.Id : -1;
	}

	//FUNÇÕES AUXILIARES
	private static string SaveEntity_Base(Miner minerador)
	{
		if (minerador.Id < -1)
			throw new ArgumentException($"Minerador tem Id inválido ({minerador.Id}).");

		string query;

		//Inserir caso Id seja um valor inválido mas esperado
		if (minerador.Id == -1)
		{
			query = QueryHelper.ParameterizedInsert(Table, "Active", "CoinId", "Location", "Name", "Parameters");
		}
		else //Atualizar caso tenha Id válido
		{
			query = QueryHelper.ParameterizedUpdate(Table, "Id = @Id", "Active", "CoinId", "Location", "Name", "Parameters", "UpdatedDate");

			minerador.UpdatedDate = DateTime.Now;
		}
		return query;
	}

	public Task<List<Miner>> SaveEntities(IEnumerable<Miner> entidades = null)
	{
		throw new NotImplementedException();
	}
}
