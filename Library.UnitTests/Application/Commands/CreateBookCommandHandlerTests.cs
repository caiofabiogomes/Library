
using Library.Application.Commands.Book.CreateBook;
using Library.Application.Commands.Loan.CreteLoan;
using Library.Core.IRepositories;
using Library.Infra.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UnitTests.Application.Commands
{
    public class CreateBookCommandHandlerTests
    {
        [Fact]
        public  async Task InputIsOk_Executed_ReturnSucess() 
        {
            //verificar se é para criar validações em caso de propriedades nulas
            //Arrange
            var bookRepository = new Mock<IBookRepository>();

            var createBookCommand = new CreateBookCommand("Livro teste", "teste", "9780134494272", new DateTime(1990, 1, 1));

            var createBookCommandHandler = new CreateBookCommandHandler(bookRepository.Object);

            //Act
            var result = await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Livro criado com sucesso!", result.Message);
        }
    }
}
