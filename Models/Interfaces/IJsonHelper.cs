using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Models.Interfaces;

public interface IJsonHelper
{
	T Deserialize<T>(Stream stream) where T : class;
	T Deserialize<T>(string json) where T : class;
	Task<List<T>> DeserializeAsync<T>(Stream stream) where T : class;
	Task<T> DeserializeSingleAsync<T>(Stream stream) where T : class;
	Task<string> SerializeAsync(object value);
}