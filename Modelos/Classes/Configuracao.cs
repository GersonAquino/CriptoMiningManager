using PropertyChanged;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelos.Classes
{
    //A segunda anotação serve para poder usar os DataLayoutControls em condições, aka, para as alterações feitas ao objeto se refletirem nos controlos visualmente
    [Description("Configuração"), AddINotifyPropertyChangedInterface]
    public class Configuracao
    {
        [Key]
        public int Id { get; set; } = -1;
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
