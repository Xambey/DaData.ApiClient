using System.Collections.Generic;
using DaData.Models.Additional.Results;

namespace DaData.Models.Additional.Responses
{
    public class OrganizationResponse : BaseResponse
    {
        public List<OrganizationResult> Suggestions { get; set; }
    }
}