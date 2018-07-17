using System.Collections.Generic;
using System.Linq;
using DaData.Models.Standartization.Results;
using DaData.Models.Standartization.ShortResponses;
using DaData.Models.Standartization.ShortsResults;

namespace DaData.Models.Standartization.Responses
{
    public class FioResponse : BaseResponse
    {
        public List<FioResult> Value { get; set; }
        
        public FioShortResponse ToShortResponse()
        {
            return new FioShortResponse
            {
                Value = Value.Select(x => new FioShortResult
                {
                    Name = x.Name,
                    Patronymic = x.Patronymic,
                    Surname = x.Surname,
                    Gender = x.Gender
                }).ToList()
            };
        }
    }
}