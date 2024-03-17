namespace Modelos.Classes
{
    public class Comando : Configuracao
    {
        public string Comandos { get; set; }
        public bool PreMineracao { get; set; }
        public bool PosMineracao { get; set; }
    }
}
