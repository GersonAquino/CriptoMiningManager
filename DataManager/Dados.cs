using Dapper;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataManager;

public class Dados : IData
{
	private IDbConnection Connection = null;
	private IDbTransaction Transaction = null;
	private string ConnectionString;

	public Dados(string connectionString = null, bool startConnection = false)
	{
		ConnectionString = connectionString;

		if (startConnection)
		{
			Connection = new SQLiteConnection(connectionString);
			Connection.Open();
		}
	}

	#region Connections
	///<inheritdoc/>
	public void StartConnection(string connectionString = null)
	{
		CloseConnection();

		if (!string.IsNullOrWhiteSpace(connectionString))
			ConnectionString = connectionString;
		else if (string.IsNullOrWhiteSpace(ConnectionString))
			throw new ArgumentException("Não é possível inicar uma conexão sem uma connection string!");

		Connection = new SQLiteConnection(ConnectionString);
		Connection.Open();
	}

	///<inheritdoc/>
	public void CloseConnection()
	{
		if (Connection != null)
		{
			UndoTransaction();

			Connection.Close();
			Connection.Dispose();
		}
	}
	#endregion

	#region Transactions
	///<inheritdoc/>
	public void StartTransaction()
	{
		UndoTransaction();

		Transaction = Connection.BeginTransaction();
	}

	///<inheritdoc/>
	public void UndoTransaction()
	{
		if (Transaction != null)
		{
			Transaction.Rollback();
			Transaction.Dispose();
		}
	}

	///<inheritdoc/>
	public void CommitTransaction()
	{
		if (Transaction != null)
		{
			Transaction.Commit();
			Transaction.Dispose();
		}
	}
	#endregion

	///<inheritdoc/>
	public async Task<int> ExecuteOpenAsync(string query)
	{
		return await Connection.ExecuteAsync(query, transaction: Transaction);
	}

	///<inheritdoc/>
	public async Task<int> ExecuteOpenAsync<T>(string query, T parameters)
	{
		return await Connection.ExecuteAsync(query, parameters, transaction: Transaction);
	}

	///<inheritdoc/>
	public async Task<T> ExecuteScalarOpenAsync<T>(string query)
	{
		return await Connection.ExecuteScalarAsync<T>(query, transaction: Transaction);
	}

	///<inheritdoc/>
	public async Task<T> ExecuteScalarOpenAsync<T, P>(string query, P parameters)
	{
		return await Connection.ExecuteScalarAsync<T>(query, parameters, Transaction);
	}

	///<inheritdoc/>
	public async Task<T> GetValorOpenAsync<T>(string query)
	{
		return await Connection.QueryFirstOrDefaultAsync<T>(query, transaction: Transaction);
	}

	///<inheritdoc/>
	public async Task<IEnumerable<T>> QueryOpenAsync<T>(string query, object parameters = null)
	{
		return await Connection.QueryAsync<T>(query, parameters, transaction: Transaction);
	}

	///<inheritdoc/>
	public async Task<IEnumerable<T>> QueryOpenAsync<Entidade1, Entidade2, T>(string query, Func<Entidade1, Entidade2, T> mapping, string splitOn = "Id")
	{
		return await Connection.QueryAsync(query, mapping, transaction: Transaction, splitOn: splitOn);
	}

