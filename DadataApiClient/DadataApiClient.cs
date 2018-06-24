using DadataApiClient.Options;

namespace DadataApiClient
{
    public class DadataApiClient
    {
        private readonly DadataApiClientOptions _options;
        
        public DadataApiClient(DadataApiClientOptions options)
        {
            if (string.IsNullOrEmpty(options.Token)) ;
        }
    }
}
