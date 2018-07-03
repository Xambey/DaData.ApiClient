using System.Collections.Generic;
using DadataApiClient.Models.Suggests.Data;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Models.Standartization.Data
{
    public class DadataCompositeQueryResult
    {
        public List<string> Structure { get; set; }

        public List<DadataDataQueryData> Data { get; set; }
    }
}