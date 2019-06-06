using System.Collections.Generic;
using System.Linq;
using DaData.Models.Suggestions.ShortResponses;
using DaData.Models.Suggestions.ShortsResults;

namespace DaData.Models.Suggestions.Responses
{
    public class BankResponse : BaseResponse
    {
        public List<Results.BankResult> Suggestions { get; set; }

        public BankShortResponse ToShortResponse()
        {
            return new BankShortResponse
            {
                Suggestions = Suggestions.Select(x => new BankShortResult
                {
                    Address = x.Data.Address,
                    Bic = x.Data.Bic,
                    Okpo = x.Data.Okpo,
                    Phone = x.Data.Phone,
                    Rkc = x.Data.Rkc?.Rkc,
                    Swift = x.Data.Swift,
                    UnrestrictedValue = x.UnrestrictedValue,
                    Value = x.Value
                }).ToList()
            };
        }
    }
}