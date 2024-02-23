
using Library.Application.Commands.Book.DeleteBook;
using Library.Core.Entities;
using Library.Core.IRepositories;
using Moq;

namespace Library.UnitTests.Application.Commands
{
    public class DeleteBookCommandHandlerTests
    {
        [Fact]
        public async Task InputIsOk_Executed_ReturnSucess()
        {
            var book = new Book("Livro teste", "teste", "9780134494272", new DateTime(1990, 1, 1));
            
            var bookRepository = new Mock<IBookRepository>();
            bookRepository.Setup(pr => pr.GetByIdAsync(1).Result).Returns(book);

            var deleteBookCommand = new DeleteBookCommand(1);
            var deleteBookCommandHandler = new DeleteBookCommandHandler(bookRepository.Object);


            var result = await deleteBookCommandHandler.Handle(deleteBookCommand, new CancellationToken());


            Assert.True(result.IsSuccess);
            Assert.Equal("Livro excluído com sucesso.", result.Message);
        }

        [Fact]
        public async Task InputBookIsNotFound_Executed_ReturnNotFound()
        {

            var bookRepository = new Mock<IBookRepository>(); 

            var deleteBookCommand = new DeleteBookCommand(1);
            var deleteBookCommandHandler = new DeleteBookCommandHandler(bookRepository.Object);


            var result = await deleteBookCommandHandler.Handle(deleteBookCommand, new CancellationToken());


            Assert.False(result.IsSuccess);
            Assert.False(result.IsFound);
            Assert.Equal("Livro não encontrado.", result.Message);
        }
    }
}
