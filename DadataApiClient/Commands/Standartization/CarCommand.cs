using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using DadataApiClient.Models.Standartization.Responses;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Commands.Standartization
{
    public class CarCommand : StandartizationCommandBase
    {
        public CarCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/vehicle";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is List<string> temp) || temp.Count == 0)
                throw new InvalidQueryException(query);
            
            var value = new JArray(temp);
            
            return await client.SendResponseAsync<DadataCarQueryBaseResponse>(HttpMethod.Post, new Uri(Url), value);
        }
    }
}