using Modelos.JsonConverters;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Modelos.Classes
{
    public class Moedas
    {
        /// <summary>
        /// Usar isto é desaconselhado, só está público para poder ser desserializado em condições. Usar <see cref="GetMoedas"/>
        /// </summary>
        public ListaMoedas coins { get; set; }

        /// <summary>
        /// Pega em todas as propriedades do tipo <see cref="Moeda"/> em <see cref="coins"/> e passa-as para um <see cref="IEnumerable{T}"/> de <see cref="Moeda"/>
        /// </summary>
        /// <returns></returns>
        public List<Moeda> GetMoedas()
        {
            if (coins == null)
                return null;

            PropertyInfo[] propriedades = coins.GetType().GetProperties();

            List<Moeda> moedas = new List<Moeda>(propriedades.Length);
            foreach (PropertyInfo propriedade in propriedades)
            {
                if (propriedade.GetValue(coins) is Moeda moeda)
                {
                    moeda.Nome = propriedade.Name;
                    moedas.Add(moeda);
                }
            }

            return moedas;
        }
    }

    public class ListaMoedas
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
        public Moeda NicehashAlephium { get; set; }

        [JsonPropertyName("Nicehash-Autolykos")]
        public Moeda NicehashAutolykos { get; set; }

        [JsonPropertyName("Nicehash-BeamV3")]
        public Moeda NicehashBeamV3 { get; set; }

        [JsonPropertyName("Nicehash-Cuckatoo32")]
        public Moeda NicehashCuckatoo32 { get; set; }

        [JsonPropertyName("Nicehash-CuckooCycle")]
        public Moeda NicehashCuckooCycle { get; set; }

        [JsonPropertyName("Nicehash-Etchash")]
        public Moeda NicehashEtchash { get; set; }

        [JsonPropertyName("Nicehash-Ethash")]
        public Moeda NicehashEthash { get; set; }

        [JsonPropertyName("Nicehash-IronFish")]
        public Moeda NicehashIronFish { get; set; }

        [JsonPropertyName("Nicehash-KawPow")]
        public Moeda NicehashKawPow { get; set; }

        [JsonPropertyName("Nicehash-NexaPow")]
        public Moeda NicehashNexaPow { get; set; }

        [JsonPropertyName("Nicehash-Octopus")]
        public Moeda NicehashOctopus { get; set; }

        [JsonPropertyName("Nicehash-ZelHash")]
        public Moeda NicehashZelHash { get; set; }

        [JsonPropertyName("Nicehash-Zhash")]
        public Moeda NicehashZhash { get; set; }

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
    [System.ComponentModel.Description("Moeda")]
    public class Moeda
    {
        /// <summary>
        /// Id utilizado internamente
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int Id { get; set; }
        public int? IdMinerador { get; set; }
        public string Nome { get; set; }

        //Propriedades vindas da API
        [JsonPropertyName("Id")]
        [JsonConverter(typeof(IntConverter))]
        public int IdExterno { get; set; }
        public string Tag { get; set; }
        public string Algorithm { get; set; }
        //public object block_time { get; set; } //Às vezes é string, outras é um int
        //public decimal block_reward { get; set; }
        //public decimal block_reward24 { get; set; }
        //public int last_block { get; set; }
        //public decimal difficulty { get; set; }
        //public decimal difficulty24 { get; set; }
        public long Nethash { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal Exchange_rate { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal Exchange_rate24 { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal Exchange_rate_vol { get; set; }
        public string Exchange_rate_curr { get; set; }
        public string Market_cap { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal Estimated_rewards { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal Estimated_rewards24 { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal Btc_revenue { get; set; }

        [JsonConverter(typeof(DecimalConverter))]
        public decimal Btc_revenue24 { get; set; }

        [JsonConverter(typeof(IntConverter))]
        public int Profitability { get; set; }

        [JsonConverter(typeof(IntConverter))]
        public int Profitability24 { get; set; }
        public bool Lagging { get; set; }

        [JsonConverter(typeof(IntConverter))]
        public int Timestamp { get; set; }

        public Moeda() { }
    }
}