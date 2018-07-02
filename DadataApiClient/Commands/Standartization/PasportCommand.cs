using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Standartization
{
    public class PasportCommand : StandartizationCommandBase
    {
        public PasportCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/passport";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}