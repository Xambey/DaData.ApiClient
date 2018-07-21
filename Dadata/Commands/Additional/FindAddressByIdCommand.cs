using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Exceptions;
using DaData.Http;
using DaData.Models;
using DaData.Models.Additional.Requests;
using DaData.Models.Suggestions.Responses;

namespace DaData.Commands.Additional
{
    public class FindAddressByIdCommand : AdditionalCommandBase
    {
        private static string Url { get; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/findById/address";

        public override async Task<BaseResponse> Execute(object query)
        {
            if(!(query is AddressByIdRequest temp) || string.IsNullOrEmpty(temp.Query))
                throw new InvalidQueryException(query);

            return await Client.SendResponseAsync<AddressResponse>(HttpMethod.Post, new Uri(Url), query);
        }
    }
}