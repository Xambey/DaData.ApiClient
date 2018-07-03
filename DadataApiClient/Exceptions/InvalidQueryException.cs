namespace DadataApiClient.Exceptions
{
    public class InvalidQueryException : BadRequestException
    {
        public InvalidQueryException() : base("Query is invalid")
        {
        }
        
        public InvalidQueryException(object obj) : base(obj)
        {
        }
    }
}