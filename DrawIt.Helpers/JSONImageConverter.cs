using System.Text.Json.Serialization;
using System.Text.Json;

namespace DrawIt.Helpers
{
	public class JSONImageConverter : JsonConverter<Image>
	{
		public override Image? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string? _val = reader.GetString();
			if (_val == null || _val == String.Empty)
				return null;
			// convert base64 to byte array, put that into memory stream and feed to image
			return Image.FromStream(new MemoryStream(Convert.FromBase64String(_val)));
		}

		public override void Write(Utf8JsonWriter writer, Image value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteStringValue(String.Empty);
				return;
			}
			var ms = new MemoryStream();
			value.Save(ms, value.RawFormat);
			byte[] imageBytes = ms.ToArray();
			writer.WriteStringValue(Convert.ToBase64String(imageBytes));
		}
	}
}
