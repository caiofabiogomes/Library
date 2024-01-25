using Library.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Loan.CreteLoan
{
    public class CreateLoanCommand : IRequest<Result<Unit>>
    {
        public CreateLoanCommand(int userId, int bookId, DateTime endDateLoan)
        {
            UserId = userId;
            BookId = bookId;
            EndDateLoan = endDateLoan;
        }
        public int UserId { get; private set; }

        public int BookId { get; private set; }

        public DateTime EndDateLoan { get; private set; }
    }
}
