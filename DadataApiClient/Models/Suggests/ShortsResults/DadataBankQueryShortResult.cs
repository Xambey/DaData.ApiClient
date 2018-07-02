using MarkupFree.Api.Models.Api.Dadata.Suggests.Results;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults
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