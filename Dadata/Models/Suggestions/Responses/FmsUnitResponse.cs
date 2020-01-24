using DaData.Models.Suggestions.Results;

namespace DaData.Models.Suggestions.Responses
{
    public class FmsUnitResponse : BaseResponse
    {
        public FmsUnit[] Suggestions { get; set; }
    }
}