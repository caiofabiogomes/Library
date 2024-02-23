
using Library.Application.Abstractions;
using Library.Application.ViewModels;
using Library.Core.IRepositories;
using MediatR;

namespace Library.Application.Queries.Loans.GetLoansByUser
{
    public class GetLoanByUserQueryHandler : IRequestHandler<GetLoansByUserQuery, Result<List<GetLoansViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;
        public GetLoanByUserQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Result<List<GetLoansViewModel>>> Handle(GetLoansByUserQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllByUserIdAsync(request.UserId);

            if (loans == null)
                return Result<List<GetLoansViewModel>>.Success(new List<GetLoansViewModel>());

            var viewModel = loans.Select(x => new GetLoansViewModel(
                x.Id,
                x.UserId,
                x.Status,
                x.BookId,
                x.Book.Title,
                x.Book.Author,
                x.Book.ISBN,
                x.ValuePerDay,
                x.ValuePerDayLate,
                x.Book.PublicationDate,
                x.StartDateLoan,
                x.EndDateLoan,
                x.FinishDateLoan,
                x.TotalValuePaid,
                x.PaymentId
                ))
                .ToList();

            return Result<List<GetLoansViewModel>>.Success(viewModel);
        }
    }
}
