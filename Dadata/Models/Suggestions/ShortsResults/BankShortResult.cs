using DaData.Models.Suggestions.Results;

namespace DaData.Models.Suggestions.ShortsResults
{
    public class BankShortResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public string Bic { get; set; }
        
        public string Swift { get; set; }
        
        public string Okpo { get; set; }
        
        public string Rkc { get; set; }
        
        public AddressResult Address { get; set; }
        
        public string Phone { get; set; }
    }
}