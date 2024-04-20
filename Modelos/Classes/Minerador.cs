using System.Collections.Generic;
using System.ComponentModel;

namespace Modelos.Classes
{
    [Description("Minerador")]
    public class Minerador : Configuracao
    {
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string Parametros { get; set; }

        public List<Moeda> Moedas { get; set; }

        public Minerador()
        {
            Moedas = new List<Moeda>();
        }
    }
}
