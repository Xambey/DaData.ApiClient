using System.Collections.Generic;
using System.Linq;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Results;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.Responses
{
    public class DadataPartyQueryResponse
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