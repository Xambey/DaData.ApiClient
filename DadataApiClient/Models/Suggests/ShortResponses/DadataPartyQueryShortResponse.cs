using System.Collections.Generic;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses
{
    public class DadataPartyQueryShortResponse
    {  
        public List<DadataPartyQueryShortResult> Suggestions { get; set; }
    }
}