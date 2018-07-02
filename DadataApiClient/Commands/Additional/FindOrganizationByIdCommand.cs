using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Additional
{
    public class FindOrganizationByIdCommand : AdditionalCommandBase
    {
        public FindOrganizationByIdCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}