using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DadataApiClient.Test
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
//
//            var location = result.Value.Location;
//            
//            Assert.NotNull(location.Value);
//            Assert.NotNull(location.Data);
        }
    }
}