using DadataApiClient.Models.Suggests.Results;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Data
{
    public class DadataBankQueryData
    {
        public DadataQueryDataRkcOpf Opf { get; set; }
        
        public DadataQueryDataRkcName Name { get; set; }
        
        public string Bic { get; set; }
        
        public string Swift { get; set; }
        
        public string Okpo { get; set; }
        
        [JsonProperty("correspondent_account")] public string CorrespondentAccount { get; set; }
        
        [JsonProperty("registration_number")] public string RegistrationNumber { get; set; }
        
        public DadataQueryDataRkc Rkc { get; set; }

        public DadataAddressQueryResult Address { get; set; }
        
        public string Phone { get; set; }
        
        public DadataQueryDataState State { get; set; }
    }
}