using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Additional
{
    public class DetectAddressByIpCommand : AdditionalCommandBase
    {
        public DetectAddressByIpCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/detectAddressByIp";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}