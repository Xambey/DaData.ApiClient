using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Additional
{
    public class MonitoringStandartizationCommand : AdditionalCommandBase
    {
        public MonitoringStandartizationCommand()
        {
            Url = "https://dadata.ru/api/v2/status/CLEAN";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}