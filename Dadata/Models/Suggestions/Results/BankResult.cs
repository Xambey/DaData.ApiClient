using DaData.Models.Suggestions.Data;

namespace DaData.Models.Suggestions.Results
{
    public class BankResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public BankData Data { get; set; }
    }
}