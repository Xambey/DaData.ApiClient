using DadataApiClient.Models.Suggestions.Data;

namespace DadataApiClient.Models.Additional.Data
{
    public class DadataQueryDataLocation
    {
        public string Value { get; set; }

        public string UnrestrictedValue { get; set; }
        
        public DadataAddressQueryData Data { get; set; }
    }
}