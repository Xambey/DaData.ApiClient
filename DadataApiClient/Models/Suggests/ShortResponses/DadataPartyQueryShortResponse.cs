using System.Collections.Generic;
using DadataApiClient.Models.Suggests.ShortsResults;

namespace DadataApiClient.Models.Suggests.ShortResponses
{
    public class DadataPartyQueryShortResponse
    {  
        public List<DadataPartyQueryShortResult> Suggestions { get; set; }
    }
}