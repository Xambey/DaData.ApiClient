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
    public class EmailCommand : StandartizationCommandBase
    {
        public EmailCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/email";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is List<string> temp) || temp.Count == 0)
                throw new InvalidQueryException(query);
            
            var value = new JArray(temp);
            
            return await client.SendResponseAsync<DadataEmailQueryBaseResponse>(HttpMethod.Post, new Uri(Url), value);
        }
    }
}