using System.Collections.Generic;
using DadataApiClient.Models.Suggests.ShortsResults;

namespace DadataApiClient.Models.Suggests.ShortResponses
{
    public class DadataAddressQueryShortResponse
    {
        public List<DadataAddressQueryShortResult> Suggestions { get; set; }
    }
}