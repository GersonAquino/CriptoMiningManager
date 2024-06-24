using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Classes
{
	[Description("Minerador"), Table("Mineradores")]
	public class Minerador : Configuracao
	{
		public int? IdMoeda { get => Moeda?.Id; }

		public bool CPU { get; set; }
		public bool GPU { get; set; }

		/// <summary>
		/// Consumo médio (em Watts) do(s) componente(s) utilizado(s) na mineração
		/// </summary>
		public decimal ConsumoMedio { get; set; }

		public string Nome { get; set; }
		public string Localizacao { get; set; }
		public string Parametros { get; set; }

		[NotMapped]
		public Moeda Moeda { get; set; }

		public Minerador() { }

		public override string ToString()
		{
			return $"{Id} - {Nome}";
		}
	}
}
