using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using DadataApiClient.Models.Standartization.Responses;
using DadataApiClient.Models.Standartization.Results;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Commands.Standartization
{
    public class DateCommand : StandartizationCommandBase
    {
        public DateCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/birthdate";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is IEnumerable<string> temp) || !temp.Any())
                throw new InvalidQueryException(query);
            
            var value = new JArray(temp);
            
            return new DadataDateQueryBaseResponse
            {
                Value = await client.SendResponseAsync<List<DadataDateQueryResult>>(HttpMethod.Post, new Uri(Url),
                    value)
            };
        }
    }
}