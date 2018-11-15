using System.Collections.Generic;
using System.Linq;
using DaData.Models.Standartization.Results;
using DaData.Models.Standartization.ShortResponses;
using DaData.Models.Standartization.ShortsResults;

namespace DaData.Models.Standartization.Responses
{
    public class PhoneResponse : BaseResponse
    {
        public List<PhoneResult> Value { get; set; }
        
        public PhoneShortResponse ToShortResponse()
        {
            return new PhoneShortResponse
            {
                Value = Value.Select(x => new PhoneShortResult
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