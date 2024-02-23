namespace LibraryPayment.Core.Interfaces.Integrations
{
    public interface IPaymentStripeIntegration
    {
        Task<string> ProcessPayment(decimal value);
    }
}
