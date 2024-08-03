using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Classes
{
	[Description("Comando"), Table("Comandos")]
	public class Comando : Configuracao
	{
		public string Comandos { get; set; }
		public bool PreMineracao { get; set; }
		public bool PosMineracao { get; set; }

		[NotMapped]
		public string ComandosCMD { get => "/C " + Comandos.Replace(Environment.NewLine, " & "); }

		public override string ToString()
		{
			string tipoComando;
			if (PreMineracao)
				tipoComando = PosMineracao ? " (pré-mineração e pós-mineração)" : " (pré-mineração)";
			else
				tipoComando = PosMineracao ? " (pós-mineração)" : string.Empty;

			return $"{Id}{tipoComando}";
		}
	}
}
