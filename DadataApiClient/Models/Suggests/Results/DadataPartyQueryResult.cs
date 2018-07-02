using DadataApiClient.Models.Suggests.Data;
using Newtonsoft.Json;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.Results
{
    public class DadataPartyQueryResult
    {
        public string Value { get; set; }
        
        [JsonProperty("unrestricted_value")] public string UnrestrictedValue { get; set; }
        
        public DadataPartyQueryData Data { get; set; }
    }
}