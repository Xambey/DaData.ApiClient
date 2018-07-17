using DaData.Models.Suggestions.Data;

namespace DaData.Models.Additional.Data
{
    public class DataLocation
    {
        public string Value { get; set; }

        public string UnrestrictedValue { get; set; }
        
        public AddressData Data { get; set; }
    }
}