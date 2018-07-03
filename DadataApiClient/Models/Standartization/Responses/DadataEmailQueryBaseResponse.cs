using System.Collections.Generic;
using DadataApiClient.Models.Standartization.Results;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataEmailQueryBaseResponse : BaseResponse
    {
        public List<DadataEmailQueryResult> Value { get; set; }
    }
}