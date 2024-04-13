using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
    public class ComandoHelper : IEntidadesHelper<Comando>
    {
        private const string Tabela = "Comandos";

        private IDados Dados { get; set; }

        public ComandoHelper(IDados dados)
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
        public async Task<IEnumerable<Comando>> GetEntidades(string condicoes = null, string ordenacao = null)
        {
            string query = QueryHelper.Select("c.*", "Comandos c", condicoes, ordenacao);

            return await Dados.QueryOpenAsync<Comando>(query);
        }

        ///<inheritdoc/>
        public async Task<Dictionary<int, Comando>> GetEntidadesComLista(string condicoes = null, string ordenacao = null)
        {
            return (await GetEntidades(condicoes, ordenacao)).ToDictionary(c => c.Id);
        }

        ///<inheritdoc/>
        public async Task<bool> GravarEntidade(Comando comando)
        {
            return await Dados.ExecuteOpenAsync(GravarEntidade_Base(comando), comando) == 1;
        }

        ///<inheritdoc/>
        public async Task<int> GravarEntidade_GetIdGerado(Comando comando)
        {
            if (comando.Id == -1)
            {
                string query = GravarEntidade_Base(comando) + "; SELECT LAST_INSERT_ROWID();";
                return await Dados.ExecuteScalarOpenAsync<int, Comando>(query, comando);
            }
            
            return await GravarEntidade(comando) ? comando.Id : -1;
        }

        //FUNÇÕES AUXILIARES
        private string GravarEntidade_Base(Comando comando)
        {
            if (comando.Id < -1)
                throw new ArgumentException($"Comando tem Id inválido ({comando.Id}).");

            string query;

            //Inserir caso Id seja um valor inválido, mas esperado
            if (comando.Id == -1)
            {
                query = QueryHelper.InsertParametrizado(Tabela, "Comandos", "PreMineracao", "PosMineracao", "Ativo");
            }
            else //Atualizar caso tenha Id válido
            {
                query = QueryHelper.UpdateParametrizado(Tabela, "Id = @Id", "Comandos", "PreMineracao", "PosMineracao", "Ativo", "DataAlteracao");

                comando.DataAlteracao = DateTime.Now;
            }

            return query;
        }
    }
}
