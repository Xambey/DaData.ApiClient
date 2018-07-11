using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Models.Standartization.Results
{
    public class DadataCompositeQueryResult
    {
        public JArray Structure { get; set; }

        public JArray Data { get; set; } 
    }
}