using System;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Extensions;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggestions.Requests;
using DadataApiClient.Models.Suggestions.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Commands.Suggestions
{
    public class AddressCommand : SuggestionsCommandBase
    {
        public AddressCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";
        }

        public static int v { get; set; } = 0;

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is DadataAddressQueryRequest temp) || string.IsNullOrEmpty(temp.Query))
                throw new InvalidQueryException(query);
            return await client.SendResponseAsync<DadataAddressQueryBaseResponse>(HttpMethod.Post, new Uri(Url), query);
        }
    }
}