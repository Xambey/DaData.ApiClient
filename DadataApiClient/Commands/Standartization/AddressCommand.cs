using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Standartization
{
    public class AddressCommand : StandartizationCommandBase
    {
        public AddressCommand()
        {
            Url = "https://dadata.ru/api/v2/clean/address";
        }

        public override async Task<BaseResponse> Execute(object query, HttpClient client)
        {
            
        }
    }
}