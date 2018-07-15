using System;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Http;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggestions.Requests;
using DadataApiClient.Models.Suggestions.Responses;
using Uri = DadataApiClient.Http.Uri;

namespace DadataApiClient.Commands.Suggestions
{
    public class FioCommand : SuggestionsCommandBase
    {
        public FioCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/fio";
        }  
        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is DadataFioQueryRequest temp) || string.IsNullOrEmpty(temp.Query))
                throw new InvalidQueryException(query);
            return await client.SendResponseAsync<DadataFioQueryBaseResponse>(HttpMethod.Post, new Uri(Url), query);
        }
    }
}