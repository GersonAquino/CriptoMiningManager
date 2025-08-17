using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Classes;

[Description("Comando"), Table("Commands")]
public class Command : Configuration
{
	public string Commands { get; set; }
	public bool PreMining { get; set; }
	public bool PosMining { get; set; }

	[NotMapped]
	public string CommandLineCommands { get => "/C " + Commands.Replace(Environment.NewLine, " & "); }
}
