using DadataApiClient.Models.Suggests.Data;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Results
{
    public class DadataEmailQueryResult
    {
        public string Value { get; set; }
        
        [JsonProperty("unrestricted_value")] public string UnrestrictedValue { get; set; }
        
        public DadataEmailQueryData Data { get; set; }
    }
}