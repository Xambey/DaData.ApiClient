using DaData.Converters;
using DaData.Exceptions;
using DaData.Models.Additional.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Linq;
using DaData.Models.Enums;
using Xunit;

namespace Dadata.Test
{
    public class DeserializationTest
    {
        [Fact]
        public void DeserializeDataOrganization()
        {
            var data = JsonConvert.DeserializeObject<OrganizationResponse>(TestData, DeserializerSettings);
            Assert.NotNull(data);
            Assert.NotNull(data.Suggestions);
            Assert.NotEmpty(data.Suggestions);
            var organization = data.Suggestions.First();
            Assert.NotNull(organization?.Data);
            Assert.NotNull(organization.Data.Address);
            Assert.NotNull(organization.Data.Authorities);
            Assert.NotNull(organization.Data.Documents);
            Assert.Equal(OrganizationType.Legal, organization.Data.Type);
            var manager = organization.Data.Managers.First();
            Assert.Equal(ManagerType.Employee, manager.Type);
            Assert.Equal(Gender.Male, manager.Fio.Gender);
        }

        [Fact]
        public void DeserializeDataEntrepreneur()
        {
            var data = JsonConvert.DeserializeObject<OrganizationResponse>(TestDataEntrepreneur, DeserializerSettings);
            Assert.NotNull(data);
            Assert.NotNull(data.Suggestions);
            Assert.NotEmpty(data.Suggestions);
            var organization = data.Suggestions.First();
            Assert.NotNull(organization?.Data);
            Assert.NotNull(organization.Data.Address);
            Assert.NotNull(organization.Data.Authorities);
            Assert.NotNull(organization.Data.Documents);
            Assert.Equal(OrganizationType.Individual, organization.Data.Type);
        }

        [Theory]
        [InlineData("{Date:0}", "01/01/1970")]
        [InlineData("{Date:\"0\"}", "01/01/1970")]
        [InlineData("{Date:86400000}", "01/02/1970")]
        [InlineData("{Date:\"86400000\"}", "01/02/1970")]
        [InlineData("{Date:-86400000}", "12/31/1969")]
        [InlineData("{Date:\"-86400000\"}", "12/31/1969")]
        [InlineData("{Date:1577836800000}", "01/01/2020")]
        [InlineData("{Date:\"1577836800000\"}", "01/01/2020")]
        [InlineData("{Date:-2208988800000}", "01/01/1900")]
        [InlineData("{Date:\"-2208988800000\"}", "01/01/1900")]
        public void TimestampToDateTimeConverterTest(string serialized, string expected)
        {
            var expectedResult = DateTime.Parse(expected, CultureInfo.InvariantCulture);
            var result = JsonConvert.DeserializeObject<DateTimeTestModel>(serialized);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Date);
        }

        [Theory]
        [InlineData("{Date:0}", "01/01/1970")]
        [InlineData("{Date:\"0\"}", "01/01/1970")]
        [InlineData("{Date:86400000}", "01/02/1970")]
        [InlineData("{Date:\"86400000\"}", "01/02/1970")]
        [InlineData("{Date:-86400000}", "12/31/1969")]
        [InlineData("{Date:\"-86400000\"}", "12/31/1969")]
        [InlineData("{Date:1577836800000}", "01/01/2020")]
        [InlineData("{Date:\"1577836800000\"}", "01/01/2020")]
        [InlineData("{Date:-2208988800000}", "01/01/1900")]
        [InlineData("{Date:\"-2208988800000\"}", "01/01/1900")]
        public void TimestampToDateTimeOffsetConverterTest(string serialized, string expected)
        {
            var expectedResult = DateTimeOffset.Parse(expected, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            var result = JsonConvert.DeserializeObject<DateTimeOffsetTestModel>(serialized);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Date);
        }

