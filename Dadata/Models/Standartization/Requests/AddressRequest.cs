using System.Collections.Generic;

namespace DaData.Models.Standartization.Requests
{
    public class AddressRequest : BaseRequest
    {
        public List<string> Queries { get; set; }
    }
}