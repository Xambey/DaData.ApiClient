using System.Collections.Generic;
using DadataApiClient.Models.Suggests.ShortsResults;

namespace DadataApiClient.Models.Suggests.ShortResponses
{
    public class DadataEmailQueryShortResponse
    {
        public List<DadataEmailQueryShortResult> Suggestions { get; set; }
    }
}