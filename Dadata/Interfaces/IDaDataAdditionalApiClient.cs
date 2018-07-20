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
        Task<AddressResponse> AdditionalQueryDetectAddressByIp(string ip);
        
        /// <summary>
        /// Get full hints for the address by ip address
        /// </summary>
        /// <param name="ip">ip address (if null, then the client address will be used by default)</param>
        /// <returns></returns>
        Task<AddressResponse> AdditionalQueryDetectAddressByIp(IPAddress ip = null);

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
        
        
    }
}