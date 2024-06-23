using PropertyChanged;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelos.Classes
{
	//A segunda anotação serve para poder usar os DataLayoutControls em condições, ou seja, para as alterações feitas ao objeto se refletirem nos controlos visualmente
	[Description("Registo"), AddINotifyPropertyChangedInterface]
	public class Registo
	{
		[Key]
		public int Id { get; set; } = -1;
		public DateTime DataCriacao { get; set; } = DateTime.Now;
		public DateTime DataAlteracao { get; set; } = DateTime.Now;
	}
}
