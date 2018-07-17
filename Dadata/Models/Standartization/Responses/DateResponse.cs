using System.Collections.Generic;
using DaData.Models.Standartization.Results;

namespace DaData.Models.Standartization.Responses
{
    public class DateResponse : BaseResponse
    {
        public List<DateResult> Value { get; set; }
    }
}