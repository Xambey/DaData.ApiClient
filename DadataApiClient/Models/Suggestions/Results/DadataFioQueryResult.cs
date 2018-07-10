using DadataApiClient.Models.Suggestions.Data;

namespace DadataApiClient.Models.Suggestions.Results
 {
     public class DadataFioQueryResult
     {
         public string Value { get; set; }
         
         public string UnrestrictedValue { get; set; }
 
         public DadataFioQueryData Data { get; set; }
     }
 }