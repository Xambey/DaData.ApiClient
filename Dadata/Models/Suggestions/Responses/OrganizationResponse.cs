using System.Collections.Generic;
using System.Linq;
using DaData.Models.Suggestions.Results;
using DaData.Models.Suggestions.ShortResponses;
using DaData.Models.Suggestions.ShortsResults;

namespace DaData.Models.Suggestions.Responses
{
    public class OrganizationResponse : BaseResponse
    {
        public List<PartyResult> Suggestions { get; set; }

        public PartyShortResponse ToShortResponse()
        {
            return new PartyShortResponse
            {
                Suggestions = Suggestions.Select(x => new PartyShortResult
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