using DaData.Models.Suggestions.Data;

namespace DaData.Models.Suggestions.Results
{
    public class EmailResult
    {
        public string Value { get; set; }
        
        public string UnrestrictedValue { get; set; }
        
        public EmailData Data { get; set; }
    }
}