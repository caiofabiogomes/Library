
using Library.Application.Abstractions;
using Library.Application.ViewModels;
using Library.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.Loans.GetLoansByUser
{
    public class GetLoanByUserQueryHandler : IRequestHandler<GetLoansByUserQuery, Result<List<GetLoansByUserViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;
        public GetLoanByUserQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Result<List<GetLoansByUserViewModel>>> Handle(GetLoansByUserQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllByUserIdAsync(request.UserId);

            if(loans == null)
                return Result<List<GetLoansByUserViewModel>>.Success(new List<GetLoansByUserViewModel>());

            var viewModel = loans.Select(x => new GetLoansByUserViewModel(
                x.UserId,
                x.Status,
                x.BookId,
                x.Book.Title,
                x.Book.Author,
                x.Book.ISBN,
                x.Book.PublicationDate,
                x.StartDateLoan,
                x.EndDateLoan,
                x.FinishDateLoan
                ))
                .ToList();

            return Result<List<GetLoansByUserViewModel>>.Success(viewModel);
        }
    }
}
