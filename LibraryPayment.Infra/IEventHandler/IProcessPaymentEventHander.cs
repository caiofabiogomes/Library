namespace LibraryPayment.Infra.IServicesConsumers
{
    public interface IProcessPaymentEventHander
    {
        Task<string> ProcessPayment(decimal value);
    }
}
