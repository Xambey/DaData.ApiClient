using System.Collections.Generic;

namespace DaData.Models.Standartization.Requests
{
    public class PasportRequest : BaseRequest
    {
        public List<string> Queries { get; set; }
    }
}