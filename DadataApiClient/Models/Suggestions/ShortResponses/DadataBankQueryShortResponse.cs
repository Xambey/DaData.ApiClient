using System.Collections.Generic;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.ShortResponses
{
    public class DadataBankQueryShortResponse
    {
        public List<DadataBankQueryShortResult> Suggestions { get; set; }
    }
}