using System;
using DaData.Converters;
using DaData.Models.Additional.Data;
using Newtonsoft.Json;

namespace DaData.Models.Additional.Responses
{
    public class UsageStatisticsResponse : BaseResponse
    {
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime Date { get; set; }
        public DataServices Services { get; set; }
    }
}