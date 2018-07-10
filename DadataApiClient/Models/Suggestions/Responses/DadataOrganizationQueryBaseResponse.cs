using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggestions.Results;
using DadataApiClient.Models.Suggestions.ShortResponses;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.Responses
{
    public class DadataOrganizationQueryBaseResponse : BaseResponse
    {
        public List<DadataPartyQueryResult> Suggestions { get; set; }

        public DadataPartyQueryShortResponse ToShortResponse()
        {
            return new DadataPartyQueryShortResponse
            {
                Suggestions = Suggestions.Select(x => new DadataPartyQueryShortResult
                {
                    Value = x.Value,
                    UnrestrictedValue = x.UnrestrictedValue,
                    Inn = x.Data.Inn,
                    Kpp = x.Data.Kpp,
                    Ogrn = x.Data.Ogrn,
                    Okpo = x.Data.Okpo
                }).ToList()
            };
        }
    }
}