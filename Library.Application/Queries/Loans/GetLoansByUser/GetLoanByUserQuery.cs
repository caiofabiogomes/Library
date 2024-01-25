using Library.Application.Abstractions;
using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
