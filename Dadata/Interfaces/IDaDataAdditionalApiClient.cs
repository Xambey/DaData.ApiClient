using System;
using System.Net;
using System.Threading.Tasks;
using DaData.Models.Additional.Requests;
using DaData.Models.Additional.Responses;

namespace DaData.Interfaces
{
    public interface IDaDataAdditionalApiClient : IDisposable
    {
        /// <summary>
        /// Get full hints for the address by ip address
        /// </summary>
        /// <param name="ip">ip address (if null, then the client address will be used by default)</param>
        /// <returns></returns>
        Task<AddressByIpResponse> AdditionalQueryDetectAddressByIp(string ip);
        
        /// <summary>
        /// Get full hints for the address by ip address
        /// </summary>
        /// <param name="ip">ip address (if null, then the client address will be used by default)</param>
        /// <returns></returns>
        Task<AddressByIpResponse> AdditionalQueryDetectAddressByIp(IPAddress ip = null);

        /// <summary>
        /// Get full hints for the address by ip KLADR or FIAS
        /// </summary>
        /// <param name="query">ip address of FIAS or KLADR</param>
        /// <returns></returns>
        Task<Models.Suggestions.Responses.AddressResponse> AdditionalQueryFindAddressById(string query);
        
        /// <summary>
        /// Get full hints for the address by ip KLADR or FIAS
        /// </summary>
        /// <param name="query">ip address of FIAS or KLADR</param>
        /// <returns></returns>
        Task<Models.Suggestions.Responses.AddressResponse> AdditionalQueryFindAddressById(AddressByIdRequest query);

        /// <summary>
        /// Get full hints for the company or individual entrepreneur by INN or OGRN
        /// </summary>
        /// <param name="query">object of request</param>
        /// <returns></returns>
        Task<OrganizationResponse> AdditionalQueryOrganizationByInnOrOgrn(OrganizationRequest query);
        
        /// <summary>
        /// Get full hints for the company or individual entrepreneur by INN or OGRN
        /// </summary>
        /// <param name="query">object of request</param>
        /// <returns></returns>
        Task<OrganizationResponse> AdditionalQueryOrganizationByInnOrOgrn(string query, string type = null, string branchType = null);

        /// <summary>
        /// Get information about actuality of directories
        /// </summary>
        /// <returns></returns>
        Task<DateRelevanceDirectoriesResponse> AdditionalQueryDateRelevanceDirectories();
    }
}