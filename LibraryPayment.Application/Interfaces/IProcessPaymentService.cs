using LibraryPayment.Application.InputModels;

namespace LibraryPayment.Application.Interfaces
{
    public interface IProcessPaymentService
    {
        Task<string> ProcessPaymentCreditCard(ProcessPaymentInputModel input);
    }
}
