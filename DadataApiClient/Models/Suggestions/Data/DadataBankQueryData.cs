using DadataApiClient.Models.Suggestions.Results;

namespace DadataApiClient.Models.Suggestions.Data
{
    public class DadataBankQueryData 
    {
        public DadataQueryDataRkcOpf Opf { get; set; }
        
        public DadataQueryDataRkcName Name { get; set; }
        
        public string Bic { get; set; }
        
        public string Swift { get; set; }
        
        public string Okpo { get; set; }
        
        public string CorrespondentAccount { get; set; }
        
        public string RegistrationNumber { get; set; }
        
        public DadataQueryDataRkc Rkc { get; set; }

        public DadataAddressQueryResult Address { get; set; }
        
        public string Phone { get; set; }
        
        public DadataQueryDataState State { get; set; }
    }
}