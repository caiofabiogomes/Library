using Library.Core.IntegrationEvents;
using Library.Core.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.ActionConsumers
{
    public class PaymentApprovedEventHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentApprovedEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task HandleAsync(PaymentApprovedIntegrationEvent paymentApprovedIntegrationEvent)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var loanRepository = scope.ServiceProvider.GetRequiredService<ILoanRepository>();

                var loan = await loanRepository.GetByIdAsync(paymentApprovedIntegrationEvent.LoanId);

                loan.FinishLoan(paymentApprovedIntegrationEvent.FinishDateLoan, paymentApprovedIntegrationEvent.TotalValuePaid, paymentApprovedIntegrationEvent.PaymentId);

                await loanRepository.UpdateAsync(loan);
            }
        }
    }
}
