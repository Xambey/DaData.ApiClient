using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Dadata.Test
{
    public class SuggestionsApi : TestInitializer
    {
        [Fact]
        public async Task SuggestionsQueryAddressTest()
        {
            var result = await ApiClient.SuggestionsQueryAddress("москва хабар");
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.Equal("г Москва, ул Хабаровская", firstSuggest.Value);
            Assert.NotNull(firstSuggest.Data);

            result = await ApiClient.SuggestionsQueryAddress("москва хабар", 3);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.Equal("г Москва, ул Хабаровская", firstSuggest.Value);
            Assert.NotNull(firstSuggest.Data);
        }
        
        [Fact]
        public async Task SuggestionsShortQueryAddressTest()
        {
            var result = await ApiClient.SuggestionsShortQueryAddress("г Москва, ул Сухонская, д 1А", 1);
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.FullName);
            Assert.NotNull(firstSuggest.Latitude);
            Assert.NotNull(firstSuggest.Longitude);
            Assert.NotNull(firstSuggest.Name);
        }
        
        [Fact]
        public async Task SuggestionsQueryFioTest()
        {
            var result = await ApiClient.SuggestionsQueryFio("Путуридзе");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Data);
        }
        
        [Fact]
        public async Task SuggestionsShortQueryFioTest()
        {
            var result = await ApiClient.SuggestionsShortQueryFio("Зураб Шотович Путуридзе");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Patronymic);
            Assert.NotNull(firstSuggest.Name);
            Assert.NotNull(firstSuggest.Surname);
        }
        
        [Fact]
        public async Task SuggestionsQueryBankTest()
        {
            var result = await ApiClient.SuggestionsQueryBank("Сбербанк");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Data);
        }
        
        [Fact]
      
        public async Task SuggestionsShortQueryBankTest()
        {
            var result = await ApiClient.SuggestionsShortQueryBank("Сбер");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Address);
            //Assert.NotNull(firstSuggest.Okpo);
            Assert.NotNull(firstSuggest.Bic);
        }
        
        [Fact]
        public async Task SuggestionsQueryOrganizationTest()
        {
            var result = await ApiClient.SuggestionsQueryOrganization("Сбербанк");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Data);
        }
        
        [Fact]
        public async Task SuggestionsShortQueryOrganizationTest()
        {
            var result = await ApiClient.SuggestionsShortQueryOrganization("Сбер");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Inn);
            Assert.NotNull(firstSuggest.Kpp);
        }
        
        [Fact]
        public async Task SuggestionsQueryEmail()
        {
            var result = await ApiClient.SuggestionsQueryEmail("xambey@yandex.ru");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Data);
        }
        
        [Fact]
        public async Task SuggestionsShortQueryEmail()
        {
            var result = await ApiClient.SuggestionsShortQueryEmail("xambey@gmail");
            
            Assert.NotNull(result);
            Assert.NotEmpty(result.Suggestions);

            var firstSuggest = result.Suggestions.FirstOrDefault();
            Assert.NotNull(firstSuggest);
            Assert.NotNull(firstSuggest.Value);
            Assert.NotNull(firstSuggest.UnrestrictedValue);
            Assert.NotNull(firstSuggest.Domain);
            Assert.NotNull(firstSuggest.Local);
        }

        public SuggestionsApi(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }
    }
}