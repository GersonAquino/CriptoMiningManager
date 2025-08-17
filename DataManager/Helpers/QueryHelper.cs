using System.Text;

namespace DataManager.Helpers;

internal static class QueryHelper
{
	/// <summary>
	/// Constroi um comando SQL com um DELETE
	/// </summary>
	/// <param name="table"></param>
	/// <param name="conditions">Parâmetro obrigatório para não apagar os dados inteiros duma tabela acidentalmente</param>
	/// <returns></returns>
	internal static string Delete(string table, string conditions)
	{
		return $"DELETE FROM {table} {(string.IsNullOrWhiteSpace(conditions) ? "" : $"WHERE {conditions}")}";
	}

	/// <summary>
	/// Constroi um comando SQL com um INSERT e parâmetros para o Dapper ou SqlParameters
	/// </summary>
	/// <param name="table"></param>
	/// <param name="columns"></param>
	/// <returns></returns>
	internal static string ParameterizedInsert(string table, params string[] columns)
	{
		StringBuilder sbInsert = new($"INSERT INTO {table} (");
		StringBuilder sbValores = new(") VALUES (");

		for (int i = 0; i < columns.Length; i++)
		{
			string coluna = $"{columns[i]}, ";
			sbInsert.Append(coluna);
			sbValores.Append('@').Append(coluna);
		}
		sbInsert.Remove(sbInsert.Length - 2, 2);
		sbValores.Remove(sbValores.Length - 2, 2).Append(')');

		return sbInsert.Append(sbValores).ToString();
	}

	/// <summary>
	/// Constroi uma query SQL
	/// </summary>
	/// <param name="campos"></param>
	/// <param name="tabelas"></param>
	/// <param name="condicoes"></param>
	/// <param name="ordenacao"></param>
	/// <param name="limit">Equivalente ao TOP em SQL Server</param>
	/// <returns></returns>
	internal static string Select(string campos, string tabelas, string condicoes = null, string ordenacao = null, int? limit = null)
	{
		StringBuilder query = new StringBuilder("SELECT ").AppendLine(campos)
			.Append("FROM ").AppendLine(tabelas);

		if (!string.IsNullOrWhiteSpace(condicoes))
			query.Append("WHERE ").AppendLine(condicoes);

		if (!string.IsNullOrWhiteSpace(ordenacao))
			query.Append("ORDER BY ").AppendLine(ordenacao);

		if (limit.HasValue)
			query.Append("LIMIT ").Append(limit.Value);

		return query.Append(';').ToString();
	}

	/// <summary>
	/// Constroi um comando SQL com um UPDATE e parâmetros para o Dapper ou SqlParameters
	/// </summary>
	/// <param name="table"></param>
	/// <param name="conditions"></param>
	/// <param name="columns"></param>
	/// <returns></returns>
	internal static string ParameterizedUpdate(string table, string conditions, params string[] columns)
	{
		StringBuilder sbUpdate = new StringBuilder($"UPDATE ").Append(table).Append(" SET ");

		for (int i = 0; i < columns.Length; i++)
		{
			sbUpdate.Append(columns[i]).Append(" = @").Append(columns[i]).Append(", ");
		}

		return sbUpdate.Remove(sbUpdate.Length - 2, 2).Append(" WHERE ").Append(conditions).ToString();
	}
}
