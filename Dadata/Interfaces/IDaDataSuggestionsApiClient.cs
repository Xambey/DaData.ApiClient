using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaData.Models.Suggestions.Requests;
using DaData.Models.Suggestions.Responses;
using DaData.Models.Suggestions.ShortResponses;
using Newtonsoft.Json.Linq;

namespace DaData.Interfaces
{
    /// <summary>
    /// Interface for creation client of Suggestions API
    /// </summary>
    public interface IDaDataSuggestionsApiClient : IDisposable
    {
        /// <summary>
        /// Get full hints for the address
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <param name="count">the number of hints, if equal to 1, then the coordinates are filled</param>
        /// <param name="locations">list of locations</param>
        /// <param name="locationsBoost">list of boost locations</param>
        /// <returns></returns>
        Task<AddressResponse> SuggestionsQueryAddress(string query, int? count = null,
            List<JObject> locations = null, List<JObject> locationsBoost = null);

        /// <summary>
        /// Get short hints for the address
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <param name="count">the number of hints, if equal to 1, then the coordinates are filled</param>
        /// <param name="locations">list of locations</param>
        /// <param name="locationsBoost">list of boost locations</param>
        /// <returns></returns>
        Task<AddressShortResponse> SuggestionsShortQueryAddress(string query, int? count = null,
            List<JObject> locations = null, List<JObject> locationsBoost = null);

        /// <summary>
        /// Get full hints for the address
        /// </summary>
        /// <param name="query">object to search for</param>
        /// <returns></returns>
        Task<AddressResponse> SuggestionsQueryAddress(AddressRequest query);

        /// <summary>
        /// Get full hints for the FIO
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<FioResponse> SuggestionsQueryFio(string query);
        
        /// <summary>
        /// Get short hints for the FIO
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<FioShortResponse> SuggestionsShortQueryFio(string query);

        /// <summary>
        /// Get full hints for the organization
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<OrganizationResponse> SuggestionsQueryOrganization(string query);
        
        /// <summary>
        /// Get short hints for the organization
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<PartyShortResponse> SuggestionsShortQueryOrganization(string query);
        
        /// <summary>
        /// Get full hints for the bank
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<BankResponse> SuggestionsQueryBank(string query);
        
        /// <summary>
        /// Get short hints for the bank
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<BankShortResponse> SuggestionsShortQueryBank(string query);
        
        /// <summary>
        /// Get full hints for the email
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<EmailResponse> SuggestionsQueryEmail(string query);
        
        /// <summary>
        /// Get short hints for the email
        /// </summary>
        /// <param name="query">text to search for</param>
        /// <returns></returns>
        Task<EmailShortResponse> SuggestionsShortQueryEmail(string query);
    }
}