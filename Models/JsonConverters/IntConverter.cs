using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models.JsonConverters;

public class IntConverter : JsonConverter<int>
{
	public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String)
			return int.Parse(reader.GetString(), CultureInfo.InvariantCulture);

		return reader.GetInt32();
	}

	public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value);
	}
}
