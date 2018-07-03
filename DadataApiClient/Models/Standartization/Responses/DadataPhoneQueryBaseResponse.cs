using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Standartization.Results;
using DadataApiClient.Models.Standartization.ShortResponses;
using DadataApiClient.Models.Standartization.ShortsResults;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataPhoneQueryBaseResponse : BaseResponse
    {
        public List<DadataPhoneQueryResult> Value { get; set; }
        
        public DadataPhoneQueryShortResponse ToShortResponse()
        {
            return new DadataPhoneQueryShortResponse
            {
                Value = Value.Select(x => new DadataPhoneQueryShortResult
                {
                    CityCode = x.CityCode,
                    CountryCode = x.CountryCode,
                    Extension = x.Extension,
                    Number = x.Number,
                    Phone = x.Phone
                }).ToList()
            };
        }
    }
}