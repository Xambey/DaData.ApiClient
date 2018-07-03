using System.Collections.Generic;
using DadataApiClient.Models.Standartization.ShortsResults;

namespace DadataApiClient.Models.Standartization.ShortResponses
{
    public class DadataPhoneQueryShortResponse
    {
        public List<DadataPhoneQueryShortResult> Value { get; set; }
    }
}