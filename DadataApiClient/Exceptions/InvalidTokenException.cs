namespace DadataApiClient.Exceptions
{
    public class InvalidTokenException : BadRequestException
    {
        public InvalidTokenException() : base("Token is invalid")
        {
        }
    }
}