using System.Collections.Generic;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.ShortResponses
{
    public class DadataEmailQueryShortResponse
    {
        public List<DadataEmailQueryShortResult> Suggestions { get; set; }
    }
}