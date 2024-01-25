using Library.Application.Abstractions;
using Library.Application.ViewModels;
using Library.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Book.GetBook
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Result<GetBookViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        
        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result<GetBookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book is null)
                return Result<GetBookViewModel>.Success(null);

            var viewModel = new GetBookViewModel(
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.PublicationDate,
                book.Loans.Select(x => new LoansViewModel(
                    x.UserId,
                    x.BookId,
                    x.StartDateLoan,
                    x.EndDateLoan,
                    x.FinishDateLoan,
                    x.Status
                    )).ToList());

            return Result<GetBookViewModel>.Success(viewModel);
        }
    }
}
