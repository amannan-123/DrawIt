using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrawIt.Helpers
{
    public static class DrawItJson
    {
        private static readonly JsonSerializerOptions _options = CreateOptions();

        public static JsonSerializerOptions Options => _options;

        public static string Serialize<T>(T value)
        {
            return JsonSerializer.Serialize(value, _options);
        }

        public static T? Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, _options);
        }

        public static void SerializeToFile<T>(string path, T value)
        {
            var json = Serialize(value);
            File.WriteAllText(path, json);
        }

        public static T? DeserializeFromFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            return Deserialize<T>(json);
        }

        private static JsonSerializerOptions CreateOptions()
        {
            var options = new JsonSerializerOptions
            {
                UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };

            options.Converters.Add(new JsonStringEnumConverter());
            options.Converters.Add(new JSONColorConverter());
            options.Converters.Add(new JSONImageConverter());

            return options;
        }
    }
}
