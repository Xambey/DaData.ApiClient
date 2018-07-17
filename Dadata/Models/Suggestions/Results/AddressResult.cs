using DaData.Models.Suggestions.Data;

namespace DaData.Models.Suggestions.Results
{
    public class AddressResult
    {
        public string Value { get; set; }

        public string UnrestrictedValue { get; set; }
        
        public AddressData Data { get; set; }
    }
}