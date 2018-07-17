using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Models;

namespace DaData.Commands.Additional
{
    public class UserBalanceCommand : AdditionalCommandBase
    {
        private static string Url { get; } = "https://dadata.ru/api/v2/profile/balance";

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}