using System;
using System.Linq;
using System.Threading.Tasks;
using DaData.Models.Enums;
using DaData.Models.Standartization.Requests;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Dadata.Test
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
            Assert.Equal("ПАО \"МГТС\"", first.Provider);
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
            Assert.Equal(Gender.Male, first.Gender);
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
            Assert.Equal(new DateTime(2012, 03, 24), first.Birthdate);
            Assert.Equal(1, first.Qc);
        } 
        
        [Fact]
        async Task StandartizationQueryCompositeTest()
        {
            var sb =
                "[\n" +
                "    [ \"1\",\n" +
                "      \"Федотов Алексей\",\n" +
                "      \"Москва, Сухонская улица, 11 кв 89\",\n" +
                "      \"8 916 823 3454\"\n" +
                "    ],\n" +
                "    [ \"2\",\n" +
                "      \"Иванов Сергей Владимирович\",\n" +
                "      \"мск,улица свободы,65,12\",\n" +
                "      \"495 663-12-53\"\n" +
                "    ],\n" +
                "    [ \"3\",\n" +
                "      \"Ольга Павловна Ященко\",\n" +
                "      \"Спб, ул Петрозаводская 8\",\n" +
                "      \"457 07 25\"\n" +
                "    ]\n" +
                "]";

            var request = new CompositeRequest
            {
                Structure = new JArray
                {
                    "AS_IS",
                    "NAME",
                    "ADDRESS",
                    "PHONE"
                },
                Data = JArray.Parse(sb)
            };
            
            var result = await ApiClient.StandartizationQueryComposite(request);
            
            Assert.NotNull(result);
            Assert.NotNull(result.Value);

            var first = result.Value;

            Assert.NotNull(first);
            
            Assert.NotNull(first.Data);
            Assert.NotEmpty(first.Data);

            var data = first.Data;

            var requests = data.Children<JArray>(); 
            
            var firstRequest = requests.ElementAt(0).Children<JObject>();

            var child1 = firstRequest.ElementAt(0);
            
            Assert.Equal("1", child1.Property("source").Value.ToString());
            
            var child2 = firstRequest.ElementAt(1);
            
            Assert.Equal("Федотов Алексей", child2.Property("source").Value.ToString());
            Assert.Equal("Федотов Алексей", child2.Property("result").Value.ToString());
            Assert.Equal(0, child2.Property("qc").Value.ToObject<int>());

            var child3 = firstRequest.ElementAt(2);

            Assert.Equal("Москва, Сухонская улица, 11 кв 89", child3.Property("source").Value.ToString());    
            Assert.Equal("г Москва, ул Сухонская, д 11, кв 89", child3.Property("result").Value.ToString());    
            Assert.Empty(child3.Property("unparsed_parts").Value.ToString());    
            Assert.Equal(0, child3.Property("qc").Value.ToObject<int>());

            var child4 = firstRequest.ElementAt(3);
            
            Assert.Equal("8 916 823 3454", child4.Property("source").Value.ToString()); 
            Assert.Equal("Мобильный", child4.Property("type").Value.ToString()); 
            Assert.Equal("+7 916 823-34-54", child4.Property("phone").Value.ToString()); 
            Assert.Equal(0, child4.Property("qc").Value.ToObject<int>());     
            
            var secondRequest = requests.ElementAt(1).Children<JObject>();
            
            child1 = secondRequest.ElementAt(0);
            
            Assert.Equal("2", child1.Property("source").Value.ToString());
            
            child2 = secondRequest.ElementAt(1);
            
            Assert.Equal("Иванов Сергей Владимирович", child2.Property("source").Value.ToString());
            Assert.Equal("Иванов Сергей Владимирович", child2.Property("result").Value.ToString());
            Assert.Equal(0, child2.Property("qc").Value.ToObject<int>());

            child3 = secondRequest.ElementAt(2);

            Assert.Equal("мск,улица свободы,65,12", child3.Property("source").Value.ToString());    
            Assert.Equal("г Москва, ул Свободы, д 65, кв 12", child3.Property("result").Value.ToString());     
            Assert.Empty(child3.Property("unparsed_parts").Value.ToString());    
            Assert.Equal(0, child3.Property("qc").Value.ToObject<int>());

            child4 = secondRequest.ElementAt(3);
            
            Assert.Equal("495 663-12-53", child4.Property("source").Value.ToString()); 
            Assert.Equal("Стационарный", child4.Property("type").Value.ToString()); 
            Assert.Equal("+7 495 663-12-53", child4.Property("phone").Value.ToString()); 
            Assert.Equal(0, child4.Property("qc").Value.ToObject<int>());
            
            var thirdRequest = requests.ElementAt(2).Children<JObject>();
            
            child1 = thirdRequest.ElementAt(0);
            
            Assert.Equal("3", child1.Property("source").Value.ToString());
            
            child2 = thirdRequest.ElementAt(1);
            
            Assert.Equal("Ольга Павловна Ященко", child2.Property("source").Value.ToString());
            Assert.Equal("Ященко Ольга Павловна", child2.Property("result").Value.ToString());
            Assert.Equal(0, child2.Property("qc").Value.ToObject<int>());

            child3 = thirdRequest.ElementAt(2);

            Assert.Equal("Спб, ул Петрозаводская 8", child3.Property("source").Value.ToString());    
            Assert.Equal("г Санкт-Петербург, ул Петрозаводская, д 8", child3.Property("result").Value.ToString());     
            Assert.Empty(child3.Property("unparsed_parts").Value.ToString());    
            Assert.Equal(0, child3.Property("qc").Value.ToObject<int>());

            child4 = thirdRequest.ElementAt(3);
            
            Assert.Equal("457 07 25", child4.Property("source").Value.ToString()); 
            Assert.Equal("Стационарный", child4.Property("type").Value.ToString()); 
            Assert.Equal("+7 812 457-07-25", child4.Property("phone").Value.ToString()); 
            Assert.Equal(1, child4.Property("qc").Value.ToObject<int>());
            
        }

        public StandartizationApi(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }
    }
}