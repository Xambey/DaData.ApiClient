

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DadataApiClient.Exceptions;
using DadataApiClient.Models;
using DadataApiClient.Models.Suggests.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<BaseResponse> SendResponseAsync(this HttpClient client, HttpMethod method, Uri url, JObject value)
        {
            var httpRequestMessage = new HttpRequestMessage(method, url);

            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json");
            
            using (HttpResponseMessage response = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead))
            {
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<DadataFioQueryBaseResponse>(result);
                throw new BadRequestException($"{response.StatusCode} {response.ReasonPhrase}");
            }
        }
    }
}