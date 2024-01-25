using Library.Application.Abstractions;
using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
