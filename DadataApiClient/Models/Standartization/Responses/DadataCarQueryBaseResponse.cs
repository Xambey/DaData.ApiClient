using System.Collections.Generic;
using DadataApiClient.Models.Standartization.Results;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataCarQueryBaseResponse : BaseResponse
    {
        public List<DadataCarQueryResult> Value { get; set; }
    }
}