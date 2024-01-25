using Library.Application.Abstractions;
using Library.Application.ViewModels;
using Library.Core.IRepositories;
using Library.Infra.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.Loan.FinishLoan
{
    public class FinishLoanCommandHandler : IRequestHandler<FinishLoanCommand, Result<FinishLoanViewModel>>
    {
        private readonly ILoanRepository _loanRepository;
        
        public FinishLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Result<FinishLoanViewModel>> Handle(FinishLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            if (loan is null)
                return Result<FinishLoanViewModel>.NotFound("Empréstimo não encontrado!");

            loan.FinishLoan(request.FinishDateLoan);
            await _loanRepository.UpdateAsync(loan);

            bool isLate  = loan.FinishDateLoan > loan.EndDateLoan ? true : false;
            int daysLate = 0;

            if (isLate)
                daysLate = (int)(loan.FinishDateLoan.Value - loan.EndDateLoan).TotalDays;

            var viewModel = new FinishLoanViewModel(isLate, daysLate);

            return Result<FinishLoanViewModel>.Success(viewModel,"Empréstimo finalizado com sucesso!");
        }
    }
}
