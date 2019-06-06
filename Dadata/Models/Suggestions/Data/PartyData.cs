using System;
using DaData.Models.Suggestions.Results;

namespace DaData.Models.Suggestions.Data
{
    public class PartyData 
    {
        public string Kpp { get; set; }
        
        public string Capital { get; set; }
        
        public DataManagement DataManagement { get; set; }
        
        public string Founders { get; set; }
        
        public string Managers { get; set; }
        
        public string BranchType { get; set; }
        
        public string BranchCount { get; set; }

        public string Source { get; set; }
        
        public string Qc { get; set; }
        
        public string Hid { get; set; }
        
        public string Type { get; set; }
        
        public DataState StateData { get; set; }
        
        public OpfData Data { get; set; }
        
        public DataName DataName { get; set; }
        
        public string Inn { get; set; }
        
        public string Ogrn { get; set; }
        
        public string Okpo { get; set; }
        
        public string Okved { get; set; }
        
        public string Okveds { get; set; }
        
        public string Authorities { get; set; }
        
        public string Documents { get; set; }
        
        public string Licenses { get; set; }
        
        public AddressResult Address { get; set; }
        
        public string Phones { get; set; }
        
        public string Emails { get; set; }
        
        public DateTime? OrgnDate { get; set; }
        
        public string OkvedType { get; set; }
    }
}