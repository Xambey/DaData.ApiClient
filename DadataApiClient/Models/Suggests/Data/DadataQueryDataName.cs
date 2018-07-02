using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Data
{
    public class DadataQueryDataName
    {
        [JsonProperty("full_with_opt")] public string FullWithOpf { get; set; }
        
        [JsonProperty("short_with_opt")] public string ShortWithOpf { get; set; }

        public string Latin { get; set; }
        
        public string Full { get; set; }
        
        public string Short { get; set; }
    }
}