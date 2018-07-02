using System.Collections.Generic;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses
{
    public class DadataAddressQueryShortResponse
    {
        public List<DadataAddressQueryShortResult> Suggestions { get; set; }
    }
}