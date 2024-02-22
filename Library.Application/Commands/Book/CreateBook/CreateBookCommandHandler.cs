using Library.Application.Abstractions;
using Library.Core.IRepositories;
using MediatR;

namespace Library.Application.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<Unit>>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Result<Unit>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Library.Core.Entities.Book(request.Title, request.Author, request.ISBN, request.PublicationDate);

            await _bookRepository.AddAsync(book);

            return Result<Unit>.Success(Unit.Value, "Livro criado com sucesso!");
        }
    }
}
