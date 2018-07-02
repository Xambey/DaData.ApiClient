using System.Threading.Tasks;

namespace DadataApiClient
{
    public interface IDadataApiClient : IDadataSuggestionsApiClient, IDadataStandartizationApiClient, IDadataAdditionalApiClient
    {
    }
}