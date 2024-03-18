using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorDados.Helpers
{
    public class JsonHelper : IJsonHelper
    {
        public static JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public T Deserialize<T>(string json) where T : class
        {
            return JsonSerializer.Deserialize<T>(json, _options);
        }
        public T Deserialize<T>(Stream stream) where T : class
        {
            if (stream.CanSeek)
                stream.Position = 0;

            using (StreamReader reader = new StreamReader(stream))
            {
                return JsonSerializer.Deserialize<T>(reader.ReadToEnd(), _options);
            }
        }

        /// <summary>
        /// Desserializa um ficheiro JSON para uma lista de T.
        /// Primeiro tenta ler o JSON como uma lista de T, se falhar tenta ler o JSON como um objeto T único.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns>Lista de T. Se falhar ao ler o JSON como uma lista e suceder a ler o JSON como 1 elemento único devolve uma Lista com 1 elemento</returns>
        public async Task<List<T>> DeserializeAsync<T>(Stream stream) where T : class
        {
            //Código para tratar streams não seekable (recursivo) -> Cria uma cópia seekable da stream
            //if (!stream.CanSeek)
            //{
            //    using (MemoryStream newStream = new MemoryStream())
            //    {
            //        await stream.CopyToAsync(newStream);
            //        return await DeserializeJson<T>(newStream);
            //    }
            //}

            try
            {
                stream.Position = 0;
                return await JsonSerializer.DeserializeAsync<List<T>>(stream, _options);
            }
            catch (JsonException)
            {
                stream.Position = 0;
                return new List<T>() { await JsonSerializer.DeserializeAsync<T>(stream, _options) };
            }
        }

        public async Task<T> DeserializeSingleAsync<T>(Stream stream) where T : class
        {
            stream.Position = 0;
            return await JsonSerializer.DeserializeAsync<T>(stream, _options);
        }

        /// <summary>
        /// Serializa o parâmetro recebido e devolve a string JSON resultante
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String JSON do objeto serializado</returns>
        public async Task<string> SerializeAsync(object value)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(stream, value);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
