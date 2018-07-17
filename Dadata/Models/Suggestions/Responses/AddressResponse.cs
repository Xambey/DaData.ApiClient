using System.Collections.Generic;
using System.Linq;
using DaData.Models.Suggestions.Results;
using DaData.Models.Suggestions.ShortResponses;
using DaData.Models.Suggestions.ShortsResults;

namespace DaData.Models.Suggestions.Responses
{
    public class AddressResponse : BaseResponse
    {
        public List<AddressResult> Suggestions { get; set; }

        public AddressShortResponse ToShortResponse()
        {
            return new AddressShortResponse
            {
                Suggestions = Suggestions.Select(x => new AddressShortResult
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