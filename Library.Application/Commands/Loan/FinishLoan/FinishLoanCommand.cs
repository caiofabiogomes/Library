using Library.Application.Abstractions;
using MediatR;

namespace Library.Application.Commands.Loan.FinishLoan
{
    public class FinishLoanCommand : IRequest<Result<Unit>>
    {
        public FinishLoanCommand(int id, DateTime finishDateLoan)
        {
            Id = id;
            FinishDateLoan = finishDateLoan;
        }
        public int Id { get; private set; }

        public DateTime FinishDateLoan { get; private set; }

    }
}
