using System.Collections.Generic;
using System.Linq;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Results;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.Responses
{
    public class DadataEmailQueryResponse
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