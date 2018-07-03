using System;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggestions.Responses;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Commands.Suggestions
{
    public class OrganizationCommand : SuggestionsCommandBase
    {
        public OrganizationCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/party";
        }
        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is string temp) || string.IsNullOrEmpty(temp))
                throw new InvalidQueryException(query);
            
            var value = new JObject();
            value.Add("query", temp);

            return await client.SendResponseAsync<DadataOrganizationQueryBaseResponse>(HttpMethod.Post, new Uri(Url), value);
        }
    }
}