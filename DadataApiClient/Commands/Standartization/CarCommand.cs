using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Standartization
{
    public class CarCommand : StandartizationCommandBase
    {
        public CarCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/vehicle";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}