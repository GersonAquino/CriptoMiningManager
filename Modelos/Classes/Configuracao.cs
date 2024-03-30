using System;
using System.ComponentModel;

namespace Modelos.Classes
{
    [Description("Configuração")]
    public class Configuracao
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
