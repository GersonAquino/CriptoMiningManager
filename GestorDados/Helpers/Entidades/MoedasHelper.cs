using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
	public class MoedasHelper : EntidadesHelper<Moeda>
	{
		private IHttpHelper HttpHelper { get; set; }

		public MoedasHelper(IDados dados, IHttpHelper httpHelper) : base(dados)
		{
			HttpHelper = httpHelper;
		}

		public override async Task<List<Moeda>> GravarEntidades(IEnumerable<Moeda> entidades = null)
		{
			if (entidades == null) //Isto significa que se estão apenas a obter dados da API e não exatamente a gravar dados alterados pelo utilizador
			{
				List<Moeda> moedasAPI = (await HttpHelper.PedidoGETHttpSingle<Moedas>(null)).GetMoedas();
				Dictionary<int, Moeda> moedasExistentes = (await GetEntidades("IdExterno IN @IdsExternos", null,
					("IdsExternos", moedasAPI.Select(m => m.IdExterno)))).ToDictionary(m => m.IdExterno);

				moedasAPI.ForEach(moeda =>
				{
					if (moedasExistentes.TryGetValue(moeda.IdExterno, out Moeda moedaExistente))
					{
						moeda.Id = moedaExistente.Id;
						moeda.Nome = moedaExistente.Nome;
						moeda.DataCriacao = moedaExistente.DataCriacao;
						moeda.DataAlteracao = moedaExistente.DataAlteracao;
					}
					else
					{
						moeda.Id = -1;
						moeda.Nome = null;
						moeda.DataCriacao = DateTime.Now;
						moeda.DataAlteracao = DateTime.Now;
					}
				});

				await Dados.BulkMerge(moedasAPI);

				return moedasAPI;
			}
			else
			{
				List<Moeda> entidadesList = entidades.ToList();
				entidadesList.ForEach(m => m.DataAlteracao = DateTime.Now);

				await Dados.BulkMerge(entidadesList);

				return entidadesList;
			}

		}
	}
}
