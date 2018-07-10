using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggestions.Results;
using DadataApiClient.Models.Suggestions.ShortResponses;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.Responses
{
    public class DadataAddressQueryBaseResponse : BaseResponse
    {
        public List<DadataAddressQueryResult> Suggestions { get; set; }

        public DadataAddressQueryShortResponse ToShortResponse()
        {
            return new DadataAddressQueryShortResponse
            {
                Suggestions = Suggestions.Select(x => new DadataAddressQueryShortResult
                {
                    Name = x.Value,
                    FullName = x.UnrestrictedValue,
                    Latitude = x.Data.GeoLat,
                    Longitude = x.Data.GeoLon,
                    PostalCode = x.Data.PostalCode
                }).ToList()
            };
        }
    }
}