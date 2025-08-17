using PropertyChanged;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Classes;

//A segunda anotação serve para poder usar os DataLayoutControls em condições, aka, para as alterações feitas ao objeto se refletirem nos controlos visualmente
[Description("Configuração"), AddINotifyPropertyChangedInterface]
public class Configuration
{
	[Key]
	public int Id { get; set; } = -1;
	public bool Active { get; set; }
	public DateTime CreatedDate { get; set; } = DateTime.Now;
	public DateTime UpdatedDate { get; set; } = DateTime.Now;
}
