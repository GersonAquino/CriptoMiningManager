using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelos.Classes;

[Description("Minerador"), Table("Mineradores")]
public class Minerador : Configuracao
{
	public string Nome { get; set; }
	public string Localizacao { get; set; }
	public string Parametros { get; set; }

	public int? IdMoeda { get => Moeda?.Id; }

	[NotMapped]
	public Moeda Moeda { get; set; }

	public Minerador() { }

	public override string ToString()
	{
		return $"{Id} - {Nome}";
	}
}
