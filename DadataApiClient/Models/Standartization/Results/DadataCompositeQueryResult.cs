using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Models.Standartization.Results
{
    public class DadataCompositeQueryResult
    {
        public List<string> Structure { get; set; }

        public JArray Data { get; set; } 
    }
}