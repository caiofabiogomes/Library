using Library.Application.Abstractions;
using Library.Application.ViewModels;
using Library.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Result<Unit>>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            
            if (book == null)
                return Result<Unit>.NotFound("Livro não encontrado."); 

            await _bookRepository.DeleteAsync(book);

            return Result<Unit>.Success(Unit.Value, "Livro excluído com sucesso.");
        }
    }
}
