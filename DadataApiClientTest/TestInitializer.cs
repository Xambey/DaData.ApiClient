using DadataApiClient;

namespace DadataApiClientTest
{
    public class TestInitializer
    {
        public DadataApiClient.DadataApiClient ApiClient { get; set; }
        
        public TestInitializer()
        {
            //TODO: hide tokens
            ApiClient = new DadataApiClient.DadataApiClient("Token f91389fb0453fd7f1e961a0b49bc35dee1c9ee09", "93bf1a6c17c21518cad9f4152de2543cc97f2c31");
        }
    }
}