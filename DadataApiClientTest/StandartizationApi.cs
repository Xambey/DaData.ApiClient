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

        [Fact]
        async Task StandartizationQueryCarTest()
        {
            var result = await ApiClient.StandartizationQueryCar(new[] {"форд фокус"});
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            
            var first = result.Value.FirstOrDefault();

            Assert.NotNull(first);
            
            Assert.Equal("форд фокус", first.Source);
            Assert.Equal("FORD FOCUS", first.Result);
            Assert.Equal("FORD", first.Brand);
            Assert.Equal("FOCUS", first.Model);
            Assert.Equal(0, first.Qc);
        }
    }
}