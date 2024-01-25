using FluentValidation;
using Library.Application.Commands.Loan.CreteLoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Validators
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidator()
        {
            RuleFor(p => p.UserId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Usuário é obrigatório!");

            RuleFor(p => p.BookId)
              .NotEmpty()
              .NotNull()
              .WithMessage("Livro é obrigatório!");

            RuleFor(p => p.EndDateLoan)
              .NotEmpty()
              .NotNull()
              .GreaterThanOrEqualTo(DateTime.Now.AddDays(1))
              .WithMessage("Data final do empréstimo é obrigatória e, deve ser pelo menos 1 dia depois do início do empréstimo!");
        }
    }
}
