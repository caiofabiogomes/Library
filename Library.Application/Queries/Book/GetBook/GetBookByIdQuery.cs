using Library.Application.Abstractions;
using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Queries.Book.GetBook
{
    public class GetBookByIdQuery : IRequest<Result<GetBookViewModel>>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
