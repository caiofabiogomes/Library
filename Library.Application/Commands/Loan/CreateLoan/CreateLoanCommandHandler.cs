using Library.Application.Abstractions;
using Library.Core.IRepositories;
using MediatR;

namespace Library.Application.Commands.Loan.CreteLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Result<Unit>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Result<Unit>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
                return Result<Unit>.NotFound("cliente não encontrado ou foi removido");

            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book == null)
                return Result<Unit>.NotFound("livro não encontrado ou foi removido");

            var loan = new Core.Entities.Loan(request.UserId, request.BookId, request.EndDateLoan, request.ValuePerDay, request.ValuePerDayLate);

            await _loanRepository.AddAsync(loan);

            return Result<Unit>.Success(Unit.Value, "Empréstimo criado com sucesso!");
        }
    }
}
