using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONHelpers
{
	public class JSONColorConverter : JsonConverter<Color>
	{
		public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string? _val = reader.GetString();
			if (_val == null)
				return Color.Empty;
			string p1 = _val.Substring(1, 2);
			string p2 = _val.Substring(3, 2);
			string p3 = _val.Substring(5, 2);
			string p4 = _val.Substring(7, 2);
			return Color.FromArgb(int.Parse(p1, NumberStyles.AllowHexSpecifier),
				int.Parse(p2, NumberStyles.AllowHexSpecifier),
				int.Parse(p3, NumberStyles.AllowHexSpecifier),
				int.Parse(p4, NumberStyles.AllowHexSpecifier));
		}

		public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
		{
			writer.WriteStringValue($"#{value.A:X2}{value.R:X2}{value.G:X2}{value.B:X2}");
		}
	}
}