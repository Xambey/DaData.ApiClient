using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DadataApiClient.Models.Standartization.Requests;
using DadataApiClient.Models.Standartization.Responses;
using DadataApiClient.Models.Standartization.ShortResponses;

namespace DadataApiClient.Interfaces
{
    public interface IDadataStandartizationApiClient : IDisposable
    {
        /// <summary>
        /// Get full hints for the address
        /// </summary>
        /// <param name="queries">list of queries  search for</param>
        /// <returns></returns>
        Task<DadataAddressQueryBaseResponse> StandartizationQueryAddress(IEnumerable<string> queries);
        
        /// <summary>
        /// Get full hints for the address
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataAddressQueryBaseResponse> StandartizationQueryAddress(Models.Standartization.Requests.DadataAddressQueryRequest queries);
        
        /// <summary>
        /// Get short hints for the address
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataAddressQueryShortResponse> StandartizationShortQueryAddress(IEnumerable<string> queries);

        /// <summary>
        /// Get short hints for the address
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataAddressQueryShortResponse> StandartizationShortQueryAddress(
            Models.Standartization.Requests.DadataAddressQueryRequest queries);
        
        /// <summary>
        /// Get full hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataPhoneQueryBaseResponse> StandartizationQueryPhone(IEnumerable<string> queries);
        
        /// <summary>
        /// Get full hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataPhoneQueryBaseResponse> StandartizationQueryPhone(DadataPhoneQueryRequest queries);
        
        /// <summary>
        /// Get short hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataPhoneQueryShortResponse> StandartizationShortQueryPhone(IEnumerable<string> queries);
        
        /// <summary>
        /// Get short hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataPhoneQueryShortResponse> StandartizationShortQueryPhone(DadataPhoneQueryRequest queries);
        
        /// <summary>
        /// Get hints for the pasport
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataPasportQueryBaseResponse> StandartizationQueryPasport(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the pasport
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataPasportQueryBaseResponse> StandartizationQueryPasport(DadataPasportQueryRequest queries);
        
        /// <summary>
        /// Get full hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataFioQueryBaseResponse> StandartizationQueryFio(IEnumerable<string> queries);
        
        /// <summary>
        /// Get full hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataFioQueryBaseResponse> StandartizationQueryFio(DadataFioQueryRequest queries);
        
        /// <summary>
        /// Get short hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataFioQueryShortResponse> StandartizationShortQueryFio(IEnumerable<string> queries);
        
        /// <summary>
        /// Get short hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataFioQueryShortResponse> StandartizationShortQueryFio(DadataFioQueryRequest queries);
        
        /// <summary>
        /// Get hints for the email
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataEmailQueryBaseResponse> StandartizationQueryEmail(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the email
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataEmailQueryBaseResponse> StandartizationQueryEmail(DadataEmailQueryRequest queries);

        /// <summary>
        /// Get hints for the date
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataDateQueryBaseResponse> StandartizationQueryDate(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the date
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataDateQueryBaseResponse> StandartizationQueryDate(DadataDateQueryRequest queries);

        /// <summary>
        /// Get hints for the car
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataCarQueryBaseResponse> StandartizationQueryCar(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the car
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DadataCarQueryBaseResponse> StandartizationQueryCar(DadataCarQueryRequest queries);

        /// <summary>
        /// Get hints for the composite notes
        /// </summary>
        /// <param name="queries">requests to search for</param>
        /// <returns></returns>
        Task<DadataCompositeQueryBaseResponse> StandartizationQueryComposite(DadataCompositeQueryRequest queries);
    }
}