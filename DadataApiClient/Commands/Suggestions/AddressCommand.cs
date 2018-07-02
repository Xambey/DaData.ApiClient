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
    public class AddressCommand : SuggestionsCommandBase
    {
        public AddressCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is Tuple<string,int?> temp) || string.IsNullOrEmpty(temp.Item1))
                throw new InvalidQueryException(query);
            
            var value = new JObject();
            value.Add("query", temp?.Item1);
            if (temp.Item2 != null)
                value.Add("count", temp.Item2);
            
            return await client.SendResponseAsync(HttpMethod.Post, new Uri(Url), value);
        }
    }
}