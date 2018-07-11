using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DadataApiClient.Models.Standartization.Requests
{
    public class DadataCompositeQueryRequest
    {
        [JsonProperty("structure")]
        public JArray Structure { get; set; }
        
        [JsonProperty("data")]
        public JArray Data { get; set; }
    }
}