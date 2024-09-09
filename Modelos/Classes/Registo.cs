using PropertyChanged;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Utils;

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

		/// <summary>
		/// Compara 2 <see cref="Registo"/>s pelo <see cref="Id"/>.
		/// <para>Caso o Id de <paramref name="registo"/> seja -1 (novo registo), devolve false</para>
		/// </summary>
		/// <param name="registo"></param>
		/// <returns></returns>
		public bool CompararPorId(Registo registo)
		{
			return registo != null && CompararPorId(registo.Id);
		}

		/// <summary>
		/// Compara 2 Ids.
		/// <para>Caso <paramref name="id"/> seja -1 (novo registo), devolve false</para>
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool CompararPorId(int id)
		{
			if (id == -1)
				return false;

			return id == Id;
		}

		public override string ToString()
		{
			string descricaoClasse = this.GetType().GetDescricaoClasse();
			return Id == -1 ? descricaoClasse : $"{descricaoClasse} {Id}";
		}
	}
}
