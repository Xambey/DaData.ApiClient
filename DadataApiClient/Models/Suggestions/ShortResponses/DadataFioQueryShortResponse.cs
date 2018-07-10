using System.Collections.Generic;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.ShortResponses
{
    public class DadataFioQueryShortResponse
    {
        public List<DadataFioQueryShortResult> Suggestions { get; set; }
    }
}