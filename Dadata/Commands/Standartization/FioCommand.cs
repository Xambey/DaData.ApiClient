using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Exceptions;
using DaData.Http;
using DaData.Models;
using DaData.Models.Standartization.Requests;
using DaData.Models.Standartization.Responses;
using DaData.Models.Standartization.Results;
using Uri = DaData.Http.Uri;

namespace DaData.Commands.Standartization
{
    public class FioCommand : StandartizationCommandBase
    {
        private static string Url { get; } = "https://dadata.ru/api/v2/clean/name";
        
        public override async Task<BaseResponse> Execute(BaseRequest query)
        {
            if(!(query is FioRequest temp)|| temp.Queries == null || !temp.Queries.Any())
                throw new InvalidQueryException(query);
            return new FioResponse
            {
                Value = await Client.SendResponseAsync<List<FioResult>>(HttpMethod.Post, new Uri(Url), temp.Queries)
            };
        }
    }
}