using DadataApiClient.Models.Suggestions.Data;

namespace DadataApiClient.Models.Suggestions.Results
{
    public class DadataBankQueryResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public DadataBankQueryData Data { get; set; }
    }
}