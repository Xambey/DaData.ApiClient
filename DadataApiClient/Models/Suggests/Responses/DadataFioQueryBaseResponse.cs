using System.Collections.Generic;
using System.Linq;
using DadataApiClient.Models.Suggests.Results;
using DadataApiClient.Models.Suggests.ShortResponses;
using DadataApiClient.Models.Suggests.ShortsResults;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Responses
{
    public class DadataFioQueryBaseResponse : BaseResponse
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