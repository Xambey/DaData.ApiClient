using System.Collections.Generic;

namespace DaData.Models.Standartization.Requests
{
    public class EmailRequest : BaseRequest
    {
        public List<string> Queries { get; set; }
    }
}