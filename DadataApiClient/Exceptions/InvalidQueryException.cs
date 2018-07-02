namespace DadataApiClient.Exceptions
{
    public class InvalidQueryException : BadRequestException
    {
        public InvalidQueryException(object obj) : base(obj)
        {
        }
    }
}