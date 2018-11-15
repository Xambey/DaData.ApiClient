using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DaData.Models.Standartization.Requests;
using DaData.Models.Standartization.Responses;
using DaData.Models.Standartization.ShortResponses;

namespace DaData.Interfaces
{
    public interface IDaDataStandartizationApiClient : IDisposable
    {
        /// <summary>
        /// Get full hints for the address
        /// </summary>
        /// <param name="queries">list of queries  search for</param>
        /// <returns></returns>
        Task<AddressResponse> StandartizationQueryAddress(IEnumerable<string> queries);
        
        /// <summary>
        /// Get full hints for the address
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<AddressResponse> StandartizationQueryAddress(Models.Standartization.Requests.AddressRequest queries);
        
        /// <summary>
        /// Get short hints for the address
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<AddressShortResponse> StandartizationShortQueryAddress(IEnumerable<string> queries);

        /// <summary>
        /// Get short hints for the address
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<AddressShortResponse> StandartizationShortQueryAddress(
            Models.Standartization.Requests.AddressRequest queries);
        
        /// <summary>
        /// Get full hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<PhoneResponse> StandartizationQueryPhone(IEnumerable<string> queries);
        
        /// <summary>
        /// Get full hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<PhoneResponse> StandartizationQueryPhone(PhoneRequest queries);
        
        /// <summary>
        /// Get short hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<PhoneShortResponse> StandartizationShortQueryPhone(IEnumerable<string> queries);
        
        /// <summary>
        /// Get short hints for the phone
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<PhoneShortResponse> StandartizationShortQueryPhone(PhoneRequest queries);
        
        /// <summary>
        /// Get hints for the pasport
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<PasportResponse> StandartizationQueryPasport(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the pasport
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<PasportResponse> StandartizationQueryPasport(PasportRequest queries);
        
        /// <summary>
        /// Get full hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<FioResponse> StandartizationQueryFio(IEnumerable<string> queries);
        
        /// <summary>
        /// Get full hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<FioResponse> StandartizationQueryFio(FioRequest queries);
        
        /// <summary>
        /// Get short hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<FioShortResponse> StandartizationShortQueryFio(IEnumerable<string> queries);
        
        /// <summary>
        /// Get short hints for the FIO
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<FioShortResponse> StandartizationShortQueryFio(FioRequest queries);
        
        /// <summary>
        /// Get hints for the email
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<EmailResponse> StandartizationQueryEmail(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the email
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<EmailResponse> StandartizationQueryEmail(EmailRequest queries);

        /// <summary>
        /// Get hints for the date
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DateResponse> StandartizationQueryDate(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the date
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<DateResponse> StandartizationQueryDate(DateRequest queries);

        /// <summary>
        /// Get hints for the car
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<CarResponse> StandartizationQueryCar(IEnumerable<string> queries);
        
        /// <summary>
        /// Get hints for the car
        /// </summary>
        /// <param name="queries">list of queries for search</param>
        /// <returns></returns>
        Task<CarResponse> StandartizationQueryCar(CarRequest queries);

        /// <summary>
        /// Get hints for the composite notes
        /// </summary>
        /// <param name="queries">requests to search for</param>
        /// <returns></returns>
        Task<CompositeResponse> StandartizationQueryComposite(CompositeRequest queries);
    }
}