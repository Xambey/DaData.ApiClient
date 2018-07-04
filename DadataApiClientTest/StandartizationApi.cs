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
            
            Assert.Equal(result.Value.Count, 2);

            var first = result.Value.First();
            
            Assert.NotNull(first.Source);
            Assert.Equal(first.Result, "г Москва, ул Сухонская, д 11, кв 89");
            Assert.NotNull(first.Metro);
            Assert.NotEmpty(first.Metro);
        }
    }
}