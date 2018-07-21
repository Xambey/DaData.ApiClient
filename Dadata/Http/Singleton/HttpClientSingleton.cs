using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using DaData.Options;

namespace DaData.Http.Singleton
{
    internal static class HttpClientSingleton
    {
        private static object MLock { get; } = new object();

        private static HttpClient Instance { get; set; }

        public static HttpClient GetInstance()
        {
            lock (MLock)
            {
                if (Instance == null)
                {
                    Instance = new HttpClient(new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip
                    });

                    Instance.DefaultRequestHeaders.Accept.Add(
                        MediaTypeWithQualityHeaderValue.Parse("application/json"));
                }

                return Instance;
            }
        }
        
        public static HttpClient GetInstance(ApiClientOptions options)
        {
            lock(MLock) 
            {
                if (Instance == null)
                {
                    Instance = new HttpClient(new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip
                    });

                    Instance.DefaultRequestHeaders.Accept.Add(
                        MediaTypeWithQualityHeaderValue.Parse("application/json"));
                    
                    if (options != null)
                    {
                        if(options.Token != null)
                            Instance.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue("Token", options.Token);
                        if(options.Secret != null)
                            Instance.DefaultRequestHeaders.Add("X-Secret", options.Secret);
                    }
                }

                return Instance;
            }
        }
    }
}