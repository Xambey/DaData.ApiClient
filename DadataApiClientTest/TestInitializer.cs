using System;
using System.IO;
using DadataApiClient.Options;
using Newtonsoft.Json;

namespace DadataApiClientTest
{
    public class TestInitializer
    {
        public DadataApiClient.DadataApiClient ApiClient { get; set; }
        
        public TestInitializer()
        {
            var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.Parent;
            if (directoryInfo != null)
            {
                var options = JsonConvert.DeserializeObject<DadataApiClientOptions>(
                    File.ReadAllText(Path.Combine(directoryInfo.FullName,
                        "appsettings.json")));
            
                ApiClient = new DadataApiClient.DadataApiClient(options);
            }
        }
    }
}