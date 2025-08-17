using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Helpers;

public class HttpHelper : IHttpHelper
{
	private readonly IJsonHelper jsonHelper;

	public string BaseURL { get; }

	public HttpHelper(IJsonHelper serializationHelper, string baseUrl)
	{
		jsonHelper = serializationHelper;
		BaseURL = baseUrl;
	}

	/// <summary>
	/// Faz um pedido HTTP usando os headers e uri recebidos.
	/// Se algum header ou o uri forem null, faz throw de <see cref="ArgumentNullException"/>.
	/// Se o pedido HTTP falhar, faz throw de <see cref="HttpRequestException"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="uri"></param>
	/// <param name="headers">Pares de nomes/tipos dos headers com o respetivo valor</param>
	/// <returns></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="HttpRequestException"></exception>
	public async Task<List<T>> GETRequestHttp<T>(string uri, params (string Header, string Value)[] headers) where T : class
	{
		if (string.IsNullOrWhiteSpace(uri))
			uri = BaseURL;

		using HttpClient client = new();
		DefinirHeaders(client, headers);

		using HttpResponseMessage respostaHttp = await client.GetAsync(uri.TrimStart());
		using Stream stream = await respostaHttp.Content.ReadAsStreamAsync();
		return await jsonHelper.DeserializeAsync<T>(stream);
	}

	public async Task<T> GETRequestHttpSingle<T>(string uri, params (string Header, string Value)[] headers) where T : class
	{
		if (string.IsNullOrWhiteSpace(uri))
			uri = BaseURL;

		using HttpClient client = new();
		DefinirHeaders(client, headers);

		using HttpResponseMessage respostaHttp = await client.GetAsync(uri.TrimStart());
		using Stream stream = await respostaHttp.Content.ReadAsStreamAsync();
		return await jsonHelper.DeserializeSingleAsync<T>(stream);
	}

	//Descrição na interface
	public async Task<T> POSTRequestHttp<T>(string uri, string body, string contentTypeHeader, params (string Header, string Value)[] requestHeaders) where T : class
	{
		if (string.IsNullOrWhiteSpace(uri))
			uri = BaseURL;

		string contentType = !string.IsNullOrWhiteSpace(contentTypeHeader) ? contentTypeHeader : "text/plain";
		using HttpContent content = new StringContent(body, Encoding.UTF8, contentType);
		return await PedidoPOSTHttpBase<T>(uri, content, requestHeaders);
	}

	//Descrição na interface
	public async Task<T> POSTRequestHttp<T>(string uri, Dictionary<string, string> parameters, params (string Header, string Value)[] requestHeaders) where T : class
	{
		if (string.IsNullOrWhiteSpace(uri))
			uri = BaseURL;

		using HttpContent content = new FormUrlEncodedContent(parameters);
		return await PedidoPOSTHttpBase<T>(uri, content, requestHeaders);
	}

	//FUNÇÕES AUXILIARES
	private async Task<T> PedidoPOSTHttpBase<T>(string uri, HttpContent content, params (string Header, string Value)[] requestHeaders) where T : class
	{
		using HttpClient client = new();
		DefinirHeaders(client, requestHeaders);

		if (!uri.StartsWith("http"))
			uri = "http://" + uri;

		using HttpResponseMessage httpAnswer = await client.PostAsync(uri.TrimStart(), content);
		using Stream stream = await httpAnswer.Content.ReadAsStreamAsync();
		return jsonHelper.Deserialize<T>(stream);
	}

	private static void DefinirHeaders(HttpClient client, (string Header, string Value)[] headers)
	{
		client.DefaultRequestHeaders.Accept.Clear();
		//client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

		foreach ((string Header, string Value) in headers)
		{
			if (string.IsNullOrEmpty(Header) || string.IsNullOrEmpty(Value))
				throw new ArgumentNullException("Erro ao usar header " + Header);

			client.DefaultRequestHeaders.Add(Header, Value);
		}
	}
}
