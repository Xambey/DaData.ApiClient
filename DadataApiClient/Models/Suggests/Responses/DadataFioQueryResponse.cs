using System.Collections.Generic;
using System.Linq;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Results;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace MarkupFree.Api.Models.Api.Dadata.Suggests.Responses
{
    public class DadataFioQueryResponse
    {
        [JsonProperty("suggestions")]
        public List<DadataFioQueryResult> Suggestions { get; set; }

        public DadataFioQueryShortResponse ToShortResponse()
        {
            return new DadataFioQueryShortResponse
            {
                Suggestions = Suggestions.Select(x => new DadataFioQueryShortResult
                {
                    Name = x.Data.Name,
                    Patronymic = x.Data.Patronymic,
                    Surname = x.Data.Surname,
                    Value = x.Value,
                    UnrestrictedValue = x.UnrestrictedValue
                }).ToList()
            };
        }

    }
}