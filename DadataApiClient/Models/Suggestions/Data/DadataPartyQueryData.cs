using DadataApiClient.Models.Suggestions.Results;

namespace DadataApiClient.Models.Suggestions.Data
{
    public class DadataPartyQueryData 
    {
        public string Kpp { get; set; }
        
        public string Capital { get; set; }
        
        public DadataQueryDataManagement DataManagement { get; set; }
        
        public string Founders { get; set; }
        
        public string Managers { get; set; }
        
        public string BranchType { get; set; }
        
        public string BranchCount { get; set; }

        public string Source { get; set; }
        
        public string Qc { get; set; }
        
        public string Hid { get; set; }
        
        public string Type { get; set; }
        
        public DadataQueryDataState DataState { get; set; }
        
        public DadataQueryDataOpf DataOpf { get; set; }
        
        public DadataQueryDataName DataName { get; set; }
        
        public string Inn { get; set; }
        
        public string Ogrn { get; set; }
        
        public string Okpo { get; set; }
        
        public string Okved { get; set; }
        
        public string Okveds { get; set; }
        
        public string Authorities { get; set; }
        
        public string Documents { get; set; }
        
        public string Licenses { get; set; }
        
        public DadataAddressQueryResult Address { get; set; }
        
        public string Phones { get; set; }
        
        public string Emails { get; set; }
        
        public string OrgnDate { get; set; }
        
        public string OkvedType { get; set; }
    }
}