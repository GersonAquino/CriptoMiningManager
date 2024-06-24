namespace Modelos.EventArgs
{
	public class ErroMineradorEventArgs : System.EventArgs
	{
		public string Erro;

		public ErroMineradorEventArgs() : base() { }
		public ErroMineradorEventArgs(string erro) : base()
		{
			Erro = erro;
		}
	}
}
