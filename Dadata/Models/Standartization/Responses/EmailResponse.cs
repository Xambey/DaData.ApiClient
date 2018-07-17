using System.Collections.Generic;
using DaData.Models.Standartization.Results;

namespace DaData.Models.Standartization.Responses
{
    public class EmailResponse : BaseResponse
    {
        public List<EmailResult> Value { get; set; }
    }
}