using Modelos.Classes;

namespace Modelos.EventArgs
{
	public class AlteracaoMoedaMaisRentavelEventArgs : System.EventArgs
	{
		public Moeda Moeda;

		public AlteracaoMoedaMaisRentavelEventArgs() : base() { }
		public AlteracaoMoedaMaisRentavelEventArgs(Moeda moeda) : base()
		{
			Moeda = moeda;
		}
	}
}
