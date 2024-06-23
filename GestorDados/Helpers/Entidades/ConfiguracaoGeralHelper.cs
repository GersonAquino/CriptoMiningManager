using Modelos.Classes;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
	public class ConfiguracaoGeralHelper : EntidadesHelper<ConfiguracaoGeral>
	{
		public ConfiguracaoGeralHelper(IDados dados) : base(dados) { }

		//FUNÇÕES AUXILIARES
		protected override async Task GravarEntidade_ValidacoesExtra_Async(ConfiguracaoGeral entidade)
		{
			if (entidade.Ativo)
			{
				string query = QueryHelper.Select("Id", Tabela, $"Ativo = 1 AND Id != {entidade.Id}", limit: 1);

				int? idExistente = await Dados.ExecuteScalarOpenAsync<int?>(query);
				if (idExistente.HasValue)
					throw new CustomException("Já existe uma configuração geral ativa.", "Configuração geral ativa já existente");
			}
		}
	}
}
