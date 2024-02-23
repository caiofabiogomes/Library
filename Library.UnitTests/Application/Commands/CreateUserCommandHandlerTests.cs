using Library.Application.Commands.User.CreateUser;
using Library.Core.Enums;
using Library.Core.IRepositories;
using Library.Infra.Auth;
using Moq;

namespace Library.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputIsOk_Executed_ReturnSuccess()
        { 
            var userRepository = new Mock<IUserRepository>();
            var authService = new Mock<IAuthService>();
            var password = "12401240";
            var hashPassword = "a18a98148d47f2ffafc99a3adac3181169cc3a89c0e75305eaec5b98896ed304";

            authService.Setup(pr => pr.ComputeSha256Hash(password)).Returns(hashPassword);

            var createUserCommand = new CreateUserCommand("Usuario teste", "teste@email.com", password, EUserRole.Client);
            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object, authService.Object);  


            var result = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());
            

            Assert.True(result.IsSuccess);
            Assert.Equal("Usuário criado com sucesso!", result.Message);

            authService.Verify(pr => pr.ComputeSha256Hash(password), Times.Once());
            authService.Verify(pr => pr.ComputeSha256Hash(password), hashPassword);
            userRepository.Verify(pr => pr.AddAsync(It.IsAny<Library.Core.Entities.User>()), Times.Once);
        }
    }
}
