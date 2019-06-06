using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using DaData.Converters;

namespace DaData.Models.Standartization.Results
{
    public class DateResult
    {
        public string Source { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "dd.MM.yyyy")]
        public DateTime Birthdate { get; set; }

        public int? Qc { get; set; }
    }
}