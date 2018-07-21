
using System.Collections.Generic;
using DaData.Models.Suggestions.Results;

namespace DaData.Models.Additional.Data
{
    public class DataOrganization
    {
        public string Kpp { get; set; }

        public DataCapital Capital { get; set; }
        
        public DataManagement Management { get; set; }

        public List<DataFounder> Founders { get; set; }
        
        public List<DataManager> Managers { get; set; }

        public string BranchType { get; set; }
        
        public long? BranchCount { get; set; }

        public string Source { get; set; }

        public int? Qc { get; set; }

        public string Hid { get; set; }

        public string Type { get; set; }

        public DataState State { get; set; }

        public DataOpf Opf { get; set; }

        public DataName Name { get; set; }

        public string Inn { get; set; }

        public string Orgn { get; set; }

        public string Okpo { get; set; }

        public string Okved { get; set; }
        
        public List<DataOkved> Okveds { get; set; }

        public List<DataAuthority> Authorities { get; set; }

        public List<DataDocument> Documents { get; set; }

        public List<DataLicense> Licenses { get; set; }

        public AddressResult Address { get; set; }

        public List<string> Phones { get; set; }

        public List<string> Emails { get; set; }

        public long? OgrnDate { get; set; }

        public string OkvedType { get; set; }
    }
}