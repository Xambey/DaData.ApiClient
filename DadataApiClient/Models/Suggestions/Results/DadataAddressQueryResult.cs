using DadataApiClient.Models.Suggestions.Data;

namespace DadataApiClient.Models.Suggestions.Results
{
    public class DadataAddressQueryResult
    {
        public string Value { get; set; }

        public string UnrestrictedValue { get; set; }
        
        public DadataAddressQueryData Data { get; set; }
    }
}