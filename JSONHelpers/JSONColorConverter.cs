using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONHelpers
{
	public class JSONColorConverter : JsonConverter<Color>
	{
		public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string? _val = reader.GetString();
			if (_val==null)
				return Color.Empty;
			return ColorTranslator.FromHtml(_val);
		}

		public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(ColorTranslator.ToHtml(value));
		}
	}
}