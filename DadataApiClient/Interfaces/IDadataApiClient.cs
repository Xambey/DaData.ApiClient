using System.Collections.Generic;
using System.Threading.Tasks;
using DadataApiClient.Models.Suggestions.Responses;
using Newtonsoft.Json.Linq;

namespace DadataApiClient.Interfaces
{
    public interface IDadataApiClient : IDadataSuggestionsApiClient, IDadataStandartizationApiClient, IDadataAdditionalApiClient
    {
    }
}