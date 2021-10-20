using System.Text.Json.Serialization;

namespace lesson10.Dto.AsmaAlHusna
{
    public class En
    {
        [JsonPropertyName("meaning")]
        public string Meaning { get; set; }
    }
}