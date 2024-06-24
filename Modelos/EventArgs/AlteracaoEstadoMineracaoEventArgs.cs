namespace Modelos.EventArgs
{
	public class AlteracaoEstadoMineracaoEventArgs : System.EventArgs
	{
		public bool Ativa;

		public AlteracaoEstadoMineracaoEventArgs() : base() { }
		public AlteracaoEstadoMineracaoEventArgs(bool ativa) : base()
		{
			Ativa = ativa;
		}
	}
}
