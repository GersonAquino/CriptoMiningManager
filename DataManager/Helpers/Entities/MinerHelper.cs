using Dapper;
using Models.Classes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManager.Helpers.Entities;

public class MineradorHelper : IEntityHelper<Miner>
{
	private const string Tabela = "Mineradores";

	private IData Dados { get; set; }

	public MineradorHelper(IData dados)
	{
		Dados = dados;
	}

	///<inheritdoc/>
	public async Task<int> EliminarEntidades(IEnumerable<int> ids)
	{
		string query = QueryHelper.Delete(Tabela, "Id IN @Ids");

		return await Dados.ExecuteOpenAsync(query, new { Ids = ids });
	}

	///<inheritdoc/>
	public async Task<IEnumerable<Miner>> GetEntidades(string condicoes = null, string ordenacao = null)
	{
		string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);
		return await Dados.QueryOpenAsync<Miner>(query);
	}

	///<inheritdoc/>
	public async Task<IEnumerable<Miner>> GetEntidades(string condicoes, string ordenacao, params (string parametro, object valor)[] parametros)
	{
		string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);

		DynamicParameters parametrosDapper = new DynamicParameters();
		for (int i = 0; i < parametros.Length; i++)
		{
			parametrosDapper.Add(parametros[i].parametro, parametros[i].valor);
		}

		return await Dados.QueryOpenAsync<Miner>(query, parametrosDapper);
	}

	///<inheritdoc/>
	public async Task<Dictionary<int, Miner>> GetEntidadesComLista(string condicoes = null, string ordenacao = null)
	{
		string query = QueryHelper.Select("mi.*, mo.*",
			@"Mineradores mi
                            LEFT JOIN Moedas mo
                                ON mo.Id = mi.IdMoeda", condicoes, ordenacao);

		Dictionary<int, Miner> mineradores = new Dictionary<int, Miner>();

		//Função para mapear as moedas com os mineradores
		Func<Miner, Coin, Miner> mapeamento = (minerador, moeda) =>
		{
			if (!mineradores.TryGetValue(minerador.Id, out Miner mineradorExistente))
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

	///<inheritdoc/>
	public async Task<bool> GravarEntidade(Miner minerador)
	{
		return await Dados.ExecuteOpenAsync(GravarEntidade_Base(minerador), minerador) == 1;
	}

	public async Task<int> GravarEntidade_GetIdGerado(Miner minerador)
	{
		if (minerador.Id == -1)
		{
			string query = GravarEntidade_Base(minerador) + "; SELECT LAST_INSERT_ROWID();";
			return await Dados.ExecuteScalarOpenAsync<int, Miner>(query, minerador);
		}

		return await GravarEntidade(minerador) ? minerador.Id : -1;
	}

	//FUNÇÕES AUXILIARES
	private string GravarEntidade_Base(Miner minerador)
	{
		if (minerador.Id < -1)
			throw new ArgumentException($"Minerador tem Id inválido ({minerador.Id}).");

		string query;

		//Inserir caso Id seja um valor inválido mas esperado
		if (minerador.Id == -1)
		{
			query = QueryHelper.InsertParametrizado(Tabela, "Ativo", "IdMoeda", "Localizacao", "Nome", "Parametros");
		}
		else //Atualizar caso tenha Id válido
		{
			query = QueryHelper.UpdateParametrizado(Tabela, "Id = @Id", "Ativo", "IdMoeda", "Localizacao", "Nome", "Parametros", "DataAlteracao");

			minerador.DataAlteracao = DateTime.Now;
		}
		return query;
	}

	public Task<List<Miner>> GravarEntidades(IEnumerable<Miner> entidades = null)
	{
		throw new NotImplementedException();
	}
}
