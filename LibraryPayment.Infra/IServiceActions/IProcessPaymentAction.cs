namespace LibraryPayment.Infra.IServicesConsumers
{
    public interface IProcessPaymentAction
    {
        Task<string> ProcessPayment(decimal value);
    }
}
