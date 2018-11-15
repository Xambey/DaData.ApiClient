using DaData.Models.Suggestions.Results;

namespace DaData.Models.Suggestions.Data
{
    public class RkcData
    {
        public RkcOpfData Opf { get; set; }
        
        public RkcNameData Name { get; set; }

        public string Bic { get; set; }

        public string Swift { get; set; }

        public string Okpo { get; set; }

        public string CorrespondentAccount { get; set; }
        
        public string RegistrationNumber { get; set; }
        
        public string Rkc { get; set; }
        
        public AddressResult Address { get; set; }
        
        public string Phone { get; set; }
        
        public DataState DataState { get; set; }
    }
}