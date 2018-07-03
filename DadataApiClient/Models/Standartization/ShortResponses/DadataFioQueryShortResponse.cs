using System.Collections.Generic;
using DadataApiClient.Models.Standartization.ShortsResults;

namespace DadataApiClient.Models.Standartization.ShortResponses
{
    public class DadataFioQueryShortResponse
    {
        public List<DadataFioQueryShortResult> Value { get; set; }
    }
}