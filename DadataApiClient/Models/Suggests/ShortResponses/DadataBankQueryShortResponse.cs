using System.Collections.Generic;
using DadataApiClient.Models.Suggests.ShortsResults;

namespace DadataApiClient.Models.Suggests.ShortResponses
{
    public class DadataBankQueryShortResponse
    {
        public List<DadataBankQueryShortResult> Suggestions { get; set; }
    }
}