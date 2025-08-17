using Dapper;
using Models.Classes;
using Models.Exceptions;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Helpers.Entities;

public class CommandHelper : IEntityHelper<Command>
{
	private const string Table = "Commands";

	private IData Data { get; set; }

	public CommandHelper(IData data)
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
	public async Task<IEnumerable<Command>> GetEntities(string conditions = null, string sorting = null)
	{
		string query = QueryHelper.Select("*", Table, conditions, sorting);

		return await Data.QueryOpenAsync<Command>(query);
	}

	///<inheritdoc/>
	public async Task<IEnumerable<Command>> GetEntities(string conditions, string sorting, params (string parameter, object value)[] parameters)
	{
		string query = QueryHelper.Select("*", Table, conditions, sorting);

		DynamicParameters dapperParameters = new();
		for (int i = 0; i < parameters.Length; i++)
		{
			dapperParameters.Add(parameters[i].parameter, parameters[i].value);
		}

		return await Data.QueryOpenAsync<Command>(query, dapperParameters);
	}

	///<inheritdoc/>
	public async Task<Dictionary<int, Command>> GetEntitiesWithList(string conditions = null, string sorting = null)
	{
		return (await GetEntities(conditions, sorting)).ToDictionary(c => c.Id);
	}

	///<inheritdoc/>
	public async Task<bool> SaveEntity(Command command)
	{
		return await Data.ExecuteOpenAsync(SaveEntity_Base(command), command) == 1;
	}

	///<inheritdoc/>
	public async Task<int> SaveEntity_GetId(Command command)
	{
		string query;
		if (command.Active)
		{
			if (!command.PreMining && !command.PosMining)
				throw new CustomException("Por favor defina o tipo de comando (Pré-Mineração, Pós-Mineração ou ambos) antes de o definir como 'Active'.", "Comando inválido");

			string commandType;
			if (command.PreMining)
			{
				commandType = "AND PreMining = 1";
				if (command.PosMining)
					commandType += " OR AfterMining = 1";
			}
			else
				commandType = "AND AfterMining = 1";

			query = QueryHelper.Select("Id", Table,
				$"Active = 1 {commandType}{(command.Id != -1 ? $" AND Id != {command.Id}" : "")}", limit: 1);

			int? existentId = await Data.ExecuteScalarOpenAsync<int?>(query);
			if (existentId.HasValue)
				throw new CustomException("Já existe um comando ativo com as definições de Pré/Pós-Mineracao.", "Comando ativo do mesmo tipo já existente");
		}

		if (command.Id == -1)
		{
			query = SaveEntity_Base(command) + "; SELECT LAST_INSERT_ROWID();";

			return await Data.ExecuteScalarOpenAsync<int, Command>(query, command);
		}

		return await SaveEntity(command) ? command.Id : -1;
	}

	//FUNÇÕES AUXILIARES
	private static string SaveEntity_Base(Command command)
	{
		if (command.Id < -1)
			throw new ArgumentException($"Comando tem Id inválido ({command.Id}).");

		string query;

		//Inserir caso Id seja um valor inválido, mas esperado
		if (command.Id == -1)
		{
			query = QueryHelper.ParameterizedInsert(Table, "Comandos", "PreMining", "AfterMining", "Active");
		}
		else //Atualizar caso tenha Id válido
		{
			query = QueryHelper.ParameterizedUpdate(Table, "Id = @Id", "Comandos", "PreMining", "AfterMining", "Active", "UpdatedDate");

			command.UpdatedDate = DateTime.Now;
		}

		return query;
	}

	public Task<List<Command>> SaveEntities(IEnumerable<Command> entidades = null)
	{
		throw new NotImplementedException();
	}
}
