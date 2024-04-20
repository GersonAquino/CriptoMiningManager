using Dapper;
using Modelos.Classes;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDados.Helpers.Entidades
{
    public class MoedasHelper : IEntidadesHelper<Moeda>
    {
        private const string Tabela = "Moedas";

        private IDados Dados { get; set; }

        public MoedasHelper(IDados dados)
        {
            Dados = dados;
        }

        public async Task<int> EliminarEntidades(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Moeda>> GetEntidades(string condicoes = null, string ordenacao = null)
        {
            string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);

            return await Dados.QueryOpenAsync<Moeda>(query);
        }

        public async Task<IEnumerable<Moeda>> GetEntidades(string condicoes, string ordenacao, params (string parametro, object valor)[] parametros)
        {
            string query = QueryHelper.Select("*", Tabela, condicoes, ordenacao);

            DynamicParameters parametrosDapper = new DynamicParameters();
            for (int i = 0; i < parametros.Length; i++)
            {
                parametrosDapper.Add(parametros[i].parametro, parametros[i].valor);
            }

            return await Dados.QueryOpenAsync<Moeda>(query, parametrosDapper);
        }

        public async Task<Dictionary<int, Moeda>> GetEntidadesComLista(string condicoes = null, string ordenacao = null)
        {
            return (await GetEntidades(condicoes, ordenacao)).ToDictionary(m => m.Id);
        }

        public async Task<bool> GravarEntidade(Moeda moeda)
        {
            return await Dados.ExecuteOpenAsync(GravarEntidade_Base(moeda), moeda) == 1;
        }

        public async Task<int> GravarEntidade_GetIdGerado(Moeda moeda)
        {
            if (moeda.Id == -1)
            {
                string query = GravarEntidade_Base(moeda) + "; SELECT LAST_INSERT_ROWID();";
                return await Dados.ExecuteScalarOpenAsync<int, Moeda>(query, moeda);
            }

            return await GravarEntidade(moeda) ? moeda.Id : -1;
        }

        //FUNÇÕES AUXILIARES
        private string GravarEntidade_Base(Moeda moeda)
        {
            if (moeda.Id < -1)
                throw new ArgumentException($"Moeda tem Id inválido ({moeda.Id}).");

            string query;

            //Inserir caso Id seja um valor inválido mas esperado
            if (moeda.Id == -1)
            {
                query = QueryHelper.InsertParametrizado(Tabela, "IdExterno", "Nome");
            }
            else //Atualizar caso tenha Id válido
            {
                query = QueryHelper.UpdateParametrizado(Tabela, "Id = @Id", "IdExterno", "Nome");

                //moeda.DataAlteracao = DateTime.Now;
            }
            return query;
        }
    }
}
