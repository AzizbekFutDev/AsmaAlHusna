using System.Text.Json.Serialization;

namespace lesson10.Dto.AsmaAlHusna
{
    public class Datum
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("transliteration")]
        public string Transliteration { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("en")]
        public En En { get; set; }
    }
}