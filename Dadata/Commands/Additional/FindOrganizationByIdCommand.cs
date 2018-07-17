using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Models;

namespace DaData.Commands.Additional
{
    public class FindOrganizationByIdCommand : AdditionalCommandBase
    {
        private static string Url { get; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/party";

        public override Task<BaseResponse> Execute(object query, HttpClient client)
        {
            return base.Execute(query, client);
        }
    }
}