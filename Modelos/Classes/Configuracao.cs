using System;

namespace Modelos.Classes
{
    public class Configuracao
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
