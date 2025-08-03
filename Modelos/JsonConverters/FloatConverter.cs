using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modelos.JsonConverters;

public class FloatConverter : JsonConverter<float>
{
	public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String)
			return float.Parse(reader.GetString(), CultureInfo.InvariantCulture);

		return reader.GetSingle();
	}

	public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value);
	}
}
