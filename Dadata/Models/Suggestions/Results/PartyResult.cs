using DaData.Models.Suggestions.Data;

namespace DaData.Models.Suggestions.Results
{
    public class PartyResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public PartyData Data { get; set; }
    }
}