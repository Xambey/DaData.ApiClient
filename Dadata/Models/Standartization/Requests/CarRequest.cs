using System.Collections.Generic;

namespace DaData.Models.Standartization.Requests
{
    public class CarRequest : BaseRequest
    {
        public List<string> Queries { get; set; }
    }
}