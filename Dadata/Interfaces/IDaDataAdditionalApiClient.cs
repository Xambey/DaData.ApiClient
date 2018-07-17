using System;
using System.Net;
using System.Threading.Tasks;
using DaData.Models.Additional.Responses;

namespace DaData.Interfaces
{
    public interface IDaDataAdditionalApiClient : IDisposable
    {
        /// <summary>
        /// Get full hints for the address by ip address
        /// </summary>
        /// <param name="ip">list of queries  search for</param>
        /// <returns></returns>
        Task<AddressBaseResponse> AdditionalQueryDetectAddressByIp(string ip);
        
        /// <summary>
        /// Get full hints for the address by ip address
        /// </summary>
        /// <param name="ip">list of queries\  search for</param>
        /// <returns></returns>
        Task<AddressBaseResponse> AdditionalQueryDetectAddressByIp(IPAddress ip);
    }
}