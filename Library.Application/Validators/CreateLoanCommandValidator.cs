using FluentValidation;
using Library.Application.Commands.Loan.CreteLoan;

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

            RuleFor(p => p.ValuePerDay)
              .NotEmpty()
              .NotNull()
              .GreaterThan(0)
              .WithMessage("O Valor por dia do empréstimo deve ser maior que 0.");

            RuleFor(p => p.ValuePerDayLate)
              .NotEmpty()
              .NotNull()
              .GreaterThan(0)
              .WithMessage("O Valor por dia de atraso do empréstimo deve ser maior que 0.");
        }
    }
}
