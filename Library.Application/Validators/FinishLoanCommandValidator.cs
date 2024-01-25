using FluentValidation;
using Library.Application.Commands.Loan.FinishLoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Validators
{
    public class FinishLoanCommandValidator : AbstractValidator<FinishLoanCommand>
    {
        public FinishLoanCommandValidator()
        { 
            RuleFor(p => p.Id)
               .NotEmpty()
               .NotNull()
               .WithMessage("Id é obrigatório!");
            
            RuleFor(p => p.FinishDateLoan)
              .NotEmpty()
              .NotNull() 
              .WithMessage("Data de encerramento do empréstimo é obrigatória!");
        }


    }
}
