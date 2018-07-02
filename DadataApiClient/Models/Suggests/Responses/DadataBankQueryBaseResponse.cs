using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggests.Results;
using DadataApiClient.Models.Suggests.ShortResponses;
using DadataApiClient.Models.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Responses
{
    public class DadataBankQueryBaseResponse : BaseResponse
    {
        [JsonProperty("suggestions")]
        public List<Results.DadataBankQueryResponse> Suggestions { get; set; }

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