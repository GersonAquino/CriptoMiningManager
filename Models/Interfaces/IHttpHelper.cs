using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interfaces;

public interface IHttpHelper
{
	string BaseURL { get; }

	Task<List<T>> GETRequestHttp<T>(string uri, params (string Header, string Value)[] headers) where T : class;
	Task<T> GETRequestHttpSingle<T>(string uri, params (string Header, string Value)[] headers) where T : class;
	Task<T> POSTRequestHttp<T>(string uri, Dictionary<string, string> parameters, params (string Header, string Value)[] requestHeaders) where T : class;
	Task<T> POSTRequestHttp<T>(string uri, string body, string contentTypeHeader, params (string Header, string Value)[] requestHeaders) where T : class;
}