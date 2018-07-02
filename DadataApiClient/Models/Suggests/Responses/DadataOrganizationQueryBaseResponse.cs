using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggests.Results;
using DadataApiClient.Models.Suggests.ShortResponses;
using DadataApiClient.Models.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Responses
{
    public class DadataOrganizationQueryBaseResponse : BaseResponse
    {
        [JsonProperty("suggestions")]
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