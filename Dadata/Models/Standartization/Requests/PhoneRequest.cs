using System.Collections.Generic;

namespace DaData.Models.Standartization.Requests
{
    public class PhoneRequest : BaseRequest
    {
        public List<string> Queries { get; set; }
    }
}