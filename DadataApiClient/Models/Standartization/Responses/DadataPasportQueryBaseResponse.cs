using System.Collections.Generic;
using DadataApiClient.Models.Standartization.Data;

namespace DadataApiClient.Models.Standartization.Responses
{
    public class DadataPasportQueryBaseResponse : BaseResponse
    {
        public List<DadataPasportQueryResult> Value { get; set; }
    }
}