using System;

namespace Models.Exceptions;

public class CustomException : Exception
{
	public string Details { get; set; }

	public CustomException()
	{
		Details = "";
	}

	public CustomException(string mensagem, string detalhes = "") : base(mensagem)
	{
		Details = detalhes;
	}

	public CustomException(string mensagem, Exception innerException, string detalhes = "") : base(mensagem, innerException)
	{
		Details = detalhes;
	}
}
