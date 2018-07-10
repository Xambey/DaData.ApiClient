using System.Collections.Generic;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.ShortResponses
{
    public class DadataPartyQueryShortResponse
    {  
        public List<DadataPartyQueryShortResult> Suggestions { get; set; }
    }
}