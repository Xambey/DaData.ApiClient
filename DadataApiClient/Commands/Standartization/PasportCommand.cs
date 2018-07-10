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
    public class PasportCommand : StandartizationCommandBase
    {
        public PasportCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/passport";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is IEnumerable<string> temp) || !temp.Any())
                throw new InvalidQueryException(query);
            return new DadataPasportQueryBaseResponse
            {
                Value = await client.SendResponseAsync<List<DadataPasportQueryResult>>(HttpMethod.Post, new Uri(Url),
                    query)
            };
        }
    }
}