using System;
using DadataApiClient.Exceptions;

namespace DadataApiClient.Options
{
    public class DadataApiClientOptions
    {
        /// <summary>
        /// Authorization token in Dadata Api
        /// </summary>
        public string Token { get; set; }
        
        /// <summary>
        /// Secret token for authorization in the Dadata standardization API
        /// </summary>
        public string Secret { get; set; }
    }
}