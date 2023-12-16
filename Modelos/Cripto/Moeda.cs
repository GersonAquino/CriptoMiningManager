

using System.Text.Json.Serialization;

namespace Modelos.Cripto
{
    public class Moedas
    {
        public ListaMoedas coins { get; set; }
    }

    public class ListaMoedas
    {
        public Moeda Conflux { get; set; }

        [JsonPropertyName("Nicehash-Octopus")]
        public Moeda NicehashOctopus { get; set; }

        [JsonPropertyName("Nicehash-KawPow")]
        public Moeda NicehashKawPow { get; set; }

        public Moeda Clore { get; set; }
        public Moeda Neurai { get; set; }
        public Moeda Kiirocoin { get; set; }
        public Moeda Satoxcoin { get; set; }
        public Moeda Ryo { get; set; }
        public Moeda Neoxa { get; set; }
        public Moeda Alephium { get; set; }
        public Moeda Paprikacoin { get; set; }
        public Moeda GamePass { get; set; }
        public Moeda Gemlink { get; set; }
        public Moeda BitcoinGold { get; set; }

        [JsonPropertyName("Nicehash-Zhash")]
        public Moeda NicehashZhash { get; set; }

        public Moeda Zano { get; set; }
        public Moeda BitcoinZ { get; set; }
        public Moeda Ravencoin { get; set; }

        [JsonPropertyName("Nicehash-ZelHash")]
        public Moeda NicehashZelHash { get; set; }

        public Moeda Frencoin { get; set; }
        public Moeda Flux { get; set; }
        public Moeda Meowcoin { get; set; }

        [JsonPropertyName("Nicehash-CuckooCycle")]
        public Moeda NicehashCuckooCycle { get; set; }

        public Moeda Cortex { get; set; }
        public Moeda Equilibria { get; set; }
        public Moeda Aeternity { get; set; }

        [JsonPropertyName("Nicehash-BeamV3")]
        public Moeda NicehashBeamV3 { get; set; }

        public Moeda Firo { get; set; }
        public Moeda Beam { get; set; }
        public Moeda Conceal { get; set; }
        public Moeda Canxium { get; set; }

        [JsonPropertyName("Nicehash-Ethash")]
        public Moeda NicehashEthash { get; set; }

        public Moeda Ergo { get; set; }

        [JsonPropertyName("Nicehash-Autolykos")]
        public Moeda NicehashAutolykos { get; set; }

        public Moeda Radiant { get; set; }
        public Moeda Rethereum { get; set; }

        [JsonPropertyName("Bloc.money")]
        public Moeda Blocmoney { get; set; }

        public Moeda Bitnet { get; set; }
        public Moeda PowBlocks { get; set; }
        public Moeda OctaSpace { get; set; }

        [JsonPropertyName("Grin-CT32")]
        public Moeda GrinCT32 { get; set; }

        public Moeda Vertcoin { get; set; }
        public Moeda Sero { get; set; }
        public Moeda EtherGem { get; set; }
        public Moeda HavenProtocol { get; set; }
        public Moeda EthereumFair { get; set; }

        [JsonPropertyName("Nicehash-Cuckatoo32")]
        public Moeda NicehashCuckatoo32 { get; set; }

        public Moeda EthereumPoW { get; set; }
        public Moeda Callisto { get; set; }
        public Moeda EthereumClassic { get; set; }

        [JsonPropertyName("Nicehash-Etchash")]
        public Moeda NicehashEtchash { get; set; }

        public Moeda Etica { get; set; }
        public Moeda QuarkChain { get; set; }
        public Moeda Etho { get; set; }

        [JsonPropertyName("Nicehash-NexaPow")]
        public Moeda NicehashNexaPow { get; set; }

        [JsonPropertyName("Nicehash-IronFish")]
        public Moeda NicehashIronFish { get; set; }

        public Moeda Skydoge { get; set; }
        public Moeda IronFish { get; set; }
        public Moeda Karlsen { get; set; }
        public Moeda Dynexcoin { get; set; }
        public Moeda Nexa { get; set; }
    }

    /// <summary>
    /// Classe genérica com propriedades desnecessárias comentadas para evitar stresses e simplificar a leitura do JSON
    /// </summary>
    public class Moeda
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        //public object block_time { get; set; } //Às vezes é string, outras é um int
        //public decimal block_reward { get; set; }
        //public decimal block_reward24 { get; set; }
        //public int last_block { get; set; }
        //public decimal difficulty { get; set; }
        //public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }































    public class Rootobject
    {
        public Coins coins { get; set; }
    }

    public class Coins
    {
        public Conflux Conflux { get; set; }

        [JsonPropertyName("Nicehash-Octopus")]
        public NicehashOctopus NicehashOctopus { get; set; }

        [JsonPropertyName("Nicehash-KawPow")]
        public NicehashKawpow NicehashKawPow { get; set; }

        public Clore Clore { get; set; }
        public Neurai Neurai { get; set; }
        public Kiirocoin Kiirocoin { get; set; }
        public Satoxcoin Satoxcoin { get; set; }
        public Ryo Ryo { get; set; }
        public Neoxa Neoxa { get; set; }
        public Alephium Alephium { get; set; }
        public Paprikacoin Paprikacoin { get; set; }
        public Gamepass GamePass { get; set; }
        public Gemlink Gemlink { get; set; }
        public Bitcoingold BitcoinGold { get; set; }

