using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggestions.ShortResponses;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.Responses
{
    public class DadataBankQueryBaseResponse : BaseResponse
    {
        public List<Results.DadataBankQueryResult> Suggestions { get; set; }

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