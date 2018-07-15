using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DadataApiClient.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DadataApiClient.Http
{
    public static class HttpExtensions
    {
        public static Uri AddQueryParameters(this System.Uri uri, IEnumerable<KeyValuePair<string, object>> queryParameters)
        {
            var builder = new StringBuilder(uri.ToString());
            if (queryParameters != null)
            {
                var parameters = queryParameters.ToList();
                var first = parameters.First();
                builder.Append($"{(string.IsNullOrEmpty(uri.Query) ? '?': '&')}{first.Key}={first.Value}");
                
                foreach (var parameter in parameters.Skip(1))
                {
                    builder.Append($"&{parameter.Key}={parameter.Value}");
                }
            }

            return new Uri(builder.ToString());
        }

        public static string AddQueryParameters(this string uriString,
            IEnumerable<KeyValuePair<string, object>> queryParameters) =>
            AddQueryParameters(new System.Uri(uriString), queryParameters).ToString();
        
        public static async Task<TResponse> SendResponseAsync<TResponse>(this HttpClient client, HttpMethod method, Uri uri, object value = null) where TResponse : class
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };
            
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value, settings), Encoding.UTF8,
                "application/json");

            using (HttpResponseMessage response = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false))
            {
                var result = await response.Content.ReadAsStringAsync();
                
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return JsonConvert.DeserializeObject<TResponse>(result, new JsonSerializerSettings
                        {
                            ContractResolver = new DefaultContractResolver
                            {
                                NamingStrategy = new SnakeCaseNamingStrategy()
                            },
                            Formatting = Formatting.Indented
                        });
                    case HttpStatusCode.PaymentRequired:
                        throw new PaymentRequiredException();
                    case HttpStatusCode.Forbidden:
                        throw new KeyIsNotExistException();
                    case HttpStatusCode.MethodNotAllowed:
                        throw new MethodAccessException();
                    case HttpStatusCode.RequestEntityTooLarge:
                        throw new TooManyRequestsPerSecondException();
                } 
                throw new BadRequestException($"{response.StatusCode.ToString()} {result}");
            }
        }
    }
}