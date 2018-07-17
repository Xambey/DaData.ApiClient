using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Exceptions;
using DaData.Http;
using DaData.Models;
using DaData.Models.Suggestions.Requests;
using DaData.Models.Suggestions.Responses;
using Uri = DaData.Http.Uri;

namespace DaData.Commands.Suggestions
{
    public class OrganizationCommand : SuggestionsCommandBase
    {
        private static string Url { get; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/party";
        
        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            if(!(query is OrganizationRequest temp) || string.IsNullOrEmpty(temp.Query))
                throw new InvalidQueryException(query);
            return await client.SendResponseAsync<OrganizationResponse>(HttpMethod.Post, new Uri(Url), query);
        }
    }
}