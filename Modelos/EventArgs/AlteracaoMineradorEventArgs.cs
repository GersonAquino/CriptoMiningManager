using Modelos.Classes;

namespace Modelos.EventArgs
{
	public class AlteracaoMineradorEventArgs : System.EventArgs
	{
		public Minerador Minerador;

		public AlteracaoMineradorEventArgs() : base() { }
		public AlteracaoMineradorEventArgs(Minerador minerador) : base()
		{
			Minerador = minerador;
		}
	}
}
