using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggests.Results;
using DadataApiClient.Models.Suggests.ShortResponses;
using DadataApiClient.Models.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Responses
{
    public class DadataEmailQueryBaseResponse : BaseResponse
    {
        [JsonProperty("suggestions")]
        public List<DadataEmailQueryResult> Suggestions { get; set; }

        public DadataEmailQueryShortResponse ToShortResponse()
        {
            return new DadataEmailQueryShortResponse
            {
                Suggestions = Suggestions.Select(x => new DadataEmailQueryShortResult
                {
                    Domain = x.Data.Domain,
                    Local = x.Data.Local,
                    UnrestrictedValue = x.UnrestrictedValue,
                    Value = x.Value
                }).ToList()
            };
        }
    }
}