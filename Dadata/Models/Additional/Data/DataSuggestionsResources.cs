using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DaData.Models.Additional.Data
{
    public class DataSuggestionsResources
    {
        [JsonProperty("ЕГРЮЛ")] public string Egrul { get; set; }
        [JsonProperty("ФИАС")] public string Fias { get; set; }
        [JsonProperty("IP-адреса")] public string IpAddress { get; set; }
        [JsonProperty("Банки")] public string Banks { get; set; }
    }
}