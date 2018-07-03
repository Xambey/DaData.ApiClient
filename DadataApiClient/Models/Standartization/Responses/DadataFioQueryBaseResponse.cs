using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Standartization.Data;
using DadataApiClient.Models.Standartization.ShortResponses;
using DadataApiClient.Models.Standartization.ShortsResults;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataFioQueryBaseResponse : BaseResponse
    {
        public List<DadataFioQueryResult> Value { get; set; }
        
        public DadataFioQueryShortResponse ToShortResponse()
        {
            return new DadataFioQueryShortResponse
            {
                Value = Value.Select(x => new DadataFioQueryShortResult
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