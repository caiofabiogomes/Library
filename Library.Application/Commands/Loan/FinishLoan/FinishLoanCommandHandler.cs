using Library.Application.Abstractions;
using Library.Core.DTOs;
using Library.Core.Enums;
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

            if(loan.Status == ELoanStatus.Payed)
                return Result<Unit>.Failure("O empréstimo já foi pago!");

            var valueToPay = loan.ValueToPayToFinishLoan(request.FinishDateLoan);

            if(valueToPay <= 0)
                return Result<Unit>.Failure("O valor a ser pago deve ser maior que 0!");

            var paymentInfoDto = new PaymentInfoDto(loan.Id, valueToPay, request.FinishDateLoan);

            _apiPaymentService.ProcessPayment(paymentInfoDto);

            loan.PaymentPending();

            await _loanRepository.UpdateAsync(loan);

            return Result<Unit>.Success(Unit.Value, "Pagamento agendado com sucesso!");
        }
    }
}
