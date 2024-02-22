using FluentValidation;
using Library.Application.Commands.User.CreateUser;

namespace Library.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .NotNull()
               .WithMessage("Nome é obrigatório!");

            RuleFor(p => p.Email)
               .NotEmpty()
               .NotNull()
               .EmailAddress()
               .WithMessage("Email inválido!");

            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .WithMessage("A senha deve conter pelo menos 8 caracteres");
        }
    }
}
