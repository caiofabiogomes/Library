using LibraryPayment.Application.InputModels;
using LibraryPayment.Application.Interfaces;
using LibraryPayment.Core.Interfaces.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPayment.Application.Services
{
    public class ProcessPaymentService : IProcessPaymentService
    {
        private readonly IPaymentStripeIntegration _paymentStripeIntegration;

        public ProcessPaymentService(IPaymentStripeIntegration paymentStripeIntegration)
        {
            _paymentStripeIntegration = paymentStripeIntegration;
        }

        public async Task<string> ProcessPaymentCreditCard(ProcessPaymentInputModel input)
        {
            return await _paymentStripeIntegration.ProcessPayment(input.Value);
        }
    }
}
