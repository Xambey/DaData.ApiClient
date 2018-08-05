using System.Threading.Tasks;
using DaData.Models.Additional.Requests;
using DaData.Models.Additional.Responses;

namespace DaData.Interfaces
{
    public interface IDaDataApiClient : IDaDataSuggestionsApiClient, IDaDataStandartizationApiClient, IDaDataAdditionalApiClient
    {
    }
}