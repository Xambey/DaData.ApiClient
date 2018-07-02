using System.Collections.Generic;
using System.Linq;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Results;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.Responses
{
    public class DadataAddressQueryResponse
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