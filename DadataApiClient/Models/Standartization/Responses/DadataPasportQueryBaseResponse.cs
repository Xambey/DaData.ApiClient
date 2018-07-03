using System.Collections.Generic;
using DadataApiClient.Models.Standartization.Results;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataPasportQueryBaseResponse : BaseResponse
    {
        public List<DadataPasportQueryResult> Value { get; set; }
    }
}