namespace DaData.Exceptions
{
    public class MethodNotAllowedException : BadRequestException
    {
        public MethodNotAllowedException() : base("The request was made with a method other than POST")
        {
        }
    }
}