	///<inheritdoc/>
	public async Task<int> BulkMerge<T>(params T[] entities) where T : class, new()
	{
		//Obter tabela alvo
		Type tipo = typeof(T);
		string table = tipo.GetCustomAttribute<TableAttribute>().Name ??
			throw new NotImplementedException($"{tipo.Name} não tem o atributo 'Table' implementado!");

		//Obter informação sobre chave primária - É autoincrement?
		string query =
			$@"SELECT CASE
                        WHEN sql LIKE '%AUTOINCREMENT%' THEN 1 ELSE 0
                    END AS 'Autoincrement'
                FROM sqlite_master
                WHERE type = 'table'
                AND name = '{table}'
                LIMIT 1";

		Task<bool> isAutoIncrementTask = ExecuteScalarOpenAsync<bool>(query);
		//isAutoIncrementTask.Start(); //Aparentemente o Start() já deve ser chamado pelo Dapper automaticamente e não é preciso chamá-lo aqui

		//Preparar variáveis usadas para o comando sql final
		StringBuilder sbFinal = new();
		DynamicParameters parameters = new();
		PropertyInfo[] properties = tipo.GetProperties();

		//Guardar todas as colunas exceto a chave primária
		List<PropertyInfo> colunas = new(properties.Length - 1);
		PropertyInfo primaryKey = null;
		Type notMapped = typeof(NotMappedAttribute);
		Type key = typeof(KeyAttribute);
		string baseUpdate = $"UPDATE {table} SET ";

		//Obter chave primária e definir colunas a inserir no Insert
		bool isAutoIncrement = await isAutoIncrementTask;
		StringBuilder sbInsertBase = new(isAutoIncrement ? "INSERT INTO " : "REPLACE INTO "); //REPLACE INTO é o mesmo que INSERT OR REPLACE INTO

		sbInsertBase.Append(table).Append(" (");

		for (int i = 0; i < properties.Length; i++)
		{
			PropertyInfo prop = properties[i];

			if (prop.IsDefined(notMapped) ||
				!prop.PropertyType.IsPrimitive &&
				prop.PropertyType != typeof(string) &&
				prop.PropertyType != typeof(decimal) &&
				prop.PropertyType != typeof(DateTime) &&
				prop.PropertyType != typeof(char))
			{
				continue;
			}

			//Se for chave primária
			if (prop.IsDefined(key))
			{
				if (!isAutoIncrement)
					sbInsertBase.Append(prop.Name).Append(", ");

				primaryKey = prop;
			}
			else
			{
				colunas.Add(prop);
				sbInsertBase.Append(prop.Name).Append(", ");
			}
		}

		if (primaryKey == null)
			throw new NoNullAllowedException($"Chave primária da classe {tipo.Name} não encontrada!");

		string baseInsert = sbInsertBase.Remove(sbInsertBase.Length - 2, 2).Append(") VALUES (").ToString();
		object primaryKeyDefaultValue = primaryKey.GetValue(new T());

		Action<T, StringBuilder, DynamicParameters, string, List<PropertyInfo>, PropertyInfo, string, object, int> HandleIteration =
			isAutoIncrement ? BuildInsertOrUpdateCommand : BuildReplaceCommand_Aux;

		for (int i = 0; i < entities.Length; i++)
		{
			HandleIteration(entities[i], sbFinal, parameters, baseUpdate, colunas, primaryKey, baseInsert, primaryKeyDefaultValue, i);
		}

		return await Connection.ExecuteAsync(sbFinal.ToString(), parameters);
	}

	///<inheritdoc/>
	public void Dispose()
	{
		CloseConnection();
	}

	//MÉTODOS AUXILIARES
	/// <summary>
	/// Atribuir valor de uma coluna com base na <paramref name="property"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity"></param>
	/// <param name="sbFinal"></param>
	/// <param name="parameters"></param>
	/// <param name="index"></param>
	/// <param name="property"></param>
	private static void AssignValueInsertOrReplace<T>(T entity, StringBuilder sbFinal, DynamicParameters parameters, int index, PropertyInfo property) where T : class, new()
	{
		string parameter = $"@{property.Name}{index}";
		parameters.Add(parameter, property.GetValue(entity));
		sbFinal.Append(parameter).Append(", ");
	}

	/// <summary>
	/// Atribui todos os valores de <paramref name="columns"/> às colunas SQL e termina o comando sql de <paramref name="sbFinal"/> com ");"
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity"></param>
	/// <param name="sbFinal"></param>
	/// <param name="parameters"></param>
	/// <param name="columns"></param>
	/// <param name="index"></param>
	private static void AssignValuesInsertOrReplace<T>(T entity, StringBuilder sbFinal, DynamicParameters parameters, List<PropertyInfo> columns, int index) where T : class, new()
	{
		columns.ForEach(c => AssignValueInsertOrReplace(entity, sbFinal, parameters, index, c));
		sbFinal.Remove(sbFinal.Length - 2, 2).AppendLine(");");
	}

