using System.Collections.Generic;

namespace DaData.Models.Standartization.Requests
{
    public class FioRequest : BaseRequest
    {
        public List<string> Queries { get; set; }
    }
}