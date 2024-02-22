using Library.Application.Abstractions;
using MediatR;

namespace Library.Application.Commands.Loan.CreteLoan
{
    public class CreateLoanCommand : IRequest<Result<Unit>>
    {
        public CreateLoanCommand(int userId, int bookId, DateTime endDateLoan, decimal valuePerDay, decimal valuePerDayLate)
        {
            UserId = userId;
            BookId = bookId;
            EndDateLoan = endDateLoan;
            ValuePerDay = valuePerDay;
            ValuePerDayLate = valuePerDayLate;
        }
        public int UserId { get; private set; }

        public int BookId { get; private set; }

        public DateTime EndDateLoan { get; private set; }

        public decimal ValuePerDay { get; private set; }

        public decimal ValuePerDayLate { get; private set; }

    }
}
