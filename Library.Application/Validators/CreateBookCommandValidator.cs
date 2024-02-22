using FluentValidation;
using Library.Application.Commands.Book.CreateBook;

namespace Library.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(p => p.Author)
               .NotEmpty()
               .NotNull()
               .WithMessage("Nome do autor é obrigatório!");

            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Título é obrigatório!");

            RuleFor(p => p.PublicationDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data de publicação é obrigatória!");

            RuleFor(p => p.ISBN)
                .NotEmpty()
                .NotNull()
                .Must(ValidateISBN)
                .WithMessage("ISBN inválido!");

        }

        private bool ValidateISBN(string isbn)
        {
            isbn = new string(isbn.Where(c => Char.IsDigit(c)).ToArray());

            if (isbn.Length != 13)
                return false;

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = int.Parse(isbn[i].ToString());
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            int checkDigit = (10 - (sum % 10)) % 10;

            return checkDigit == int.Parse(isbn[12].ToString());
        }
    }
}
