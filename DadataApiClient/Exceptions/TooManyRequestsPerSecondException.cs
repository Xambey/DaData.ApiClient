namespace DadataApiClient.Exceptions
{
    public class TooManyRequestsPerSecondException : BadRequestException
    {
        public TooManyRequestsPerSecondException() : base("Too many requests per second")
        {
        }
    }
}