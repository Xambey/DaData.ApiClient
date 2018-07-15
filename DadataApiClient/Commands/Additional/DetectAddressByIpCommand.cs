using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Http;
using DadataApiClient.Models;
using DadataApiClient.Models.Additional.Responses;
using DadataApiClient.Models.Additional.Results;
using Newtonsoft.Json;
using Uri = DadataApiClient.Http.Uri;

namespace DadataApiClient.Commands.Additional
{
    public class DetectAddressByIpCommand : AdditionalCommandBase
    {
        public DetectAddressByIpCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/detectAddressByIp";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is string temp) || string.IsNullOrEmpty(temp))
                throw new InvalidQueryException(query);
            
            return new DadataAddressQueryBaseResponse
            {
                Value = await client.SendResponseAsync<DadataAddressQueryResult>(HttpMethod.Get, new Uri(Url, new[]
                {
                    new KeyValuePair<string, object>("ip", query)
                }))
            };
        }
    }
}