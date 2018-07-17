namespace DaData.Exceptions
{
    public class InvalidTokenException : BadRequestException
    {
        public InvalidTokenException() : base("Token is invalid")
        {
        }
    }
}