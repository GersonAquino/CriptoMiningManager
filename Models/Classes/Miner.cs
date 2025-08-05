using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Classes;

[Description("Minerador"), Table("Mineradores")]
public class Miner : Configuration
{
	public string Nome { get; set; }
	public string Localizacao { get; set; }
	public string Parametros { get; set; }

	public int? IdMoeda { get => Moeda?.Id; }

	[NotMapped]
	public Coin Moeda { get; set; }

	public Miner() { }

	public override string ToString()
	{
		return $"{Id} - {Nome}";
	}
}
