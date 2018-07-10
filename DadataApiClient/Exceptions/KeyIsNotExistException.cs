namespace DadataApiClient.Exceptions
{
    public class KeyIsNotExistException : BadRequestException
    {
        public KeyIsNotExistException() : base("The request contains a non-existent key")
        {
        }
    }
}