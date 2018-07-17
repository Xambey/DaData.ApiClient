using System.Collections.Generic;
using System.Linq;
using DaData.Models.Suggestions.Results;
using DaData.Models.Suggestions.ShortResponses;
using DaData.Models.Suggestions.ShortsResults;

namespace DaData.Models.Suggestions.Responses
{
    public class FioResponse : BaseResponse
    {
        public List<FioResult> Suggestions { get; set; }

        public FioShortResponse ToShortResponse()
        {
            return new FioShortResponse
            {
                Suggestions = Suggestions.Select(x => new FioShortResult
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