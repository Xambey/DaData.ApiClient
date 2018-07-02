using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Standartization
{
    public class DateCommand : StandartizationCommandBase
    {
        public DateCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/birthdate";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}