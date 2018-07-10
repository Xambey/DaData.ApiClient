using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadataApiClient.Models.Standartization.Requests;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DadataApiClient.Test
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

        [Fact]
        async Task StandartizationQueryPhoneTest()
        {
            var result = await ApiClient.StandartizationQueryPhone(new[] {"тел 7165219 доб139"});
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            
            var first = result.Value.FirstOrDefault();

            Assert.NotNull(first);
            
            Assert.Equal("тел 7165219 доб139", first.Source);
            Assert.Equal("Стационарный", first.Type);
            Assert.Equal("+7 495 716-52-19 доб. 139", first.Phone);
            Assert.Equal("7", first.CountryCode);
            Assert.Equal("495", first.CityCode);
            Assert.Equal("7165219", first.Number);
            Assert.Equal("139", first.Extension);
            Assert.Equal("ОАО \"МГТС\"", first.Provider);
            Assert.Equal("Москва", first.Region);
            Assert.Equal("UTC+3", first.Timezone);
            Assert.Equal(0, first.QcConflict);
            Assert.Equal(1, first.Qc);
        }

        [Fact]
        async Task StandartizationQueryPasportTest()
        {
            var result = await ApiClient.StandartizationQueryPasport(new[] {"4509 235857"});
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            
            var first = result.Value.FirstOrDefault();

            Assert.NotNull(first);
            
            Assert.Equal("4509 235857", first.Source);
            Assert.Equal("45 09", first.Series);
            Assert.Equal("235857", first.Number);
            Assert.Equal(0, first.Qc);
        }

        [Fact]
        async Task StandartizationQueryFioTest()
        {
            var result = await ApiClient.StandartizationQueryFio(new[] { "Срегей владимерович иванов"} );
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            
            var first = result.Value.FirstOrDefault();

            Assert.NotNull(first);
            
            Assert.Equal("Срегей владимерович иванов", first.Source);
            Assert.Equal("Иванов Сергей Владимирович", first.Result);
            Assert.Equal("Иванова Сергея Владимировича", first.ResultGenitive);
            Assert.Equal("Иванову Сергею Владимировичу", first.ResultDative);
            Assert.Equal("Ивановым Сергеем Владимировичем", first.ResultAblative);
            Assert.Equal("Иванов", first.Surname);
            Assert.Equal("Сергей", first.Name);
            Assert.Equal("Владимирович", first.Patronymic);
            Assert.Equal("М", first.Gender);
            Assert.Equal(1, first.Qc);
        }

        [Fact]
        async Task StandartizationQueryEmailTest()
        {
            var result = await ApiClient.StandartizationQueryEmail(new[] { "serega@yandex/ru"} );
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            
            var first = result.Value.FirstOrDefault();

            Assert.NotNull(first);
            
            Assert.Equal("serega@yandex/ru", first.Source);
            Assert.Equal("serega@yandex.ru", first.Email);
            Assert.Equal(4, first.Qc);
        }
       
        [Fact]
        async Task StandartizationQueryDateTest()
        {
            var result = await ApiClient.StandartizationQueryDate(new[] { "24/3/12"} );
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            
            var first = result.Value.FirstOrDefault();

            Assert.NotNull(first);
            
            Assert.Equal("24/3/12", first.Source);
            Assert.Equal("24.03.2012", first.Birthdate);
            Assert.Equal(1, first.Qc);
        } 
        
        [Fact]
        async Task StandartizationQueryCompositeTest()
        {
            var result = await ApiClient.StandartizationQueryComposite(new DadataCompositeQueryRequest
            {
                Structure = new List<string>
                {
                    "AS_IS",
                    "NAME",
                    "ADDRESS",
                    "PHONE"
                },
                Data = JArray.Parse("[" +
                                    "    [ \"1\"," +
                                    "      \"Федотов Алексей\"," +
                                    "      \"Москва, Сухонская улица, 11 кв 89\"," +
                                    "      \"8 916 823 3454\"" +
                                    "    ]," +
                                    "    [ [\"2\"]," +
                                    "" +
                                    "      [\"мск\", \"улица свободы\", \"65\", \"12\"]," +
                                    "      [\"495 663-12-53\"]" +
                                    "    ]," +
                                    "    [ \"3\"," +
                                    "      [\"Ольга Павловна\", \"Ященко\"]," +
                                    "      [\"\", \"Спб, ул Петрозаводская 8\", \"\", \"\"]," +
                                    "      \"457 07 25\"" +
                                    "    ]" +
                                    "  ]"
                )
            } );
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            
            var first = result.Value.FirstOrDefault();

            Assert.NotNull(first);
            
            Assert.NotNull(first.Data);
            Assert.NotEmpty(first.Data);
        }

        public StandartizationApi(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }
    }
}