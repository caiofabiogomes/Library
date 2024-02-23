using Library.Application.Queries.Book.GetAll;
using Library.Core.Entities;
using Library.Core.IRepositories;
using Moq;

namespace Library.UnitTests.Application.Queries
{
    public class GetAllBooksQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book("Nome Do Teste 1", "Autor Teste 1","9780134494272", new DateTime(2021,01,01)),
                new Book("Nome Do Teste 2", "Autor Teste 2","9780134494272", new DateTime(2022,01,01)),
                new Book("Nome Do Teste 3", "Autor Teste 3","9780134494272", new DateTime(2023,01,01)),
            };

            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(books);

            var getAllBooksQuery = new GetAllBooksQuery();
            var getAllBooksQueryHandler = new GetAllBooksQueryHandler(bookRepositoryMock.Object);

            // Act
            var viewModel = await getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken());

            // Assert
            Assert.True(viewModel.IsSuccess);
            Assert.NotNull(viewModel.Data);
            Assert.NotEmpty(viewModel.Data);
            Assert.Equal(books.Count, viewModel.Data.Count);

            bookRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }

        [Fact]
        public async Task ProjectsExistDontExist_Executed_ReturnDataEmpty()
        {
            // Arrange
            var bookRepositoryMock = new Mock<IBookRepository>();

            var getAllBooksQuery = new GetAllBooksQuery();
            var getAllBooksQueryHandler = new GetAllBooksQueryHandler(bookRepositoryMock.Object);

            // Act
            var viewModel = await getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken());

            // Assert
            Assert.True(viewModel.IsSuccess); 
            Assert.Empty(viewModel.Data); 

            bookRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
