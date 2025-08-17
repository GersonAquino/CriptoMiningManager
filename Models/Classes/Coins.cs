using Models.JsonConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Models.Classes;

public class Coins
{
	public static Comparison<Coin> ProfitabilityComparison_Descending { get; } = new((m1, m2) => -m1.Profitability24.CompareTo(m2.Profitability24));

	/// <summary>
	/// Usar isto é desaconselhado, só está público para poder ser desserializado em condições. Usar <see cref="GetCoins"/>
	/// </summary>
	public CoinList coins { get; set; }

	/// <summary>
	/// Pega em todas as propriedades do tipo <see cref="Coin"/> em <see cref="coins"/> e passa-as para um <see cref="IEnumerable{T}"/> de <see cref="Coin"/>
	/// </summary>
	/// <returns></returns>
	public List<Coin> GetCoins()
	{
		if (this.coins == null)
			return null;

		PropertyInfo[] properties = this.coins.GetType().GetProperties();

		List<Coin> coins = new(properties.Length);
		foreach (PropertyInfo propriedade in properties)
		{
			if (propriedade.GetValue(this.coins) is Coin coin)
			{
				coin.ExternalName = propriedade.Name;
				coins.Add(coin);
			}
		}

		return coins;
	}
}

public class CoinList
{
	//public Moeda Aeternity { get; set; }
	//public Moeda Alephium { get; set; }
	//public Moeda Beam { get; set; }
	//public Moeda BitcoinGold { get; set; }
	//public Moeda BitcoinZ { get; set; }
	//public Moeda Bitnet { get; set; }

	//[JsonPropertyName("Bloc.money")]
	//public Moeda Blocmoney { get; set; }

	//public Moeda Callisto { get; set; }
	//public Moeda Canxium { get; set; }
	//public Moeda Clore { get; set; }
	//public Moeda Conceal { get; set; }
	//public Moeda Conflux { get; set; }
	//public Moeda Cortex { get; set; }
	//public Moeda Dynexcoin { get; set; }
	//public Moeda Equilibria { get; set; }
	//public Moeda Ergo { get; set; }
	//public Moeda EthereumClassic { get; set; }
	//public Moeda EthereumFair { get; set; }
	//public Moeda EtherGem { get; set; }
	//public Moeda EthereumPoW { get; set; }
	//public Moeda Etho { get; set; }
	//public Moeda Etica { get; set; }
	//public Moeda Firo { get; set; }
	//public Moeda Flux { get; set; }
	//public Moeda Frencoin { get; set; }
	//public Moeda GamePass { get; set; }
	//public Moeda Gemlink { get; set; }

	//[JsonPropertyName("Grin-CT32")]
	//public Moeda GrinCT32 { get; set; }

	//public Moeda HavenProtocol { get; set; }
	//public Moeda Karlsen { get; set; }
	//public Moeda Kiirocoin { get; set; }
	//public Moeda IronFish { get; set; }
	//public Moeda Meowcoin { get; set; }
	//public Moeda Neoxa { get; set; }
	//public Moeda Nexa { get; set; }
	//public Moeda Neurai { get; set; }

	[JsonPropertyName("Nicehash-Alephium")]
	public Coin NicehashAlephium { get; set; }

	[JsonPropertyName("Nicehash-Autolykos")]
	public Coin NicehashAutolykos { get; set; }

	[JsonPropertyName("Nicehash-BeamV3")]
	public Coin NicehashBeamV3 { get; set; }

	[JsonPropertyName("Nicehash-Cuckatoo32")]
	public Coin NicehashCuckatoo32 { get; set; }

	[JsonPropertyName("Nicehash-CuckooCycle")]
	public Coin NicehashCuckooCycle { get; set; }

	[JsonPropertyName("Nicehash-Etchash")]
	public Coin NicehashEtchash { get; set; }

	[JsonPropertyName("Nicehash-Ethash")]
	public Coin NicehashEthash { get; set; }

	[JsonPropertyName("Nicehash-IronFish")]
	public Coin NicehashIronFish { get; set; }

