using System;

namespace DaData.Models.Additional.Data
{
    public class DataFounder
    {
        public string Ogrn { get; set; }
        
        public string Inn { get; set; }

        public string Name { get; set; }

        public string Hid { get; set; }

        public string Type { get; set; }

        [Obsolete]
        public DataShare Share { get; set; }
    }
}