using System;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggestions.Requests;
using DadataApiClient.Models.Suggestions.Responses;

namespace DadataApiClient.Commands.Suggestions
{
    public class BankCommand : SuggestionsCommandBase
    {
        public BankCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/bank";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is DadataBankQueryRequest temp) || string.IsNullOrEmpty(temp.Query))
                throw new InvalidQueryException(query);
            return await client.SendResponseAsync<DadataBankQueryBaseResponse>(HttpMethod.Post, new Uri(Url), query);
        }
    }
}