        [Theory]
        [InlineData("{}", null)]
        [InlineData("{Date:null}", null)]
        [InlineData("{Date:\"0\"}", "01/01/1970")]
        [InlineData("{Date:1577836800000}", "01/01/2020")]
        [InlineData("{Date:\"-2208988800000\"}", "01/01/1900")]
        public void TimestampToNullableDateTimeConverterTest(string serialized, string expected)
        {
            var expectedResult = expected == null ? default(DateTime?) : DateTime.Parse(expected, CultureInfo.InvariantCulture);
            var result = JsonConvert.DeserializeObject<NullableDateTimeTestModel>(serialized);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Date);
        }

        [Theory]
        [InlineData("{}", null)]
        [InlineData("{Date:null}", null)]
        [InlineData("{Date:\"0\"}", "01/01/1970")]
        [InlineData("{Date:1577836800000}", "01/01/2020")]
        [InlineData("{Date:\"-2208988800000\"}", "01/01/1900")]
        public void TimestampToNullableDateTimeOffsetConverterTest(string serialized, string expected)
        {
            var expectedResult = expected == null ? default(DateTimeOffset?) : DateTimeOffset.Parse(expected, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            var result = JsonConvert.DeserializeObject<NullableDateTimeOffsetTestModel>(serialized);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Date);
        }

        [Theory]
        [InlineData("{Date:null}")]
        [InlineData("{Date:\"\"}")]
        [InlineData("{Date:true}")]
        [InlineData("{Date:false}")]
        [InlineData("{Date:\"string\"}")]
        [InlineData("{Date:\"15.34\"}")]
        public void TimestampConverterThrowsTest(string serialized)
        {
            Assert.Throws<JsonConverterException>(() => JsonConvert.DeserializeObject<DateTimeTestModel>(serialized));
        }

        private class TestModel
        {
            [JsonConverter(typeof(TimestampToDateTimeConverter))]
            public string Date { get; set; }
        }

        private class DateTimeTestModel
        {
            [JsonConverter(typeof(TimestampToDateTimeConverter))]
            public DateTime Date { get; set; }
        }

        private class NullableDateTimeTestModel
        {
            [JsonConverter(typeof(TimestampToDateTimeConverter))]
            public DateTime? Date { get; set; }
        }

        private class DateTimeOffsetTestModel
        {
            [JsonConverter(typeof(TimestampToDateTimeConverter))]
            public DateTimeOffset Date { get; set; }
        }

        private class NullableDateTimeOffsetTestModel
        {
            [JsonConverter(typeof(TimestampToDateTimeConverter))]
            public DateTimeOffset? Date { get; set; }
        }

        private static readonly JsonSerializerSettings DeserializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Converters = { new TimestampToDateTimeConverter() },
            Formatting = Formatting.Indented
        };

        private const string TestDataEntrepreneur = @"
            {
                ""suggestions"": [
                    {
                        ""value"": ""ИП Дерягин Илья Игоревич"",
                        ""unrestricted_value"": ""ИП Дерягин Илья Игоревич"",
                        ""data"": {
                            ""citizenship"": {
                                ""code"": {
                                    ""numeric"": 643,
                                    ""alpha_3"": ""RUS""
                                },
                                ""name"": {
                                    ""full"": ""Российская Федерация"",
                                    ""short"": ""Россия""
                                }
                            },
                            ""source"": null,
                            ""qc"": null,
                            ""hid"": ""6ce1552b1a504fb005f212b9ccd8526242189b78cf5552ee2c9481797602bdb4"",
                            ""type"": ""INDIVIDUAL"",
                            ""state"": {
                                ""status"": ""LIQUIDATED"",
                                ""actuality_date"": 1546300800000,
                                ""registration_date"": 1463616000000,
                                ""liquidation_date"": 1475539200000
                            },
                            ""opf"": {
                                ""type"": ""2014"",
                                ""code"": ""50102"",
                                ""full"": ""Индивидуальный предприниматель"",
                                ""short"": ""ИП""
                            },
                            ""name"": {
                                ""full_with_opf"": ""Индивидуальный предприниматель Дерягин Илья Игоревич"",
                                ""short_with_opf"": ""ИП Дерягин Илья Игоревич"",
                                ""latin"": null,
                                ""full"": ""Дерягин Илья Игоревич"",
                                ""short"": null
                            },
                            ""inn"": ""233530866500"",
                            ""ogrn"": ""316237300059429"",
                            ""okpo"": null,
                            ""okved"": ""73.20"",
                            ""okveds"": [
                                {
                                    ""main"": true,
                                    ""type"": ""2014"",
                                    ""code"": ""73.20"",
                                    ""name"": ""Исследование конъюнктуры рынка и изучение общественного мнения""
                                },
                                {
                                    ""main"": false,
                                    ""type"": ""2014"",
                                    ""code"": ""73.11"",
                                    ""name"": ""Деятельность рекламных агентств""
                                },
                                {
                                    ""main"": false,
                                    ""type"": ""2014"",
                                    ""code"": ""82.99"",
                                    ""name"": ""Деятельность по предоставлению прочих вспомогательных услуг для бизнеса, не включенная в другие группировки""
                                }
                            ],
                            ""authorities"": {
                                ""fts_registration"": {
                                    ""type"": ""FEDERAL_TAX_SERVICE"",
                                    ""code"": ""2375"",
                                    ""name"": ""Межрайонная инспекция Федеральной налоговой службы № 16 по Краснодарскому краю"",
                                    ""address"": "",350020,,, Краснодар г,, Коммунаров ул, д 235,,""
                                },
                                ""fts_report"": {
                                    ""type"": ""FEDERAL_TAX_SERVICE"",
                                    ""code"": ""2373"",
                                    ""name"": ""Межрайонная инспекция Федеральной налоговой службы № 14 по Краснодарскому краю"",
                                    ""address"": null
                                },
                                ""pf"": null,
                                ""sif"": null
                            },
                            ""documents"": {
                                ""fts_registration"": {
                                    ""type"": ""FTS_REGISTRATION"",
                                    ""series"": ""23"",
                                    ""number"": ""009660568"",
                                    ""issue_date"": 1463702400000,
                                    ""issue_authority"": ""2373""
                                },
                                ""pf_registration"": null,
                                ""sif_registration"": null,
                                ""smb"": null
                            },
                            ""licenses"": null,
                            ""address"": {
                                ""value"": ""Краснодарский край, г Кореновск"",
                                ""unrestricted_value"": ""Краснодарский край, Кореновский р-н, г Кореновск"",
                                ""data"": {
                                    ""postal_code"": ""353180"",
                                    ""country"": ""Россия"",
                                    ""federal_district"": null,
                                    ""region_fias_id"": ""d00e1013-16bd-4c09-b3d5-3cb09fc54bd8"",
                                    ""region_kladr_id"": ""2300000000000"",
                                    ""region_with_type"": ""Краснодарский край"",
                                    ""region_type"": ""край"",
                                    ""region_type_full"": ""край"",
                                    ""region"": ""Краснодарский"",
                                    ""area_fias_id"": ""c4c8da32-62f3-422e-828b-b3669d0231ea"",
                                    ""area_kladr_id"": ""2301500000000"",
                                    ""area_with_type"": ""Кореновский р-н"",
                                    ""area_type"": ""р-н"",
                                    ""area_type_full"": ""район"",
                                    ""area"": ""Кореновский"",
                                    ""city_fias_id"": ""76e1af12-0fae-42b0-8771-02191d803ad0"",
                                    ""city_kladr_id"": ""2301500100000"",
                                    ""city_with_type"": ""г Кореновск"",
                                    ""city_type"": ""г"",
                                    ""city_type_full"": ""город"",
                                    ""city"": ""Кореновск"",
                                    ""city_area"": null,
                                    ""city_district_fias_id"": null,
                                    ""city_district_kladr_id"": null,
                                    ""city_district_with_type"": null,
                                    ""city_district_type"": null,
                                    ""city_district_type_full"": null,
                                    ""city_district"": null,
                                    ""settlement_fias_id"": null,
                                    ""settlement_kladr_id"": null,
                                    ""settlement_with_type"": null,
                                    ""settlement_type"": null,
                                    ""settlement_type_full"": null,
                                    ""settlement"": null,
                                    ""street_fias_id"": null,
                                    ""street_kladr_id"": null,
                                    ""street_with_type"": null,
                                    ""street_type"": null,
                                    ""street_type_full"": null,
                                    ""street"": null,
                                    ""house_fias_id"": null,
                                    ""house_kladr_id"": null,
                                    ""house_type"": null,
                                    ""house_type_full"": null,
                                    ""house"": null,
                                    ""block_type"": null,
                                    ""block_type_full"": null,
                                    ""block"": null,
                                    ""flat_type"": null,
                                    ""flat_type_full"": null,
                                    ""flat"": null,
                                    ""flat_area"": null,
                                    ""square_meter_price"": null,
                                    ""flat_price"": null,
                                    ""postal_box"": null,
                                    ""fias_id"": ""76e1af12-0fae-42b0-8771-02191d803ad0"",
                                    ""fias_code"": ""23015001000000000000000"",
                                    ""fias_level"": ""4"",
                                    ""fias_actuality_state"": ""0"",
                                    ""kladr_id"": ""2301500100000"",
                                    ""geoname_id"": null,
                                    ""capital_marker"": ""1"",
                                    ""okato"": ""03221501000"",
                                    ""oktmo"": ""03621101001"",
                                    ""tax_office"": ""2373"",
                                    ""tax_office_legal"": ""2373"",
                                    ""timezone"": ""UTC+3"",
                                    ""geo_lat"": ""45.4641703"",
                                    ""geo_lon"": ""39.458949"",
                                    ""beltway_hit"": null,
                                    ""beltway_distance"": null,
                                    ""metro"": null,
                                    ""qc_geo"": ""4"",
                                    ""qc_complete"": null,
                                    ""qc_house"": null,
                                    ""history_values"": null,
                                    ""unparsed_parts"": null,
                                    ""source"": ""КРАЙ КРАСНОДАРСКИЙ, РАЙОН КОРЕНОВСКИЙ, ГОРОД КОРЕНОВСК"",
                                    ""qc"": ""0""
                                }
                            },
                            ""phones"": null,
                            ""emails"": [
                                {
                                    ""value"": ""BOGATIR86@MAIL.RU"",
                                    ""unrestricted_value"": ""BOGATIR86@MAIL.RU"",
                                    ""data"": {
                                        ""local"": ""BOGATIR86"",
                                        ""domain"": ""MAIL.RU"",
                                        ""source"": ""BOGATIR86@MAIL.RU"",
                                        ""qc"": null
                                    }
                                }
                            ],
                            ""ogrn_date"": null,
                            ""okved_type"": ""2014""
                        }
                    }
                ]
            }";

        private const string TestData = @"
            {
                ""suggestions"": [
                    {
                        ""value"": ""ПАО СБЕРБАНК"",
                        ""unrestricted_value"": ""ПАО СБЕРБАНК"",
                        ""data"": {
                            ""kpp"": ""773601001"",
                            ""capital"": {
                                ""type"": ""УСТАВНЫЙ КАПИТАЛ"",
                                ""value"": 67760844000
                            },
                            ""management"": {
                                ""name"": ""Греф Герман Оскарович"",
                                ""post"": ""Президент, председатель правления""
                            },
                            ""founders"": [
                                {
                                    ""ogrn"": null,
                                    ""inn"": ""7702235133"",
                                    ""name"": ""ЦЕНТРАЛЬНЫЙ БАНК РОССИЙСКОЙ ФЕДЕРАЦИИ"",
                                    ""hid"": ""33b78a80c782d847d02a7e7a53d3aa17a5dff9a1cb5ec73d0311423dcc065a89"",
                                    ""type"": ""LEGAL"",
                                    ""share"": null
                                }
                            ],
                            ""managers"": [
                                {
                                    ""inn"": ""770303580308"",
                                    ""fio"": {
                                        ""surname"": ""Греф"",
                                        ""name"": ""Герман"",
                                        ""patronymic"": ""Оскарович"",
                                        ""gender"": ""MALE"",
                                        ""source"": ""ГРЕФ ГЕРМАН ОСКАРОВИЧ"",
                                        ""qc"": null
                                    },
                                    ""post"": ""Президент, председатель правления"",
                                    ""hid"": ""8aca73ef155e20b8ba6687d23521630e8fbe9b505b388cb9cb12eb1c43b68253"",
                                    ""type"": ""EMPLOYEE""
                                }
                            ],
                            ""branch_type"": ""MAIN"",
                            ""branch_count"": 93,
                            ""source"": null,
                            ""qc"": null,
                            ""hid"": ""145a83ab38c9ad95889a7b894ce57a97cf6f6d5f42932a71331ff18606edecc6"",
                            ""type"": ""LEGAL"",
                            ""state"": {
                                ""status"": ""ACTIVE"",
                                ""actuality_date"": 1521590400000,
                                ""registration_date"": 677376000000,
                                ""liquidation_date"": null
                            },
                            ""opf"": {
                                ""type"": ""2014"",
                                ""code"": ""12247"",
                                ""full"": ""Публичное акционерное общество"",
                                ""short"": ""ПАО""
                            },
                            ""name"": {
                                ""full_with_opf"": ""ПУБЛИЧНОЕ АКЦИОНЕРНОЕ ОБЩЕСТВО \""СБЕРБАНК РОССИИ\"""",
                                ""short_with_opf"": ""ПАО СБЕРБАНК"",
                                ""latin"": null,
                                ""full"": ""СБЕРБАНК РОССИИ"",
                                ""short"": ""СБЕРБАНК""
                            },
                            ""inn"": ""7707083893"",
                            ""ogrn"": ""1027700132195"",
                            ""okpo"": null,
                            ""okved"": ""64.19"",
                            ""okveds"": [
                                {
                                    ""main"": true,
                                    ""type"": ""2014"",
                                    ""code"": ""64.19"",
                                    ""name"": ""Денежное посредничество прочее""
                                }
                            ],
                            ""authorities"": {
                                ""fts_registration"": {
                                    ""type"": ""FEDERAL_TAX_SERVICE"",
                                    ""code"": ""7700"",
                                    ""name"": ""Управление Федеральной налоговой службы по г.Москве"",
                                    ""address"": ""125284, г.Москва, Хорошевское ш., 12А""
                                },
                                ""fts_report"": {
                                    ""type"": ""FEDERAL_TAX_SERVICE"",
                                    ""code"": ""7736"",
                                    ""name"": ""Инспекция Федеральной налоговой службы № 36 по г.Москве"",
                                    ""address"": null
                                },
                                ""pf"": {
                                    ""type"": ""PENSION_FUND"",
                                    ""code"": ""087705"",
                                    ""name"": ""Государственное учреждение - Главное Управление Пенсионного фонда РФ №4 Управление №1 по г. Москве и Московской области муниципальный район Гагаринский г.Москвы"",
                                    ""address"": null
                                },
                                ""sif"": {
                                    ""type"": ""SOCIAL_INSURANCE_FUND"",
                                    ""code"": ""7706"",
                                    ""name"": ""Филиал №6 Государственного учреждения - Московского регионального отделения Фонда социального страхования Российской Федерации"",
                                    ""address"": null
                                }
                            },
                            ""documents"": {
                                ""fts_registration"": {
                                    ""type"": ""FTS_REGISTRATION"",
                                    ""series"": ""77"",
                                    ""number"": ""4856976"",
                                    ""issue_date"": 1029456000000,
                                    ""issue_authority"": ""7700""
                                },
                                ""pf_registration"": {
                                    ""type"": ""PF_REGISTRATION"",
                                    ""series"": null,
                                    ""number"": ""087705007215"",
                                    ""issue_date"": 1283472000000,
                                    ""issue_authority"": ""087705""
                                },
                                ""sif_registration"": {
                                    ""type"": ""SIF_REGISTRATION"",
                                    ""series"": null,
                                    ""number"": ""770600307277061"",
                                    ""issue_date"": 978566400000,
                                    ""issue_authority"": ""7706""
                                }
                            },
                            ""licenses"": [
                                {
                                    ""series"": null,
                                    ""number"": ""045-02894-100000"",
                                    ""issue_date"": 975283200000,
                                    ""issue_authority"": ""Центральный банк Российской Федерации"",
                                    ""suspend_date"": null,
                                    ""suspend_authority"": null,
                                    ""valid_from"": 1444089600000,
                                    ""valid_to"": null,
                                    ""activities"": [
                                        ""Брокерская деятельность""
                                    ],
                                    ""addresses"": [
                                        ""Г. МОСКВА""
                                    ]
                                }
                            ],
                            ""address"": {
                                ""value"": ""г Москва, ул Вавилова, д 19"",
                                ""unrestricted_value"": ""г Москва, Академический р-н, ул Вавилова, д 19"",
                                ""data"": {
                                    ""postal_code"": ""117312"",
                                    ""country"": ""Россия"",
                                    ""federal_district"": null,
                                    ""region_fias_id"": ""0c5b2444-70a0-4932-980c-b4dc0d3f02b5"",
                                    ""region_kladr_id"": ""7700000000000"",
                                    ""region_with_type"": ""г Москва"",
                                    ""region_type"": ""г"",
                                    ""region_type_full"": ""город"",
                                    ""region"": ""Москва"",
                                    ""area_fias_id"": null,
                                    ""area_kladr_id"": null,
                                    ""area_with_type"": null,
                                    ""area_type"": null,
                                    ""area_type_full"": null,
                                    ""area"": null,
                                    ""city_fias_id"": ""0c5b2444-70a0-4932-980c-b4dc0d3f02b5"",
                                    ""city_kladr_id"": ""7700000000000"",
                                    ""city_with_type"": ""г Москва"",
                                    ""city_type"": ""г"",
                                    ""city_type_full"": ""город"",
                                    ""city"": ""Москва"",
                                    ""city_area"": ""Юго-западный"",
                                    ""city_district_fias_id"": null,
                                    ""city_district_kladr_id"": null,
                                    ""city_district_with_type"": ""Академический р-н"",
                                    ""city_district_type"": ""р-н"",
                                    ""city_district_type_full"": ""район"",
                                    ""city_district"": ""Академический"",
                                    ""settlement_fias_id"": null,
                                    ""settlement_kladr_id"": null,
                                    ""settlement_with_type"": null,
                                    ""settlement_type"": null,
                                    ""settlement_type_full"": null,
                                    ""settlement"": null,
                                    ""street_fias_id"": ""25f8f29b-b110-40ab-a48e-9c72f5fb4331"",
                                    ""street_kladr_id"": ""77000000000092400"",
                                    ""street_with_type"": ""ул Вавилова"",
                                    ""street_type"": ""ул"",
                                    ""street_type_full"": ""улица"",
                                    ""street"": ""Вавилова"",
                                    ""house_fias_id"": ""93409d8c-d8d4-4491-838f-f9aa1678b5e6"",
                                    ""house_kladr_id"": ""7700000000009240170"",
                                    ""house_type"": ""д"",
                                    ""house_type_full"": ""дом"",
                                    ""house"": ""19"",
                                    ""block_type"": null,
                                    ""block_type_full"": null,
                                    ""block"": null,
                                    ""flat_type"": null,
                                    ""flat_type_full"": null,
                                    ""flat"": null,
                                    ""flat_area"": null,
                                    ""square_meter_price"": null,
                                    ""flat_price"": null,
                                    ""postal_box"": null,
                                    ""fias_id"": ""93409d8c-d8d4-4491-838f-f9aa1678b5e6"",
                                    ""fias_code"": ""77000000000000009240170"",
                                    ""fias_level"": ""8"",
                                    ""fias_actuality_state"": ""0"",
                                    ""kladr_id"": ""7700000000009240170"",
                                    ""geoname_id"": null,
                                    ""capital_marker"": ""0"",
                                    ""okato"": ""45293554000"",
                                    ""oktmo"": ""45397000"",
                                    ""tax_office"": ""7736"",
                                    ""tax_office_legal"": ""7736"",
                                    ""timezone"": ""UTC+3"",
                                    ""geo_lat"": ""55.7001865"",
                                    ""geo_lon"": ""37.5802234"",
                                    ""beltway_hit"": ""IN_MKAD"",
                                    ""beltway_distance"": null,
                                    ""metro"": [
                                        {
                                            ""name"": ""Ленинский проспект"",
                                            ""line"": ""Калужско-Рижская"",
                                            ""distance"": 0.8
                                        },
                                        {
                                            ""name"": ""Площадь Гагарина"",
                                            ""line"": ""МЦК"",
                                            ""distance"": 0.8
                                        },
                                        {
                                            ""name"": ""Академическая"",
                                            ""line"": ""Калужско-Рижская"",
                                            ""distance"": 1.5
                                        }
                                    ],
                                    ""qc_geo"": ""0"",
                                    ""qc_complete"": null,
                                    ""qc_house"": null,
                                    ""history_values"": null,
                                    ""unparsed_parts"": null,
                                    ""source"": ""117997, ГОРОД МОСКВА, УЛИЦА ВАВИЛОВА, 19"",
                                    ""qc"": ""0""
                                }
                            },
                            ""phones"": null,
                            ""emails"": null,
                            ""ogrn_date"": 1029456000000,
                            ""okved_type"": ""2014""
                        }
                    }
                ]
            }";
    }
}