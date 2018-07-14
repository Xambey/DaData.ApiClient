using System;
using System.Net;
using System.Threading.Tasks;
using DadataApiClient.Models.Additional.Responses;

namespace DadataApiClient.Interfaces
{
    public interface IDadataAdditionalApiClient : IDisposable
    {
        /// <summary>
        /// Get full hints for the address by ip address
        /// </summary>
        /// <param name="ip">list of queries  search for</param>
        /// <returns></returns>
        Task<DadataAddressQueryBaseResponse> AdditionalQueryDetectAddressByIp(string ip);
        
        /// <summary>
        /// Get full hints for the address by ip address
        /// </summary>
        /// <param name="ip">list of queries\  search for</param>
        /// <returns></returns>
        Task<DadataAddressQueryBaseResponse> AdditionalQueryDetectAddressByIp(IPAddress ip);
    }
}