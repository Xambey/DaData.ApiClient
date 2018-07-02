using System.Collections.Generic;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses
{
    public class DadataBankQueryShortResponse
    {
        public List<DadataBankQueryShortResult> Suggestions { get; set; }
    }
}