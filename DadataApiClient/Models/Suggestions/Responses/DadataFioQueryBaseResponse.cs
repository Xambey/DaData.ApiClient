using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggestions.Results;
using DadataApiClient.Models.Suggestions.ShortResponses;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.Responses
{
    public class DadataFioQueryBaseResponse : BaseResponse
    {
        public List<DadataFioQueryResult> Suggestions { get; set; }

        public DadataFioQueryShortResponse ToShortResponse()
        {
            return new DadataFioQueryShortResponse
            {
                Suggestions = Suggestions.Select(x => new DadataFioQueryShortResult
                {
                    Name = x.Data.Name,
                    Patronymic = x.Data.Patronymic,
                    Surname = x.Data.Surname,
                    Value = x.Value,
                    UnrestrictedValue = x.UnrestrictedValue
                }).ToList()
            };
        }
    }
}