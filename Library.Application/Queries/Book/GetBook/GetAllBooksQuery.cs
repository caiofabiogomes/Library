using Library.Application.Abstractions;
using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Queries.Book.GetAll
{
    public class GetAllBooksQuery : IRequest<Result<List<GetBookViewModel>>>
    {
    }
}
