using DadataApiClient.Models.Suggestions.Results;

namespace DadataApiClient.Models.Suggestions.ShortsResults
{
    public class DadataBankQueryShortResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public string Bic { get; set; }
        
        public string Swift { get; set; }
        
        public string Okpo { get; set; }
        
        public string Rkc { get; set; }
        
        public DadataAddressQueryResult Address { get; set; }
        
        public string Phone { get; set; }
    }
}