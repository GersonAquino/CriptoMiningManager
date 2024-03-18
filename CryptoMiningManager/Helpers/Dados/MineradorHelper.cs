using Modelos.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMiningManager.Helpers.Dados
{
    internal static class MineradorHelper
    {
        /// <summary>
        /// Obtém todos os <see cref="Minerador"/> e respetivas <see cref="Minerador.Moedas"/>
        /// </summary>
        /// <param name="condicoes"></param>
        /// <param name="ordenacao"></param>
        /// <returns>Dicionário de int e <see cref="Minerador"/> em que a chave é o Id do Minerador</returns>
        internal static async Task<Dictionary<int, Minerador>> GetMineradoresComMoedas(string condicoes = null, string ordenacao = null)
        {
            string query = QueryHelper.Select("mi.*, mo.Id, mo.Nome",
                @"Mineradores mi
                            LEFT JOIN Moedas mo
                                ON mi.Id = mo.IdMinerador", condicoes, ordenacao);

            Dictionary<int, Minerador> mineradores = new Dictionary<int, Minerador>();

            Func<Minerador, Moeda, Minerador> mapeamento = (minerador, moeda) =>
            {
                if (!mineradores.TryGetValue(minerador.Id, out Minerador mineradorExistente))
                {
                    mineradorExistente = minerador;
                    mineradorExistente.Moedas = new List<Moeda>();
                    mineradores.Add(mineradorExistente.Id, mineradorExistente);
                }

                mineradorExistente.Moedas.Add(moeda);

                //O return aqui é o que vai ser devolvido para o IEnumerable<Minerador> que o Dapper está a criar
                //Como não vai ser usado, mais vale que fique cheio de nulls
                return null;
            };

            await Program.Dados.QueryOpenAsync(query, mapeamento, "Id");
            return mineradores;
        }
    }
}
