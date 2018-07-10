using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggestions.Results;
using DadataApiClient.Models.Suggestions.ShortResponses;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.Responses
{
    public class DadataEmailQueryBaseResponse : BaseResponse
    {
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