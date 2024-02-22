using Library.Application.Abstractions;
using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Queries.Loans.GetLoansByUser
{
    public class GetLoansByUserQuery : IRequest<Result<List<GetLoansByUserViewModel>>>
    {
        public GetLoansByUserQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}
