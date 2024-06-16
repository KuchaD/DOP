using System.Text.Json;

namespace DOP.Abstaction;

public static class Serializer
{
    public static class JsonDefault
    {
        private static JsonSerializerOptions Options { get; } = new ()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public static string Serialize<TValue>(TValue value)
        {
            return System.Text.Json.JsonSerializer.Serialize(value, Options);
        }
        
        public static TValue? Deserialize<TValue>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<TValue>(json, Options);
        }
    }
}