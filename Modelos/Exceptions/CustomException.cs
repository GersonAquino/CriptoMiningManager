using System;

namespace Modelos.Exceptions;

public class CustomException : Exception
{
	public string Detalhes { get; set; }

	public CustomException()
	{
		Detalhes = "";
	}

	public CustomException(string mensagem, string detalhes = "") : base(mensagem)
	{
		Detalhes = detalhes;
	}

	public CustomException(string mensagem, Exception innerException, string detalhes = "") : base(mensagem, innerException)
	{
		Detalhes = detalhes;
	}
}
