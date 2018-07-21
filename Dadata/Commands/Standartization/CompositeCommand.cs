using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DaData.Commands.Base;
using DaData.Exceptions;
using DaData.Http;
using DaData.Http.Singleton;
using DaData.Models;
using DaData.Models.Standartization.Requests;
using DaData.Models.Standartization.Responses;
using DaData.Models.Standartization.Results;
using Uri = DaData.Http.Uri;

namespace DaData.Commands.Standartization
{
    public class CompositeCommand : StandartizationCommandBase
    {
        private static string Url { get; } = "https://dadata.ru/api/v2/clean";

        public override async Task<BaseResponse> Execute(object query)
        {
            if(!(query is CompositeRequest temp && temp.Data != null && temp.Data.HasValues && temp.Structure != null && temp.Structure.Any()))
                throw new InvalidQueryException(query);
            return new CompositeResponse
            {
                Value = await Client.SendResponseAsync<CompositeResult>(HttpMethod.Post, new Uri(Url),
                    query)
            };
        }
    }
}