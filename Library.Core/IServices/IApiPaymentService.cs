using Library.Core.DTOs;

namespace Library.Core.IExternalServices
{
    public interface IApiPaymentService
    {
        void ProcessPayment(PaymentInfoDto paymentInfoDto);
    }
}
