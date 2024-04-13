using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
    public class MineradorHelper : IEntidadesHelper<Minerador>
    {
        private const string Tabela = "Mineradores";

        private IDados Dados { get; set; }

        public MineradorHelper(IDados dados)
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
        public async Task<IEnumerable<Minerador>> GetEntidades(string condicoes = null, string ordenacao = null)
        {
            string query = QueryHelper.Select("mi.*", "Mineradores mi", condicoes, ordenacao);
            return await Dados.QueryOpenAsync<Minerador>(query);
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
            return await Dados.ExecuteOpenAsync(GravarEntidade_Base(minerador), minerador) == 1;
        }

        public async Task<int> GravarEntidade_GetIdGerado(Minerador minerador)
        {
            if (minerador.Id == -1)
            {
                string query = GravarEntidade_Base(minerador) + "; SELECT LAST_INSERT_ROWID();";
                return await Dados.ExecuteScalarOpenAsync<int, Minerador>(query, minerador);
            }

            return await GravarEntidade(minerador) ? minerador.Id : -1;
        }

        //FUNÇÕES AUXILIARES
        private string GravarEntidade_Base(Minerador minerador)
        {
            if (minerador.Id < -1)
                throw new ArgumentException($"Minerador tem Id inválido ({minerador.Id}).");

            string query;

            //Inserir caso Id seja um valor inválido mas esperado
            if (minerador.Id == -1)
            {
                query = QueryHelper.InsertParametrizado(Tabela, "Localizacao", "Parametros", "Ativo");
            }
            else //Atualizar caso tenha Id válido
            {
                query = QueryHelper.UpdateParametrizado(Tabela, "Id = @Id", "Localizacao", "Parametros", "Ativo", "DataAlteracao");

                minerador.DataAlteracao = DateTime.Now;
            }
            return query;
        }
    }
}
