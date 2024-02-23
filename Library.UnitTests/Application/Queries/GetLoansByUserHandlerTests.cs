using Library.Application.Queries.Loans.GetLoansByUser;
using Library.Core.Entities;
using Library.Core.IRepositories;
using Moq;

namespace Library.UnitTests.Application.Queries
{
    public class GetLoansByUserHandlerTests
    {
        [Fact]
        public async Task ValidUserId_Executed_ReturnSuccess()
        {
            // Arrange
            var loanRepository = new Mock<ILoanRepository>();

            var book = new Book("Livro teste", "teste", "9780134494272", new DateTime(1990, 1, 1));

            var loans = new List<Loan>
            {
                new Loan(1, DateTime.Now.AddDays(15),book),
                new Loan(1, DateTime.Now.AddDays(15),book)
            };


            loanRepository.Setup(pr => pr.GetAllByUserIdAsync(1))
                .ReturnsAsync(loans);

            var query = new GetLoansByUserQuery(1);
            var queryHandler = new GetLoanByUserQueryHandler(loanRepository.Object);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert 
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.Equal(loans.Count, result.Data.Count);

            loanRepository.Verify(pr => pr.GetAllByUserIdAsync(1).Result, Times.Once);
        }

        [Fact]
        public async Task InvalidUserId_Executed_ReturnSuccessWithEmptyData()
        {
            // Arrange
            var loanRepository = new Mock<ILoanRepository>();

            var query = new GetLoansByUserQuery(1);
            var queryHandler = new GetLoanByUserQueryHandler(loanRepository.Object);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert 
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Empty(result.Data); 

            loanRepository.Verify(pr => pr.GetAllByUserIdAsync(1).Result, Times.Once);
        }
    }
}
