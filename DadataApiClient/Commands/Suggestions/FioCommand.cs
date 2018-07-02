using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DadataApiClient.Commands.Base;
using DadataApiClient.Exceptions;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Commands.Suggestions
{
    public class FioCommand : SuggestionsCommandBase
    {
        public FioCommand()
        {
            Url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/fio";
        }
        
        public override Task Execute(object query, HttpClient client)
        {
            if(!(query is string))
                throw new InvalidQueryException(query);
            
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, Url);

            var value = new JObject();
            value.Add("query", query as string);

            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json");

            using (HttpResponseMessage response = await ExecuteCommand(httpRequestMessage))
            {
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<DadataFioQueryResponse>(result);
                throw new BadRequestException($"{response.StatusCode} {response.ReasonPhrase}");
            }
        }
    }
}