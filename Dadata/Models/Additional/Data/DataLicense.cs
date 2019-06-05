using System;
using System.Collections.Generic;

namespace DaData.Models.Additional.Data
{
    public class DataLicense
    {
        public string Series { get; set; }

        public string Number { get; set; }

        public DateTime? IssueDate { get; set; }

        public string IssueAuthority { get; set; }

        public DateTime? SuspendDate { get; set; }

        public string SuspendAuthority { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidTo { get; set; }

        public string Type { get; set; }

        public List<string> Activities { get; set; }

        public List<string> Addresses { get; set; }
    }
}