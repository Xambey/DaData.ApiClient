using System;
using System.Collections;
using System.IO;
using DadataApiClient.Options;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace DadataApiClient.Test
{
    public class TestInitializer
    {
        protected ITestOutputHelper OutputHelper { get; set; }

        protected DadataApiClient ApiClient { get; set; }
        
        public TestInitializer(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            var options = Configure();
            
            
            ApiClient = new DadataApiClient(options);
        }

        private DadataApiClientOptions Configure()
        {
            var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.Parent;
            DadataApiClientOptions options;

            var path = Path.Combine(directoryInfo?.FullName ?? "./", "appsettings.json");
            
            if (File.Exists(path))
            {
                options = JsonConvert.DeserializeObject<DadataApiClientOptions>(File.ReadAllText(path));
            }
            else
            {
                options = new DadataApiClientOptions();
                var variables = Environment.GetEnvironmentVariables();
                foreach (DictionaryEntry entry in variables)
                {
                    if(entry.Key.ToString() == "Secret" || entry.Key.ToString() == "Token")
                        Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
                
                if(variables.Contains("TOKEN"))
                    options.Token = Environment.GetEnvironmentVariable("TOKEN");
                if(variables.Contains("SECRET"))
                    options.Secret = Environment.GetEnvironmentVariable("SECRET");
            }

            return options;
        }
    }
}