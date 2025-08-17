using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Classes;

[Description("Minerador"), Table("Miners")]
public class Miner : Configuration
{
	public string Name { get; set; }
	public string Location { get; set; }
	public string Parameters { get; set; }

	public int? CoinId { get => Coin?.Id; }

	[NotMapped]
	public Coin Coin { get; set; }

	public Miner() { }

	public override string ToString()
	{
		return $"{Id} - {Name}";
	}
}
