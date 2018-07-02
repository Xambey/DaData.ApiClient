using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggests.Results;
using DadataApiClient.Models.Suggests.ShortResponses;
using DadataApiClient.Models.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Responses
{
    public class DadataAddressQueryBaseResponse : BaseResponse
    {
        [JsonProperty("suggestions")]
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
                    Longitude = x.Data.GeoLon
                }).ToList()
            };
        }
    }
}