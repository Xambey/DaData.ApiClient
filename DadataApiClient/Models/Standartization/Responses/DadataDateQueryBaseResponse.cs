using System.Collections.Generic;
using DadataApiClient.Models.Standartization.Data;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataDateQueryBaseResponse : BaseResponse
    {
        public List<DadataDateQueryResult> Value { get; set; }
    }
}