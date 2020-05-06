using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Converters;
using DaData.Exceptions;
using DaData.Http;
using DaData.Models;
using DaData.Models.Additional.Requests;
using DaData.Models.Additional.Responses;
using Newtonsoft.Json;

namespace DaData.Commands.Additional
{
    public class UsageStatisticsCommand : AdditionalCommandBase
    {
        private static string Url { get; } = "https://dadata.ru/api/v2/stat/daily";

        public override async Task<BaseResponse> Execute(object query)
        {
            if (query is UsageStatisticsRequest request && request.Date != null)
            {

                return await Client.SendResponseAsync<UsageStatisticsResponse>(HttpMethod.Get,
                    new Uri(Url.AddQueryParameters(new []
                    {
                        new KeyValuePair<string, object>("date", request.Date.Value.ToString("yyyy-MM-dd")), 
                    })));
            }

            if (query != null)
            {
                throw new InvalidQueryException();
            }
            return await Client.SendResponseAsync<UsageStatisticsResponse>(HttpMethod.Get, new Uri(Url));
        }
    }
}