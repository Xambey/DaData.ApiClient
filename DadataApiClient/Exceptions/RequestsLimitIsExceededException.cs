namespace DadataApiClient.Exceptions
{
    public class RequestsLimitIsExceededException : BadRequestException
    {
        public RequestsLimitIsExceededException() : base("Requests limit is exceeded. See the documentation and the set query limit in the client options")
        {
        }

        public RequestsLimitIsExceededException(object obj) : base(obj)
        {
        }
    }
}