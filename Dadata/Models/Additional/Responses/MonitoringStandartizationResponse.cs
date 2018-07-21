using System.Net;

namespace DaData.Models.Additional.Responses
{
    public class MonitoringStandartizationResponse : BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}