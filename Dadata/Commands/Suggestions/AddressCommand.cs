using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Exceptions;
using DaData.Http;
using DaData.Models;
using DaData.Models.Suggestions.Requests;
using DaData.Models.Suggestions.Responses;
using DaData.Singleton;
using Uri = DaData.Http.Uri;

namespace DaData.Commands.Suggestions
{
    public class AddressCommand : SuggestionsCommandBase
    {
        private static string Url { get; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";

        public override async Task<BaseResponse> Execute(BaseRequest query)
        {
            if(!(query is AddressRequest temp) || string.IsNullOrEmpty(temp.Query))
                throw new InvalidQueryException(query);
            return await HttpClientSingleton.GetInstance().SendResponseAsync<AddressResponse>(HttpMethod.Post, new Uri(Url), query);
        }
    }
}