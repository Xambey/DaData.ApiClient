using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Models.Suggests.Data
{
    public class DadataDataQueryData
    {
        public List<JObject> Value { get; set; }
    }
}