using System;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggests.Responses;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Commands.Suggestions
{
    public class EmailCommand : SuggestionsCommandBase
    {
        public EmailCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/email";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is string temp) || string.IsNullOrEmpty(temp))
                throw new InvalidQueryException(query);
            
            var value = new JObject();
            value.Add("query", temp);

            return await client.SendResponseAsync<DadataEmailQueryBaseResponse>(HttpMethod.Post, new Uri(Url), value);
        }
    }
}