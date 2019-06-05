using System;

namespace DaData.Models.Additional.Data
{
    public class DataDocumentInfo
    {
        public string Type { get; set; }

        public string Series { get; set; }

        public string Number { get; set; }

        public DateTime? IssueDate { get; set; }

        public string IssueAuthority { get; set; }
    }
}