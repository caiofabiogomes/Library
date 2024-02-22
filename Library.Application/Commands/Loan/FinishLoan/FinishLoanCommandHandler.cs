using Library.Application.Abstractions;
using Library.Core.DTOs;
using Library.Core.IExternalServices;
using Library.Core.IRepositories;
using MediatR;

namespace Library.Application.Commands.Loan.FinishLoan
{
    public class FinishLoanCommandHandler : IRequestHandler<FinishLoanCommand, Result<Unit>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IApiPaymentService _apiPaymentService;

        public FinishLoanCommandHandler(ILoanRepository loanRepository, IApiPaymentService apiPaymentService)
        {
            _loanRepository = loanRepository;
            _apiPaymentService = apiPaymentService;
        }

        public async Task<Result<Unit>> Handle(FinishLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            if (loan is null)
                return Result<Unit>.NotFound("Empréstimo não encontrado!");

            var valueToPay = loan.ValueToPayToFinishLoanNow();

            var paymentInfoDto = new PaymentInfoDto(loan.Id, valueToPay, request.FinishDateLoan);

            _apiPaymentService.ProcessPayment(paymentInfoDto);

            loan.PaymentPending();

            await _loanRepository.UpdateAsync(loan);

            return Result<Unit>.Success(Unit.Value, "Pagamento agendado com sucesso!");
        }
    }
}
