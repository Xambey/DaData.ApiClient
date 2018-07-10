using DadataApiClient.Models.Suggestions.Data;

namespace DadataApiClient.Models.Suggestions.Results
{
    public class DadataPartyQueryResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public DadataPartyQueryData Data { get; set; }
    }
}