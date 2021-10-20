using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace lesson10.Dto.AsmaAlHusna
{

    public class Root
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }
    }
}