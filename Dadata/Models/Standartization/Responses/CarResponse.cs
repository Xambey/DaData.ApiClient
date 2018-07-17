using System.Collections.Generic;
using DaData.Models.Standartization.Results;

namespace DaData.Models.Standartization.Responses
{
    public class CarResponse : BaseResponse
    {
        public List<CarResult> Value { get; set; }
    }
}