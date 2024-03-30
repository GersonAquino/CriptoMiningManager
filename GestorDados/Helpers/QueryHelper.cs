namespace GestorDados.Helpers
{
    internal static class QueryHelper
    {
        internal static string Select(string campos, string tabelas, string condicoes = null, string ordenacao = null)
        {
            return $@"SELECT {campos}
                        FROM {tabelas}
                        {(string.IsNullOrWhiteSpace(condicoes) ? "" : $"WHERE {condicoes}")}
                        {(string.IsNullOrWhiteSpace(ordenacao) ? "" : $"ORDER BY {ordenacao}")}";
        }
    }
}
