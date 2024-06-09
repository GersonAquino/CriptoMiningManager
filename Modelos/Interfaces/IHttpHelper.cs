using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelos.Interfaces
{
	public interface IHttpHelper
	{
		string URLBase { get; }

		Task<List<T>> PedidoGETHttp<T>(string uri, params (string Header, string Valor)[] headers) where T : class;
		Task<T> PedidoGETHttpSingle<T>(string uri, params (string Header, string Valor)[] headers) where T : class;
		Task<T> PedidoPOSTHttp<T>(string uri, Dictionary<string, string> parameters, params (string Header, string Valor)[] requestHeaders) where T : class;
		Task<T> PedidoPOSTHttp<T>(string uri, string body, string contentTypeHeader, params (string Header, string Valor)[] requestHeaders) where T : class;
	}
}