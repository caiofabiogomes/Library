using LibraryPayment.Application.Abstractions;
using LibraryPayment.Application.InputModels;
using LibraryPayment.Application.Interfaces;
using LibraryPayment.Core.Interfaces.Integrations;

namespace LibraryPayment.Application.Services
{
    public class ProcessPaymentService : IProcessPaymentService
    {
        private readonly IPaymentStripeIntegration _paymentStripeIntegration;

        public ProcessPaymentService(IPaymentStripeIntegration paymentStripeIntegration)
        {
            _paymentStripeIntegration = paymentStripeIntegration;
        }

        public async Task<Result<string>> ProcessPaymentCreditCard(ProcessPaymentInputModel input)
        {
            var result = await _paymentStripeIntegration.ProcessPayment(input.Value);

            return Result<string>.Success(result);
        }
    }
}
