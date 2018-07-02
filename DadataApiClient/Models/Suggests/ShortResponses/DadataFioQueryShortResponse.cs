using System.Collections.Generic;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses
{
    public class DadataFioQueryShortResponse
    {
        public List<DadataFioQueryShortResult> Suggestions { get; set; }
    }
}