using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DaData.Models.Standartization.Requests
{
    public class CompositeRequest : BaseRequest
    {
        [JsonProperty("structure")]
        public JArray Structure { get; set; }
        
        [JsonProperty("data")]
        public JArray Data { get; set; }
    }
}