        [JsonPropertyName("Nicehash-Zhash")]
        public NicehashZhash NicehashZhash { get; set; }

        public Zano Zano { get; set; }
        public Bitcoinz BitcoinZ { get; set; }
        public Ravencoin Ravencoin { get; set; }

        [JsonPropertyName("Nicehash-ZelHash")]
        public NicehashZelhash NicehashZelHash { get; set; }

        public Frencoin Frencoin { get; set; }
        public Flux Flux { get; set; }
        public Meowcoin Meowcoin { get; set; }

        [JsonPropertyName("Nicehash-CuckooCycle")]
        public NicehashCuckoocycle NicehashCuckooCycle { get; set; }

        public Cortex Cortex { get; set; }
        public Equilibria Equilibria { get; set; }
        public Aeternity Aeternity { get; set; }

        [JsonPropertyName("Nicehash-BeamV3")]
        public NicehashBeamv3 NicehashBeamV3 { get; set; }

        public Firo Firo { get; set; }
        public Beam Beam { get; set; }
        public Conceal Conceal { get; set; }
        public Canxium Canxium { get; set; }

        [JsonPropertyName("Nicehash-Ethash")]
        public NicehashEthash NicehashEthash { get; set; }

        public Ergo Ergo { get; set; }

        [JsonPropertyName("Nicehash-Autolykos")]
        public NicehashAutolykos NicehashAutolykos { get; set; }

        public Radiant Radiant { get; set; }
        public Rethereum Rethereum { get; set; }

        [JsonPropertyName("Bloc.money")]
        public BlocMoney Blocmoney { get; set; }

        public Bitnet Bitnet { get; set; }
        public Powblocks PowBlocks { get; set; }
        public Octaspace OctaSpace { get; set; }

        [JsonPropertyName("Grin-CT32")]
        public GrinCT32 GrinCT32 { get; set; }

        public Vertcoin Vertcoin { get; set; }
        public Sero Sero { get; set; }
        public Ethergem EtherGem { get; set; }
        public Havenprotocol HavenProtocol { get; set; }
        public Ethereumfair EthereumFair { get; set; }

        [JsonPropertyName("Nicehash-Cuckatoo32")]
        public NicehashCuckatoo32 NicehashCuckatoo32 { get; set; }

        public Ethereumpow EthereumPoW { get; set; }
        public Callisto Callisto { get; set; }
        public Ethereumclassic EthereumClassic { get; set; }

        [JsonPropertyName("Nicehash-Etchash")]
        public NicehashEtchash NicehashEtchash { get; set; }

        public Etica Etica { get; set; }
        public Quarkchain QuarkChain { get; set; }
        public Etho Etho { get; set; }

        [JsonPropertyName("Nicehash-NexaPow")]
        public NicehashNexapow NicehashNexaPow { get; set; }

        [JsonPropertyName("Nicehash-IronFish")]
        public NicehashIronfish NicehashIronFish { get; set; }

        public Skydoge Skydoge { get; set; }
        public Ironfish IronFish { get; set; }
        public Karlsen Karlsen { get; set; }
        public Dynexcoin Dynexcoin { get; set; }
        public Nexa Nexa { get; set; }
    }

    public class Conflux
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashOctopus
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashKawpow
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Clore
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Neurai
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Kiirocoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Satoxcoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ryo
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Neoxa
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Alephium
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Paprikacoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Gamepass
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Gemlink
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Bitcoingold
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashZhash
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Zano
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Bitcoinz
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ravencoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashZelhash
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Frencoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Flux
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Meowcoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashCuckoocycle
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Cortex
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Equilibria
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Aeternity
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashBeamv3
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Firo
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Beam
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Conceal
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Canxium
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashEthash
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ergo
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashAutolykos
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Radiant
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Rethereum
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class BlocMoney
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Bitnet
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Powblocks
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Octaspace
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class GrinCT32
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Vertcoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Sero
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ethergem
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Havenprotocol
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ethereumfair
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashCuckatoo32
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ethereumpow
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Callisto
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ethereumclassic
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashEtchash
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Etica
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Quarkchain
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Etho
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashNexapow
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class NicehashIronfish
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public int block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Skydoge
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Ironfish
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public decimal difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Karlsen
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Dynexcoin
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public float block_reward { get; set; }
        public float block_reward24 { get; set; }
        public int last_block { get; set; }
        public decimal difficulty { get; set; }
        public float difficulty24 { get; set; }
        public int nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

    public class Nexa
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string algorithm { get; set; }
        public string block_time { get; set; }
        public decimal block_reward { get; set; }
        public decimal block_reward24 { get; set; }
        public int last_block { get; set; }
        public float difficulty { get; set; }
        public float difficulty24 { get; set; }
        public long nethash { get; set; }
        public float exchange_rate { get; set; }
        public float exchange_rate24 { get; set; }
        public float exchange_rate_vol { get; set; }
        public string exchange_rate_curr { get; set; }
        public string market_cap { get; set; }
        public string estimated_rewards { get; set; }
        public string estimated_rewards24 { get; set; }
        public string btc_revenue { get; set; }
        public string btc_revenue24 { get; set; }
        public int profitability { get; set; }
        public int profitability24 { get; set; }
        public bool lagging { get; set; }
        public int timestamp { get; set; }
    }

}