	/// <summary>
	/// Cria um comando INSERT ou UPDATE conforme o valor da chave primária.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity">Entidade a usar para os dados do comando</param>
	/// <param name="sbFinal">StringBuilder onde se vai acrescentar o comando</param>
	/// <param name="parameters">Objeto onde se registarão os parâmetros do comando</param>
	/// <param name="baseUpdate">String $"UPDATE {tabela} SET" para evitar criar uma nova string a cada iteração</param>
	/// <param name="columns">A propriedade <see cref="MemberInfo.Name"/> será usada como nome das colunas da base de dados</param>
	/// <param name="primaryKey">A propriedade que guarda os dados da chave primária</param>
	/// <param name="baseInsert">String base do INSERT (tudo até à parte "VALUES (" inclusive)</param>
	/// <param name="primaryKeyDefaultValue"></param>
	/// <param name="index">Indice da iteração para acrescentar aos nomes dos <paramref name="parameters"/> que serão criados</param>
	private static void BuildInsertOrUpdateCommand<T>(T entity, StringBuilder sbFinal, DynamicParameters parameters, string baseUpdate, List<PropertyInfo> columns,
		PropertyInfo primaryKey, string baseInsert, object primaryKeyDefaultValue, int index) where T : class, new()
	{
		object primaryKeyValue = primaryKey.GetValue(entity);
		//Se a chave primária for o valor por defeito, faz um INSERT
		if (primaryKeyValue.Equals(primaryKeyDefaultValue))
		{
			sbFinal.Append(baseInsert);

			//Isto só se faz se não for Autoincrement
			//sbFinal.Append(chavePrimaria.Name).Append(", ");
			//parametros.Add($"@{chavePrimaria.Name}{indice}", valorChavePrimaria);

			AssignValuesInsertOrReplace(entity, sbFinal, parameters, columns, index);
		}
		else //Caso contrário faz um UPDATE
		{
			sbFinal.Append(baseUpdate);

			columns.ForEach(c =>
			{
				string parameter = $"@{c.Name}{index}";
				parameters.Add(parameter, c.GetValue(entity));
				sbFinal.Append(c.Name).Append(" = ").Append(parameter).Append(", ");
			});

			string parameter = $"@{primaryKey.Name}{index}";
			sbFinal.Remove(sbFinal.Length - 2, 2)
				.Append(" WHERE ")
				.Append(primaryKey.Name)
				.Append(" = ")
				.Append(parameter)
				.AppendLine(";");

			parameters.Add(parameter, primaryKeyValue);
		}
	}

	/// <summary>
	/// Cria comando (INSERT OR) REPLACE INTO
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity"></param>
	/// <param name="sbFinal"></param>
	/// <param name="parameters"></param>
	/// <param name="columns"></param>
	/// <param name="primaryKey"></param>
	/// <param name="baseInsert"></param>
	/// <param name="i"></param>
	private static void BuildReplaceCommand<T>(T entity, StringBuilder sbFinal, DynamicParameters parameters,
		List<PropertyInfo> columns, PropertyInfo primaryKey, string baseInsert, int i) where T : class, new()
	{
		sbFinal.Append(baseInsert);

		AssignValueInsertOrReplace(entity, sbFinal, parameters, i, primaryKey);
		AssignValuesInsertOrReplace(entity, sbFinal, parameters, columns, i);
	}

	/// <summary>
	/// Método que serve apenas para se poder criar um <see cref="Delegate"/> com uma assinatura comum entre <see cref="BuildReplaceCommand"/> e <seealso cref="BuildInsertOrUpdateCommand"/>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entity"></param>
	/// <param name="sbFinal"></param>
	/// <param name="parameters"></param>
	/// <param name="baseUpdate"></param>
	/// <param name="columns"></param>
	/// <param name="primaryKey"></param>
	/// <param name="baseInsert"></param>
	/// <param name="primaryKeyDefaultValue"></param>
	/// <param name="index"></param>
	private static void BuildReplaceCommand_Aux<T>(T entity, StringBuilder sbFinal, DynamicParameters parameters, string baseUpdate, List<PropertyInfo> columns,
		PropertyInfo primaryKey, string baseInsert, object primaryKeyDefaultValue, int index) where T : class, new()
	{
		BuildReplaceCommand(entity, sbFinal, parameters, columns, primaryKey, baseInsert, index);
	}
}