	[JsonPropertyName("Nicehash-KawPow")]
	public Coin NicehashKawPow { get; set; }

	[JsonPropertyName("Nicehash-NexaPow")]
	public Coin NicehashNexaPow { get; set; }

	[JsonPropertyName("Nicehash-Octopus")]
	public Coin NicehashOctopus { get; set; }

	[JsonPropertyName("Nicehash-ZelHash")]
	public Coin NicehashZelHash { get; set; }

	[JsonPropertyName("Nicehash-Zhash")]
	public Coin NicehashZhash { get; set; }

	//public Moeda OctaSpace { get; set; }
	//public Moeda Paprikacoin { get; set; }
	//public Moeda PowBlocks { get; set; }
	//public Moeda QuarkChain { get; set; }
	//public Moeda Radiant { get; set; }
	//public Moeda Ravencoin { get; set; }
	//public Moeda Rethereum { get; set; }
	//public Moeda Ryo { get; set; }
	//public Moeda Satoxcoin { get; set; }
	//public Moeda Sero { get; set; }
	//public Moeda Skydoge { get; set; }
	//public Moeda Vertcoin { get; set; }
	//public Moeda Zano { get; set; }
}

/// <summary>
/// Classe genérica com propriedades desnecessárias comentadas para evitar stresses e simplificar a leitura do JSON
/// </summary>
[System.ComponentModel.Description("Moeda"), Table("Coins")]
public class Coin
{
	/// <summary>
	/// Id utilizado internamente
	/// </summary>
	[Key, JsonIgnore(Condition = JsonIgnoreCondition.Always)]
	public int Id { get; set; }
	public string Name { get; set; }
	public string ExternalName { get; set; }

	//Propriedades vindas da API
	[JsonPropertyName("Id"), JsonConverter(typeof(IntConverter))]
	public int ExternalId { get; set; }

	[NotMapped]
	public string Tag { get; set; }

	[NotMapped]
	public string Algorithm { get; set; }
	//public object block_time { get; set; } //Às vezes é string, outras é um int
	//public decimal block_reward { get; set; }
	//public decimal block_reward24 { get; set; }
	//public int last_block { get; set; }
	//public decimal difficulty { get; set; }
	//public decimal difficulty24 { get; set; }

	[NotMapped]
	public long Nethash { get; set; }

	[JsonConverter(typeof(DecimalConverter)), NotMapped]
	public decimal Exchange_rate { get; set; }

	[JsonConverter(typeof(DecimalConverter)), NotMapped]
	public decimal Exchange_rate24 { get; set; }

	[JsonConverter(typeof(DecimalConverter)), NotMapped]
	public decimal Exchange_rate_vol { get; set; }

	[NotMapped]
	public string Exchange_rate_curr { get; set; }

	[NotMapped]
	public string Market_cap { get; set; }

	[JsonConverter(typeof(DecimalConverter)), NotMapped]
	public decimal Estimated_rewards { get; set; }

	[JsonConverter(typeof(DecimalConverter)), NotMapped]
	public decimal Estimated_rewards24 { get; set; }

	/// <summary>
	/// Quantidade de BTC ganha por dia
	/// </summary>
	[JsonPropertyName("Btc_revenue"), JsonConverter(typeof(DecimalConverter)), NotMapped()]
	public decimal BtcPorDia { get; set; }

	[JsonConverter(typeof(DecimalConverter)), NotMapped()]
	public decimal Btc_revenue24 { get; set; }

	[JsonConverter(typeof(IntConverter)), NotMapped()]
	public int Profitability { get; set; }

	[JsonConverter(typeof(IntConverter)), NotMapped()]
	public int Profitability24 { get; set; }

	[NotMapped]
	public bool Lagging { get; set; }

	[JsonConverter(typeof(IntConverter)), NotMapped()]
	public int Timestamp { get; set; }

	public Coin()
	{
		Id = -1;
	}

	public override string ToString()
	{
		return $"{Id} - {Name} - {BtcPorDia} BTC/Dia";
	}
}