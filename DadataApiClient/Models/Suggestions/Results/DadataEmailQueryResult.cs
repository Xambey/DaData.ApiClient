using DadataApiClient.Models.Suggestions.Data;

namespace DadataApiClient.Models.Suggestions.Results
{
    public class DadataEmailQueryResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public DadataEmailQueryData Data { get; set; }
    }
}