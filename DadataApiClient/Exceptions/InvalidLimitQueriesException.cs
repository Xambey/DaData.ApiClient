namespace DadataApiClient.Exceptions
{
    public class InvalidLimitQueriesException : BadRequestException
    {
        public InvalidLimitQueriesException() : base("Limit queries is invalid")
        {
        }

        public InvalidLimitQueriesException(object obj) : base(obj)
        {
        }
    }
}