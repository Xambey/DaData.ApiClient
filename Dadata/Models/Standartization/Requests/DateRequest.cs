using System.Collections.Generic;

namespace DaData.Models.Standartization.Requests
{
    public class DateRequest : BaseRequest
    {
        public List<string> Queries { get; set; }
    }
}