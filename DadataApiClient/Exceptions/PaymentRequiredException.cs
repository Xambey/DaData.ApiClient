namespace DadataApiClient.Exceptions
{
    public class PaymentRequiredException : BadRequestException
    {
        public PaymentRequiredException() : base("Insufficient funds to process the request, top up the balance")
        {
        }
    }
}