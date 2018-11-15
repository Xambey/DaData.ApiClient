using System.Collections.Generic;

namespace DaData.Models.Additional.Data
{
    public class DataLicense
    {
        public string Series { get; set; }

        public string Number { get; set; }

        public string IssueDate { get; set; }

        public string IssueAuthority { get; set; }

        public string SuspendDate { get; set; }

        public string SuspendAuthority { get; set; }

        public long? ValidFrom { get; set; }

        public long? ValidTo { get; set; }

        public string Type { get; set; }

        public List<string> Activities { get; set; }

        public List<string> Addresses { get; set; }
    }
}