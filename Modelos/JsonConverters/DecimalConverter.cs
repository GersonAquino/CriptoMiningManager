using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modelos.JsonConverters;

public class DecimalConverter : JsonConverter<decimal>
{
	public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String)
			return decimal.Parse(reader.GetString(), CultureInfo.InvariantCulture);

		return reader.GetDecimal();
	}

	public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value);
	}
}
