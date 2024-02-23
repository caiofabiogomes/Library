using Library.Core.IRepositories;
using Library.Infra.IServiceActions;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.ActionConsumers
{
    public class PaymentApprovedAction : IPaymentApprovedAction
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentApprovedAction(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task FinishLoan(int loanId, DateTime finishDateLoan, decimal totalPaid, string paymentId)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var loanRepository = scope.ServiceProvider.GetRequiredService<ILoanRepository>();

                var loan = await loanRepository.GetByIdAsync(loanId);

                loan.FinishLoan(finishDateLoan, totalPaid, paymentId);

                await loanRepository.UpdateAsync(loan);
            }
        }
    }
}
