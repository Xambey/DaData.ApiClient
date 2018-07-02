using System;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using Newtonsoft.Json.Linq;

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
            if(!(query is string))
                throw new InvalidQueryException(query);

            var value = new JObject();
            value.Add("query", query as string);

            return await client.SendResponseAsync(HttpMethod.Post, new Uri(Url), value);
        }
    }
}