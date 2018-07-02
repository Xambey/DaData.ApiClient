using System.Collections.Generic;
using DadataApiClient.Models.Suggests.ShortsResults;

namespace DadataApiClient.Models.Suggests.ShortResponses
{
    public class DadataFioQueryShortResponse
    {
        public List<DadataFioQueryShortResult> Suggestions { get; set; }
    }
}