using System.Collections.Generic;

namespace Modelos.Classes
{
    public class Minerador : Configuracao
    {
        public int IdExterno { get; set; }
        public string Localizacao { get; set; }
        public string Parametros { get; set; }

        public List<Moeda> Moedas { get; set; }

        public Minerador()
        {
            Moedas = new List<Moeda>();
        }
    }
}
