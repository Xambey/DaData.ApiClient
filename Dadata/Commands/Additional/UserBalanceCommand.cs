using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Http;
using DaData.Http.Singleton;
using DaData.Models;
using DaData.Models.Additional.Responses;

namespace DaData.Commands.Additional
{
    public class UserBalanceCommand : AdditionalCommandBase
    {
        private static string Url { get; } = "https://dadata.ru/api/v2/profile/balance";

        public override async Task<BaseResponse> Execute(object query)
        {
            return await Client.SendResponseAsync<UserBalanceResponse>(HttpMethod.Get, new Uri(Url));
        }
    }
}