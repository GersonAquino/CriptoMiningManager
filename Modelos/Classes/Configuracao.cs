using System;
using System.ComponentModel;

namespace Modelos.Classes
{
    [Description("Configuração")]
    public class Configuracao
    {
        public int Id { get; set; } = -1;
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
