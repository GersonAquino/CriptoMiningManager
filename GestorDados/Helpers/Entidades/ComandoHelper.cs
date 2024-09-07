using Modelos.Classes;
using Modelos.Exceptions;
using Modelos.Interfaces;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
	public class ComandoHelper : EntidadesHelper<Comando>
	{
		public ComandoHelper(IDados dados) : base(dados) { }

		protected override void GravarEntidade_ValidacoesExtra(Comando entidade)
		{
			if (entidade.Ativo)
			{
				if (!entidade.PreMineracao && !entidade.PosMineracao)
					throw new CustomException("Por favor defina o tipo de comando (Pré-Mineração, Pós-Mineração ou ambos) antes de o definir como 'Ativo'.", "Comando inválido");

				string tipoComando;
				if (entidade.PreMineracao)
				{
					tipoComando = "AND PreMineracao = 1";
					if (entidade.PosMineracao)
						tipoComando += " OR PosMineracao = 1";
				}
				else
					tipoComando = "AND PosMineracao = 1";

				string query = QueryHelper.Select("Id", Tabela,
					$"Ativo = 1 {tipoComando}{(entidade.Id != -1 ? $" AND Id != {entidade.Id}" : "")}", limit: 1);

				int? idExistente = Dados.ExecuteScalarOpen<int?>(query);
				if (idExistente.HasValue)
					throw new CustomException("Já existe um comando ativo com as definições de Pré/Pós-Mineracao.", "Comando ativo do mesmo tipo já existente");
			}
		}
	}
}
