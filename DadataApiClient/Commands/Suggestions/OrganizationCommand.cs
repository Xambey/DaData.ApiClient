using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

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
            
        }
    }
}