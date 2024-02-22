using Library.Application.Commands.Loan.CreteLoan;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.Core.IRepositories;
using Moq;

namespace Library.UnitTests.Application.Commands
{
    public class CreateLoanCommandHandlerTests
    {
        
        [Fact]
        public async Task InputIsOk_Executed_ReturnSucess() 
        {
            //Arrange
            var loanRepository = new Mock<ILoanRepository>();
            var userRepository = new Mock<IUserRepository>();
            var bookRepository = new Mock<IBookRepository>();

            var book = new Book("Livro teste", "teste", "9780134494272", new DateTime(1990, 1, 1));
            var user = new User("Usuário teste","teste@gmail.com","12345678",EUserRole.Client);

            bookRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(book);
            userRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(user);

            var createLoanCommand = new CreateLoanCommand(1,1,DateTime.Now.AddDays(15),5,10);

            var createLoanCommandHandler = new CreateLoanCommandHandler(loanRepository.Object,userRepository.Object,bookRepository.Object);

            // Act
            var result = await createLoanCommandHandler.Handle(createLoanCommand, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Empréstimo criado com sucesso!", result.Message);

            loanRepository.Verify(pr => pr.AddAsync(It.IsAny<Loan>()), Times.Once);
        }

        [Fact]
        public async Task InputUserIsNotFound_Executed_ReturnNotFound()
        {
            //Arrange
            var loanRepository = new Mock<ILoanRepository>();
            var userRepository = new Mock<IUserRepository>();
            var bookRepository = new Mock<IBookRepository>();

            var book = new Book("Livro teste", "teste", "9780134494272", new DateTime(1990, 1, 1)); 

            bookRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(book); 

            var createLoanCommand = new CreateLoanCommand(1, 1, DateTime.Now.AddDays(15), 5, 10);

            var createLoanCommandHandler = new CreateLoanCommandHandler(loanRepository.Object, userRepository.Object, bookRepository.Object);

            // Act
            var result = await createLoanCommandHandler.Handle(createLoanCommand, new CancellationToken());

            // Assert
            Assert.False(result.IsFound);
            Assert.False(result.IsSuccess);
            Assert.Equal("cliente não encontrado ou foi removido",result.Message);

            loanRepository.Verify(pr => pr.AddAsync(It.IsAny<Loan>()), Times.Never);
        }

        [Fact]
        public async Task InputBookIsNotFound_Executed_ReturnNotFound()
        {
            //Arrange
            var loanRepository = new Mock<ILoanRepository>();
            var userRepository = new Mock<IUserRepository>();
            var bookRepository = new Mock<IBookRepository>();
             
            var user = new User("Usuário teste", "teste@gmail.com", "12345678", EUserRole.Client);
             
            userRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(user);

            var createLoanCommand = new CreateLoanCommand(1, 1, DateTime.Now.AddDays(15), 5, 10);

            var createLoanCommandHandler = new CreateLoanCommandHandler(loanRepository.Object, userRepository.Object, bookRepository.Object);

            // Act
            var result = await createLoanCommandHandler.Handle(createLoanCommand, new CancellationToken());

            // Assert
            Assert.False(result.IsFound);
            Assert.False(result.IsSuccess);
            Assert.Equal("livro não encontrado ou foi removido", result.Message);

            loanRepository.Verify(pr => pr.AddAsync(It.IsAny<Loan>()), Times.Never);
        }

    }
}
