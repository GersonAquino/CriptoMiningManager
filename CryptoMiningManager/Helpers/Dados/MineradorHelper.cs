using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoMiningManager.Helpers.Dados
{
    internal class MineradorHelper
    {
        private IDados Dados { get; }

        public MineradorHelper(IDados dados)
        {
            Dados = dados;
        }

        /// <summary>
        /// Obtém todos os <see cref="Minerador"/> e respetivas <see cref="Minerador.Moedas"/>
        /// </summary>
        /// <param name="condicoes"></param>
        /// <param name="ordenacao"></param>
        /// <returns>Dicionário de int e <see cref="Minerador"/> em que a chave é o Id do Minerador</returns>
        internal async Task<Dictionary<int, Minerador>> GetMineradoresComMoedas(string condicoes = null, string ordenacao = null)
        {
            string query = QueryHelper.Select("mi.*, mo.Id, mo.Nome",
                @"Mineradores mi
                            LEFT JOIN Moedas mo
                                ON mi.Id = mo.IdMinerador", condicoes, ordenacao);

            Dictionary<int, Minerador> mineradores = new Dictionary<int, Minerador>();

            //Função para mapear as moedas com os mineradores
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

            //Não se guarda o resultado porque os dados serão preenchidos corretamente no Dictionary<int, Minerador>
            await Dados.QueryOpenAsync(query, mapeamento, "Id");
            return mineradores;
        }

        /// <summary>
        /// Elimina da base de dados todos os mineradores com os <paramref name="ids"/> recebidos
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        internal async Task<int> EliminarMineradores(IEnumerable<int> ids)
        {
            string query = $@"DELETE FROM Mineradores
                                WHERE Id IN('{string.Join("', '", ids)}')";

            return await Dados.ExecuteOpenAsync(query);
        }
    }
}
