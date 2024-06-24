using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Classes
{
	[Description("Configuração Geral"), Table("ConfiguracoesGerais")]
	public class ConfiguracaoGeral : Configuracao
	{
		public bool IniciarMinimizada { get; set; }

		/// <summary>
		/// Define se se deve medir e atualizar automaticamente o valor de <see cref="Minerador.ConsumoMedio"/> do <see cref="Minerador"/> ativo
		/// <para>TODO: POR IMPLEMENTAR</para>
		/// </summary>
		public bool MedirConsumo { get; set; }

		public bool MinimizarAoFechar { get; set; }

		/// <summary>
		/// Se estiver ativo, ao gravar uma entidade, pergunta se pretende criar uma nova entidade (para atualizar o editor)
		/// <para>TODO: POR IMPLEMENTAR E CRIAR NA BD</para>
		/// </summary>
		public bool ConfirmacoesExtraNosEditores { get; set; }

		/// <summary>
		/// Peso a aplicar na equação de rentabilidade de mineradores para verificar se deve realmente trocar de minerador.
		/// O consumo é medido em Watts.
		/// <para>TODO: POR IMPLEMENTAR</para>
		/// </summary>
		public int PesoConsumo { get; set; }

		public string Descricao { get; set; }

		public ConfiguracaoGeral() { }
	}
}
