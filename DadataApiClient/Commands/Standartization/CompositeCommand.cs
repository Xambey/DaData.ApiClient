using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using DadataApiClient.Models.Standartization.Requests;
using DadataApiClient.Models.Standartization.Responses;
using DadataApiClient.Models.Standartization.Results;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Commands.Standartization
{
    public class CompositeCommand : StandartizationCommandBase
    {
        public CompositeCommand()
        {
            Url = "https://dadata.ru/api/v2/clean";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is DadataCompositeQueryRequest temp && temp.Data != null && temp.Data.HasValues && temp.Structure != null && temp.Structure.Any()))
                throw new InvalidQueryException(query);
            return await client.SendResponseAsync<DadataCompositeQueryBaseResponse>(HttpMethod.Post, new Uri(Url), query);
        }
    }
}