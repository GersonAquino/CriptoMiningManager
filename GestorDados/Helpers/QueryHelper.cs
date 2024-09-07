using System.Text;

namespace GestorDados.Helpers
{
	internal static class QueryHelper
	{
		/// <summary>
		/// Constroi um comando SQL com um DELETE
		/// </summary>
		/// <param name="tabela"></param>
		/// <param name="condicoes">Parâmetro obrigatório para não apagar os dados inteiros duma tabela acidentalmente</param>
		/// <returns></returns>
		internal static string Delete(string tabela, string condicoes)
		{
			return $"DELETE FROM {tabela} {(string.IsNullOrWhiteSpace(condicoes) ? "" : $"WHERE {condicoes}")}";
		}

		/// <summary>
		/// Constrói um comando SQL com um INSERT e parâmetros para o Dapper ou SqlParameters
		/// </summary>
		/// <param name="tabela"></param>
		/// <param name="colunas"></param>
		/// <returns></returns>
		internal static string InsertParametrizado(string tabela, params string[] colunas)
		{
			StringBuilder sbInsert = new($"INSERT INTO {tabela} (");
			StringBuilder sbValores = new(") VALUES (");

			for (int i = 0; i < colunas.Length; i++)
			{
				string coluna = $"{colunas[i]}, ";
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
		/// Constrói um comando SQL com um UPDATE e parâmetros para o Dapper ou SqlParameters
		/// </summary>
		/// <param name="tabela"></param>
		/// <param name="condicoes"></param>
		/// <param name="colunas"></param>
		/// <returns></returns>
		internal static string UpdateParametrizado(string tabela, string condicoes, params string[] colunas)
		{
			StringBuilder sbUpdate = new StringBuilder($"UPDATE ").Append(tabela).Append(" SET ");

			for (int i = 0; i < colunas.Length; i++)
			{
				sbUpdate.Append(colunas[i]).Append(" = @").Append(colunas[i]).Append(", ");
			}

			return sbUpdate.Remove(sbUpdate.Length - 2, 2).Append(" WHERE ").Append(condicoes).ToString();
		}
	}
}
