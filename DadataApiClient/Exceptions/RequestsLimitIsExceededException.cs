namespace DadataApiClient.Exceptions
{
    public class RequestsLimitIsExceededException : BadRequestException
    {
        public RequestsLimitIsExceededException() : base("Requests limit is exceeded. See the documentation. (Also you can increase the limit in the options of the client at your own risk)")
        {
        }

        public RequestsLimitIsExceededException(object obj) : base(obj)
        {
        }
    }
}