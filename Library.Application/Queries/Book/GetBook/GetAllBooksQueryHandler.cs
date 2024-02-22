
using Library.Application.Abstractions;
using Library.Application.ViewModels;
using Library.Core.IRepositories;
using MediatR;

namespace Library.Application.Queries.Book.GetAll
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, Result<List<GetBookViewModel>>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Result<List<GetBookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();

            if (books is null)
                return Result<List<GetBookViewModel>>.Success(new List<GetBookViewModel>());

            var viewModel = books.Select(x => new GetBookViewModel(
                x.Id,
                x.Title,
                x.Author,
                x.ISBN,
                x.PublicationDate,
                x.Loans.Select(l => new LoansViewModel(
                    l.UserId,
                    l.BookId,
                    l.StartDateLoan,
                    l.EndDateLoan,
                    l.FinishDateLoan,
                    l.Status
                    )).ToList()
                )).ToList();

            return Result<List<GetBookViewModel>>.Success(viewModel);
        }
    }
}
