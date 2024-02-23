using Library.Application.Queries.Book.GetBook;
using Library.Core.Entities;
using Library.Core.IRepositories;
using Moq;

namespace Library.UnitTests.Application.Queries
{
    public class GetBookByIdQueryHandlerTests
    {
        [Fact]
        public async Task ValidBookId_Executed_ReturnSuccess()
        {
            // Arrange
            var bookRepository = new Mock<IBookRepository>();

            var book = new Book("Livro Teste", "Autor Teste", "9780134494272", new DateTime(2022, 1, 1));
            bookRepository.Setup(pr => pr.GetByIdAsync(1)).ReturnsAsync(book);

            var query = new GetBookByIdQuery(1);
            var queryHandler = new GetBookByIdQueryHandler(bookRepository.Object);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);

            var viewModel = result.Data;
            Assert.Equal(book.Id, viewModel.Id);
            Assert.Equal(book.Title, viewModel.Title);
            Assert.Equal(book.Author, viewModel.Author);
            Assert.Equal(book.ISBN, viewModel.ISBN);
            Assert.Equal(book.PublicationDate, viewModel.PublicationDate); 
        }

        [Fact]
        public async Task InvalidBookId_Executed_ReturnSuccessWithNullData()
        {
            // Arrange
            var bookRepository = new Mock<IBookRepository>();
             

            var query = new GetBookByIdQuery(1);
            var queryHandler = new GetBookByIdQueryHandler(bookRepository.Object);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Null(result.Data);
        }
    }
}
