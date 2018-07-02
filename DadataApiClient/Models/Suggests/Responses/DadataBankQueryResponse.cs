using System.Collections.Generic;
using System.Linq;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Results;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.Responses
{
    public class DadataBankQueryResponse
    {
        [JsonProperty("suggestions")]
        public List<DadataBankQueryResult> Suggestions { get; set; }

        public DadataBankQueryShortResponse ToShortResponse()
        {
            return new DadataBankQueryShortResponse
            {
                Suggestions = Suggestions.Select(x => new DadataBankQueryShortResult
                {
                    Address = x.Data.Address,
                    Bic = x.Data.Bic,
                    Okpo = x.Data.Okpo,
                    Phone = x.Data.Phone,
                    Rkc = x.Data.Rkc.Rkc,
                    Swift = x.Data.Swift,
                    UnrestrictedValue = x.UnrestrictedValue,
                    Value = x.Value
                }).ToList()
            };
        }
    }
}