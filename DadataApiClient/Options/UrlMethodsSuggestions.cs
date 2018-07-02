namespace DadataApiClient.Options
{
    /// <summary>
    /// Url methods of Suggestions API
    /// </summary>
    public class UrlMethodsSuggestions
    {
        public string FIO { get; set; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/fio";

        public string Address { get; set; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";

        public string Organization { get; set; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/party";

        public string Bank { get; set; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/bank";

        public string Email { get; set; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/email";
    }
}