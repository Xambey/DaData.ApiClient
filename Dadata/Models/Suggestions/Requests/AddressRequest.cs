using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DaData.Models.Suggestions.Requests
{
    public class AddressRequest
    {
        public string Query { get; set; }
        
        public int? Count { get; set; }
        
        public List<JObject> Locations { get; set; }
        
        public List<JObject> LocationsBoost { get; set; }
    }
}