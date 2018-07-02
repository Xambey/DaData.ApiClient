using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Models;

namespace DadataApiClient.Commands.Additional
{
    public class UserBalanceCommand : AdditionalCommandBase
    {
        public UserBalanceCommand()
        {
            Url = "https://dadata.ru/api/v2/profile/balance";
        }

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}