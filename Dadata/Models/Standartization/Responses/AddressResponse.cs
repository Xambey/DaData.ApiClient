using System.Collections.Generic;
using System.Linq;
using DaData.Models.Standartization.Results;
using DaData.Models.Standartization.ShortResponses;
using DaData.Models.Standartization.ShortsResults;

namespace DaData.Models.Standartization.Responses
{
    public class AddressResponse : BaseResponse
    {
        public List<AddressResult> Value { get; set; }
        
        public AddressShortResponse ToShortResponse()
        {
            return new AddressShortResponse
            {
                Value = Value.Select(x => new AddressShortResult
                {
                    Source = x.Source,
                    FullName = x.Result,
                    Latitude = x.GeoLat,
                    Longitude = x.GeoLon,
                    PostalCode = x.PostalCode,
                    Area = x.Area,
                    Block = x.Block,
                    Country = x.Country,
                    Flat = x.Flat,
                    House = x.House,
                    Region = x.Region,
                    Settlement = x.Settlement,
                    Street = x.Street,
                    City = x.City
                }).ToList()
            };
        }
    }
}