using DadataApiClient.Models.Suggests.Data;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Results
{
    public class DadataAddressQueryResult
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unrestricted_value")]
        public string UnrestrictedValue { get; set; }
        
        [JsonProperty("data")]
        public DadataAddressQueryData Data { get; set; }
    }
}