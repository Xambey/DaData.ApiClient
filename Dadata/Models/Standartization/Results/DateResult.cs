using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace DaData.Models.Standartization.Results
{
    public class DateResult
    {
        public string Source { get; set; }

        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Birthdate { get; set; }

        public int? Qc { get; set; }
    }
}