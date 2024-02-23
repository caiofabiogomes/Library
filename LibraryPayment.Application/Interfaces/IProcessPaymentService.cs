using LibraryPayment.Application.Abstractions;
using LibraryPayment.Application.InputModels;

namespace LibraryPayment.Application.Interfaces
{
    public interface IProcessPaymentService
    {
        Task<Result<string>> ProcessPaymentCreditCard(ProcessPaymentInputModel input);
    }
}
