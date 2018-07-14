

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DadataApiClient.Exceptions;
using DadataApiClient.Models;
using DadataApiClient.Models.Standartization.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DadataApiClient.Extensions
{
    public static class HttpExtensions
    {       
        public static async Task<TResponse> SendResponseAsync<TResponse>(this HttpClient client, HttpMethod method, Uri url, object value = null, Dictionary<string, object> queries = null) where TResponse : class
        {
            var httpRequestMessage = new HttpRequestMessage(method, url);
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };
            
            if(value != null)
                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(value, settings), Encoding.UTF8,
                "application/json");
            if (queries != null)
                foreach (var query in queries)
                {
                    httpRequestMessage.Properties.TryAdd(query.Key, query.Value);
                }

            using (HttpResponseMessage response = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead))
            {
                var result = await response.Content.ReadAsStringAsync();
                
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        Console.WriteLine(result + "\n" + response.StatusCode + response.ReasonPhrase);
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