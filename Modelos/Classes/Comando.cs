using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Classes;

[Description("Comando"), Table("Comandos")]
public class Comando : Configuracao
{
	public string Comandos { get; set; }
	public bool PreMineracao { get; set; }
	public bool PosMineracao { get; set; }

	[NotMapped]
	public string ComandosCMD { get => "/C " + Comandos.Replace(Environment.NewLine, " & "); }
}
