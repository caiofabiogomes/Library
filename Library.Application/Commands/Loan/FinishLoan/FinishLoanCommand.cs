using Library.Application.Abstractions;
using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Loan.FinishLoan
{
    public class FinishLoanCommand : IRequest<Result<FinishLoanViewModel>>
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
