using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dadata.Test
{
    public class AdditionalApi : TestInitializer
    {
        public AdditionalApi(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }
        
        [Fact]
        async Task AdditionalQueryDetectAddressByIpTest()
        {
            var result = await ApiClient.AdditionalQueryDetectAddressByIp("46.226.227.20");

            Assert.NotNull(result.Value);
            Assert.NotNull(result.Value.Location);

            var location = result.Value.Location;

            Assert.NotNull(location.Value);
            Assert.NotNull(location.Data);
            
            result = await ApiClient.AdditionalQueryDetectAddressByIp();
            Assert.NotNull(result.Value);
        }
        
        [Fact]
        async Task AdditionalQueryFindAddressByIdTest()
        {
            var result = await ApiClient.AdditionalQueryFindAddressById("77000000000268400");

            Assert.NotNull(result);
            
            Assert.NotEmpty(result.Suggestions);
            var first = result.Suggestions.FirstOrDefault();
            
            Assert.NotNull(first);
            
            Assert.Equal("г Москва, ул Снежная", first.Value);
            Assert.Equal("г Москва, ул Снежная", first.UnrestrictedValue);
            
            Assert.NotNull(first.Data);

            var data = first.Data;
            
            Assert.Equal("129323", data.PostalCode);
            Assert.Equal("Россия", data.Country);
            Assert.Equal("0c5b2444-70a0-4932-980c-b4dc0d3f02b5", data.RegionFiasId);
            Assert.Equal("7700000000000", data.RegionKladrId);
            Assert.Equal("г Москва", data.RegionWithType);
            Assert.Equal("г", data.RegionType);
            Assert.Equal("город", data.RegionTypeFull);
            Assert.Equal("Москва", data.Region);
            
            Assert.Equal("0c5b2444-70a0-4932-980c-b4dc0d3f02b5", data.CityFiasId);
            Assert.Equal("7700000000000", data.CityKladrId);
            Assert.Equal("г Москва", data.CityWithType);
            Assert.Equal("г", data.CityType);
            Assert.Equal("город", data.CityTypeFull);
            Assert.Equal("Москва", data.City);
            
            Assert.Equal("9120b43f-2fae-4838-a144-85e43c2bfb29", data.StreetFiasId);
            Assert.Equal("77000000000268400", data.StreetKladrId);
            Assert.Equal("ул Снежная", data.StreetWithType);
            Assert.Equal("ул", data.StreetType);
            Assert.Equal("улица", data.StreetTypeFull);
            Assert.Equal("Снежная", data.Street);
            
            Assert.Equal("9120b43f-2fae-4838-a144-85e43c2bfb29", data.FiasId);
            Assert.Equal("77000000000000026840000", data.FiasCode);
            Assert.Equal("7", data.FiasLevel);
            Assert.Equal("0", data.FiasActualityState);
            Assert.Equal("77000000000268400", data.KladrId);
            Assert.Equal("0", data.CapitalMarker);
            Assert.Equal("45000000000", data.Okato);
            Assert.Equal("7716", data.TaxOffice);
            Assert.Equal("7716", data.TaxOfficeLegal);
            Assert.NotEmpty(data.GeoLat);
            Assert.NotEmpty(data.GeoLon);
            Assert.Equal("2", data.QcGeo);
            Assert.Equal("г Москва, ул Снежная", data.Source);
        }
    }
}