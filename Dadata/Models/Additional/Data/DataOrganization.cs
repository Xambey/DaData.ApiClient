
using System;
using System.Collections.Generic;
using DaData.Models.Enums;
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

        public OrganizationType Type { get; set; }

        public DataState State { get; set; }

        public DataOpf Opf { get; set; }

        public DataName Name { get; set; }

        public string Inn { get; set; }

        public string Ogrn { get; set; }

        public string Okpo { get; set; }

        public string Okved { get; set; }
        
        public List<DataOkved> Okveds { get; set; }

        public DataAuthority Authorities { get; set; }

        public DataDocument Documents { get; set; }

        public List<DataLicense> Licenses { get; set; }

        public AddressResult Address { get; set; }

        public List<string> Phones { get; set; }

        public List<string> Emails { get; set; }

        public DateTime? OgrnDate { get; set; }

        public string OkvedType { get; set; }
    }
}