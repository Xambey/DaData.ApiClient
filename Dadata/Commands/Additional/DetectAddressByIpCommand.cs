using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Exceptions;
using DaData.Http;
using DaData.Models;
using DaData.Models.Additional.Requests;
using DaData.Models.Additional.Responses;
using DaData.Models.Additional.Results;
using Uri = DaData.Http.Uri;

namespace DaData.Commands.Additional
{
    public class DetectAddressByIpCommand : AdditionalCommandBase
    {
        private static string Url { get; } = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/detectAddressByIp";

        public override async Task<BaseResponse> Execute(BaseRequest query)
        {
            return new AddressByIpResponse
            {
                Value = await Client.SendResponseAsync<AddressByIpResult>(HttpMethod.Get, query != null && query is AddressByIpRequest temp ? new Uri(Url, new[]
                {
                    new KeyValuePair<string, object>("ip", temp.Ip ?? "")
                }) : new Uri(Url))
            };
        }
    }
}