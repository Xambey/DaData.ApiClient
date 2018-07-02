using System.Threading.Tasks;
using MarkupFree.Api.Models.Api.Dadata.Suggests.Responses;
using MarkupFree.Api.Models.Api.Dadata.Suggests.ShortResponses;

namespace DadataApiClient
{
    public interface IDadataApiClient : IDadataSuggestionsApiClient, IDadataStandartizationApiClient, IDadataAdditionalApiClient
    {
    }
}