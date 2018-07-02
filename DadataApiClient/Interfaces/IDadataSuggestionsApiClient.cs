using System.Threading.Tasks;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Responses;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses;

namespace DadataApiClient
{
    /// <summary>
    /// Interface for creation client of Suggestions API
    /// </summary>
    public interface IDadataSuggestionsApiClient
    {
        /// <summary>
        /// Получить полные подсказки по адресу
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <param name="count">кол-во подсказок, если равен 1, то заполняются координаты</param>
        /// <returns></returns>
        Task<DadataAddressQueryResponse> SuggestsQueryAddress(string query, int? count = null);

        /// <summary>
        /// Получить короткие подсказки по адресу
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <param name="count">кол-во подсказок, если равен 1, то заполняются координаты</param>
        /// <returns></returns>
        Task<DadataAddressQueryShortResponse> SuggestsShortQueryAddress(string query, int? count = null);

        /// <summary>
        /// Получить полные подсказки по ФИО
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataFioQueryResponse> SuggestsQueryFio(string query);
        
        /// <summary>
        /// Получить короткие подсказки по ФИО
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataFioQueryShortResponse> SuggestsShortQueryFio(string query);

        /// <summary>
        /// Получить полные подсказки по организации
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataPartyQueryResponse> SuggestsQueryParty(string query);
        
        /// <summary>
        /// Получить короткие подсказки по организации
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataPartyQueryShortResponse> SuggestsShortQueryParty(string query);
        
        /// <summary>
        /// Получить полные подсказки по банку
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataBankQueryResponse> SuggestsQueryBank(string query);
        
        /// <summary>
        /// Получить короткие подсказки по банку
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataBankQueryShortResponse> SuggestsShortQueryBank(string query);
        
        /// <summary>
        /// Получить полные подсказки по email
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataEmailQueryResponse> SuggestsQueryEmail(string query);
        
        /// <summary>
        /// Получить короткие подсказки по email
        /// </summary>
        /// <param name="query">текст для поиска</param>
        /// <returns></returns>
        Task<DadataEmailQueryShortResponse> SuggestsShortQueryEmail(string query);
    }
}