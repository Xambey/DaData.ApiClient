using DadataApiClient.Models.Additional.Results;

namespace DadataApiClient.Models.Additional.Responses
{
    public class DadataAddressQueryBaseResponse : BaseResponse
    {
        public DadataAddressQueryResult Value { get; set; }
    }
}