using DadataApiClient.Models.Suggests.Data;
using Newtonsoft.Json;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.Results
{
    public class DadataEmailQueryResult
    {
        public string Value { get; set; }
        
        [JsonProperty("unrestricted_value")] public string UnrestrictedValue { get; set; }
        
        public DadataEmailQueryData Data { get; set; }
    }
}