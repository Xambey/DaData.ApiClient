using System;
using System.Collections.Generic;
using System.IO;
using DaData;
using DaData.Models.Standartization.Requests;
using DaData.Options;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace Dadata.Test
{
    public class TestInitializer
    {
        protected ITestOutputHelper OutputHelper { get; set; }

        protected DaData.ApiClient ApiClient { get; set; }
        
        public TestInitializer(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
            var options = Configure();
            
            
            ApiClient = new DaData.ApiClient(options);
        }

        private ApiClientOptions Configure()
        {
            var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.Parent;
            ApiClientOptions options;

            var path = Path.Combine(directoryInfo?.FullName ?? "./", "appsettings.json");
            
            if (File.Exists(path))
            {
                options = JsonConvert.DeserializeObject<ApiClientOptions>(File.ReadAllText(path));
            }
            else
            {
                options = new ApiClientOptions();
                var variables = Environment.GetEnvironmentVariables();

                if (variables.Contains("TOKEN"))
                {
                    options.Token = Environment.GetEnvironmentVariable("TOKEN");
                }

                if (variables.Contains("SECRET"))
                {
                    options.Secret = Environment.GetEnvironmentVariable("SECRET");
                }
//                Console.WriteLine(JsonConvert.SerializeObject(options));
            }

            return options;
        }
    }
}