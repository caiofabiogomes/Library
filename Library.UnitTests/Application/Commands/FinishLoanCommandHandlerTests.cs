using Library.Application.Commands.Loan.FinishLoan;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.Core.IExternalServices;
using Library.Core.IRepositories;
using Moq;

namespace Library.UnitTests.Application.Commands
{
    public class FinishLoanCommandHandlerTests
    {
        [Fact]
        public async Task InputIsOk_Executed_ReturnSucess()
        {

            var Loan = new Loan(1, 1, DateTime.Now.AddDays(15), 5, 10);
            var loanRepository = new Mock<ILoanRepository>();

            loanRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(Loan);

            var apiPaymentServiceMock = new Mock<IApiPaymentService>();
            
            var finishDateLoan = DateTime.Now.AddDays(14);
            
            var finishLoanCommand = new FinishLoanCommand(1,finishDateLoan);
            var finishLoanCommandHandler = new FinishLoanCommandHandler(loanRepository.Object, apiPaymentServiceMock.Object);


            var result = await finishLoanCommandHandler.Handle(finishLoanCommand, new CancellationToken());
            

            Assert.True(result.IsSuccess);
            Assert.Equal(ELoanStatus.PaymentPending,Loan.Status); 
            Assert.Equal("Pagamento agendado com sucesso!", result.Message);

            loanRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Loan>()), Times.Once);
        }

        [Fact]
        public async Task InputIsOk_Executed_NotFound_ReturnNotFound()
        {

            var loanRepository = new Mock<ILoanRepository>();

            var finishDateLoan = DateTime.Now.AddDays(18);

            var apiPaymentServiceMock = new Mock<IApiPaymentService>();

            var finishLoanCommand = new FinishLoanCommand(1, finishDateLoan);
            var finishLoanCommandHandler = new FinishLoanCommandHandler(loanRepository.Object, apiPaymentServiceMock.Object);


            var result = await finishLoanCommandHandler.Handle(finishLoanCommand, new CancellationToken());


            Assert.False(result.IsFound);
            Assert.False(result.IsSuccess);
            Assert.Equal("Empréstimo não encontrado!", result.Message);

            loanRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Loan>()), Times.Never);
        }
    }
}
