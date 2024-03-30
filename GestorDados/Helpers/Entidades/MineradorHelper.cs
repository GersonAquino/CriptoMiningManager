using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
    public class MineradorHelper : IEntidadesHelper<Minerador>
    {
        private IDados Dados { get; set; }

        public MineradorHelper(IDados dados)
        {
            Dados = dados;
        }

        ///<inheritdoc/>
        public async Task<int> EliminarEntidades(IEnumerable<int> ids)
        {
            string query = $@"DELETE FROM Mineradores
                                WHERE Id IN @Ids";

            return await Dados.ExecuteOpenAsync(query, new { Ids = ids });
        }

        ///<inheritdoc/>
        public async Task<Dictionary<int, Minerador>> GetEntidadesComLista(string condicoes = null, string ordenacao = null)
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

        ///<inheritdoc/>
        public async Task<bool> GravarEntidade(Minerador minerador)
        {
            if (minerador.Id < -1)
                throw new ArgumentException($"Minerador tem Id inválido ({minerador.Id}).");

            string query;

            //Inserir caso Id seja um valor inválido mas esperado
            if (minerador.Id == -1)
            {
                query = @"INSERT INTO Mineradores (Localizacao, Parametros, Ativo)
                            VALUES (@Localizacao, @Parametros, @Ativo)";
            }
            else //Atualizar caso tenha Id válido
            {
                query = @"UPDATE Mineradores
                            SET Localizacao = @Localizacao,
                                Parametros = @Parametros,
                                Ativo = @Ativo,
                                DataAlteracao = @DataAlteracao
                            WHERE Id = @Id";

                minerador.DataAlteracao = DateTime.Now;
            }

            return await Dados.ExecuteOpenAsync(query, minerador) == 1;
        }
    }
}
