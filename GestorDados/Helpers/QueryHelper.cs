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
        /// Constroi um comando SQL com um INSERT e parâmetros para o Dapper ou SqlParameters
        /// </summary>
        /// <param name="tabela"></param>
        /// <param name="colunas"></param>
        /// <returns></returns>
        internal static string InsertParametrizado(string tabela, params string[] colunas)
        {
            StringBuilder sbInsert = new StringBuilder($"INSERT INTO {tabela} (");
            StringBuilder sbValores = new StringBuilder(") VALUES (");

            for (int i = 0; i < colunas.Length; i++)
            {
                string coluna = $"{colunas[i]}, ";
                sbInsert.Append(coluna);
                sbValores.Append($"@{coluna}");
            }

            return sbInsert.ToString(0, sbInsert.Length - 2) + sbValores.Remove(sbValores.Length - 2, 2).Append(")").ToString();
        }

        /// <summary>
        /// Constroi uma query SQL
        /// </summary>
        /// <param name="campos"></param>
        /// <param name="tabelas"></param>
        /// <param name="condicoes"></param>
        /// <param name="ordenacao"></param>
        /// <returns></returns>
        internal static string Select(string campos, string tabelas, string condicoes = null, string ordenacao = null)
        {
            return $@"SELECT {campos}
                        FROM {tabelas}
                        {(string.IsNullOrWhiteSpace(condicoes) ? "" : $"WHERE {condicoes}")}
                        {(string.IsNullOrWhiteSpace(ordenacao) ? "" : $"ORDER BY {ordenacao}")}";
        }

        /// <summary>
        /// Constroi um comando SQL com um UPDATE e parâmetros para o Dapper ou SqlParameters
        /// </summary>
        /// <param name="tabela"></param>
        /// <param name="condicoes"></param>
        /// <param name="colunas"></param>
        /// <returns></returns>
        internal static string UpdateParametrizado(string tabela, string condicoes, params string[] colunas)
        {
            StringBuilder sbUpdate = new StringBuilder($"UPDATE {tabela} SET ");

            for (int i = 0; i < colunas.Length; i++)
            {
                sbUpdate.Append($"{colunas[i]} = @{colunas[i]}, ");
            }

            return $@"{sbUpdate.ToString(0, sbUpdate.Length - 2)} WHERE {condicoes}";
        }
    }
}
