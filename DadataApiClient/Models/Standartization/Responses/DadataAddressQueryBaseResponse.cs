using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Standartization.Data;
using DadataApiClient.Models.Standartization.ShortResponses;
using DadataApiClient.Models.Standartization.ShortsResults;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataAddressQueryBaseResponse : BaseResponse
    {
        public List<DadataAddressQueryResult> Value { get; set; }
        
        public DadataAddressQueryShortResponse ToShortResponse()
        {
            return new DadataAddressQueryShortResponse
            {
                Value = Value.Select(x => new DadataAddressQueryShortResult
                {
                    Name = x.Source,
                    FullName = x.Result,
                    Latitude = x.GeoLat,
                    Longitude = x.GeoLon,
                    PostalCode = x.PostalCode
                }).ToList()
            };
        }
    }
}