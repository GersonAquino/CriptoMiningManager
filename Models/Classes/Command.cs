using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Classes;

[Description("Comando"), Table("Comandos")]
public class Command : Configuration
{
	public string Comandos { get; set; }
	public bool PreMineracao { get; set; }
	public bool PosMineracao { get; set; }

	[NotMapped]
	public string ComandosCMD { get => "/C " + Comandos.Replace(Environment.NewLine, " & "); }
}
