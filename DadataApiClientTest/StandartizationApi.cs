using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DadataApiClientTest
{
    public class StandartizationApi : TestInitializer
    {
        [Fact]
        async Task StandartizationQueryAddressTest()
        {
            var result = await ApiClient.StandartizationQueryAddress(new[] {"мск сухонска 11/-89", "мск шаболовка 31"});
            
            Assert.NotNull(result);
            
            Assert.NotNull(result.Value);
            
            Assert.Equal(2, result.Value.Count);

            var first = result.Value.First();
            
            Assert.NotNull(first.Source);
            Assert.Equal("г Москва, ул Сухонская, д 11, кв 89", first.Result);
            Assert.NotNull(first.Metro);
            Assert.NotEmpty(first.Metro);
        }
    }
}