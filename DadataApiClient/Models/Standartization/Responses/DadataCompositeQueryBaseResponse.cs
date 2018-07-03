using System.Collections.Generic;
using DadataApiClient.Models.Standartization.Results;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataCompositeQueryBaseResponse : BaseResponse
    {
        public List<DadataCompositeQueryResult> Value { get; set; }
    }
}