using System.Collections.Generic;
using DadataApiClient.Models.Suggestions.ShortsResults;

namespace DadataApiClient.Models.Suggestions.ShortResponses
{
    public class DadataAddressQueryShortResponse
    {
        public List<DadataAddressQueryShortResult> Suggestions { get; set; }
    }
}