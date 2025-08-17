using System.ComponentModel;

namespace Models.Enums;

public enum Algorithm
{
	[Description("Moeda")]
	Coin,

	[Description("Mais Rentável")]
	MostProfitable,

	[Description("Selecionado")]
	Selected
}
