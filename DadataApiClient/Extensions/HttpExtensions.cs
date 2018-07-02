

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public static async Task<TResponse> SendResponseAsync<TResponse>(this HttpClient client, HttpMethod method, Uri url, JObject value) where TResponse : class
        {
            var httpRequestMessage = new HttpRequestMessage(method, url);

            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8,
                "application/json");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            using (HttpResponseMessage response = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead))
            {
                
                var result = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<TResponse>(result);
                throw new BadRequestException($"{response.StatusCode} {response.ReasonPhrase}");
            }
        }
    }
}