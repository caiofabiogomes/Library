using Library.Application.Abstractions;
using MediatR;

namespace Library.Application.Commands.Book.DeleteBook
{
    public class DeleteBookCommand : IRequest<Result<Unit>>
    {
        public DeleteBookCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

    }
}
