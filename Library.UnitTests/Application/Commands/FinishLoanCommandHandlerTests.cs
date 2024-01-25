using Library.Application.Commands.Loan.FinishLoan;
using Library.Application.ViewModels;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.Core.IRepositories;
using Library.Infra.Repositories;
using Moq; 

namespace Library.UnitTests.Application.Commands
{
    public class FinishLoanCommandHandlerTests
    {
        [Fact]
        public async Task InputIsOk_Executed_ReturnSucessAndIsntLate()
        {
            //Arrange  
            var Loan = new Loan(1,1,DateTime.Now.AddDays(15));
            var loanRepository = new Mock<ILoanRepository>();

            loanRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(Loan);
            
            var finishDateLoan = DateTime.Now.AddDays(14);
            
            var finishLoanCommand = new FinishLoanCommand(1,finishDateLoan);
            var finishLoanCommandHandler = new FinishLoanCommandHandler(loanRepository.Object);

            // Act
            var result = await finishLoanCommandHandler.Handle(finishLoanCommand, new CancellationToken());
            
            // Assert
            Assert.True(result.IsSuccess);
            Assert.False(result.Data.IsLate);
            Assert.Equal(0, result.Data.DaysLate);
            Assert.Equal(ELoanStatus.Done,Loan.Status);
            Assert.Equal(finishDateLoan, Loan.FinishDateLoan);
            Assert.Equal("Empréstimo finalizado com sucesso!", result.Message);

            loanRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Loan>()), Times.Once);
        }

        [Fact]
        public async Task InputIsOk_Executed_ReturnSucessAndIsLate()
        {
            //Arrange  
            var Loan = new Loan(1, 1, DateTime.Now.AddDays(15));
            var loanRepository = new Mock<ILoanRepository>();

            loanRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(Loan);

            var finishDateLoan = DateTime.Now.AddDays(18);

            var finishLoanCommand = new FinishLoanCommand(1, finishDateLoan);
            var finishLoanCommandHandler = new FinishLoanCommandHandler(loanRepository.Object);

            // Act
            var result = await finishLoanCommandHandler.Handle(finishLoanCommand, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.True(result.Data.IsLate);
            Assert.Equal(3, result.Data.DaysLate);
            Assert.Equal(ELoanStatus.Done, Loan.Status);
            Assert.Equal(finishDateLoan, Loan.FinishDateLoan);
            Assert.Equal("Empréstimo finalizado com sucesso!", result.Message);

            loanRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Loan>()), Times.Once);
        }

        [Fact]
        public async Task InputIsOk_Executed_NotFound_ReturnNotFound()
        {
            //Arrange  
            var loanRepository = new Mock<ILoanRepository>();

            var finishDateLoan = DateTime.Now.AddDays(18);

            var finishLoanCommand = new FinishLoanCommand(1, finishDateLoan);
            var finishLoanCommandHandler = new FinishLoanCommandHandler(loanRepository.Object);

            // Act
            var result = await finishLoanCommandHandler.Handle(finishLoanCommand, new CancellationToken());

            // Assert
            Assert.False(result.IsFound);
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal("Empréstimo não encontrado!", result.Message);

            loanRepository.Verify(pr => pr.UpdateAsync(It.IsAny<Loan>()), Times.Never);
        }
    }
}
