using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Additional
{
    public class FindAddressByIdCommand : AdditionalCommandBase
    {
        public FindAddressByIdCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/address";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}