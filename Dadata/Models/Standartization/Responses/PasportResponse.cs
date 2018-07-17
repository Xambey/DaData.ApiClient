using System.Collections.Generic;
using DaData.Models.Standartization.Results;

namespace DaData.Models.Standartization.Responses
{
    public class PasportResponse : BaseResponse
    {
        public List<PasportResult> Value { get; set; }
    }
}