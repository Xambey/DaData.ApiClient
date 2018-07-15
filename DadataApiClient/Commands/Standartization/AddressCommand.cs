using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using DadataApiClient.Http;
using DadataApiClient.Models;
using DadataApiClient.Models.Standartization.Responses;
using DadataApiClient.Models.Standartization.Results;
using Uri = DadataApiClient.Http.Uri;

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
            if(!(query is IEnumerable<string> temp) || !temp.Any())
                throw new InvalidQueryException(query);
            return new DadataAddressQueryBaseResponse
            {
                Value = await client.SendResponseAsync<List<DadataAddressQueryResult>>(HttpMethod.Post, new Uri(Url),
                    query)
            };
        }
    }
}