using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
	public class MineradorHelper : EntidadesHelper<Minerador>
	{
		public MineradorHelper(IDados dados) : base(dados) { }

		///<inheritdoc/>
		public override async Task<Dictionary<int, Minerador>> GetEntidadesComLista(string condicoes = null, string ordenacao = null)
		{
			string query = QueryHelper.Select("mi.*, mo.*",
				@"Mineradores mi
                            LEFT JOIN Moedas mo
                                ON mo.Id = mi.IdMoeda", condicoes, ordenacao);

			Dictionary<int, Minerador> mineradores = new();

			//Função para mapear as moedas com os mineradores
			Func<Minerador, Moeda, Minerador> mapeamento = (minerador, moeda) =>
			{
				if (!mineradores.TryGetValue(minerador.Id, out Minerador mineradorExistente))
				{
					mineradorExistente = minerador;
					mineradores.Add(mineradorExistente.Id, mineradorExistente);
				}

				if (moeda != null)
					mineradorExistente.Moeda = moeda;

				//O return aqui é o que vai ser devolvido para o IEnumerable<Minerador> que o Dapper está a criar
				//Como não vai ser usado, mais vale que fique cheio de nulls
				return null;
			};

			//Não se guarda o resultado porque os dados serão preenchidos corretamente no Dictionary<int, Minerador>
			await Dados.QueryOpenAsync(query, mapeamento, "Id");
			return mineradores;
		}


		//FUNÇÕES AUXILIARES
		protected override void GravarEntidade_ValidacoesExtra(Minerador entidade)
		{
			if (!entidade.CPU && !entidade.GPU)
				throw new ArgumentException("Minerador não tem nenhum tipo de componente selecionado.");
		}
	}
}
