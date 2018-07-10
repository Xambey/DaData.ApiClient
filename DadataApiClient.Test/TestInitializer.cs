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
            
            if(directoryInfo != null && File.Exists(Path.Combine(directoryInfo.FullName,
                   "appsettings.json"))) {
                var options = JsonConvert.DeserializeObject<DadataApiClientOptions>(
                    File.ReadAllText(Path.Combine(directoryInfo.FullName,
                        "appsettings.json")));

                ApiClient = new DadataApiClient.DadataApiClient(options);
            }
            else
            {
                var options = new DadataApiClientOptions();
                var variables = Environment.GetEnvironmentVariables();
                if(variables.Contains("TOKEN"))
                    options.Token = Environment.GetEnvironmentVariable("TOKEN");
                if(variables.Contains("SECRET"))
                    options.Secret = Environment.GetEnvironmentVariable("SECRET");
                ApiClient = new DadataApiClient.DadataApiClient(options);
            }
        }
    }
}