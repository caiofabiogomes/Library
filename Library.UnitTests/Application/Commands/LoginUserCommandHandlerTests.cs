using Library.Application.Commands.User.LoginUser;
using Library.Core.Enums;
using Library.Core.IRepositories;
using Library.Infra.Auth;
using Moq;

namespace Library.UnitTests.Application.Commands
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task ValidLoginCredentials_Executed_ReturnSuccess()
        {

            var authService = new Mock<IAuthService>();
            var userRepository = new Mock<IUserRepository>();
            var password = "12401240";
            var hashPassword = "a18a98148d47f2ffafc99a3adac3181169cc3a89c0e75305eaec5b98896ed304";
             
            var user = new Library.Core.Entities.User("usuário teste", "teste@email.com", hashPassword, EUserRole.Client);

            userRepository.Setup(pr => pr.GetByEmailAndPasswordAsync("teste@email.com", hashPassword))
                .ReturnsAsync(user);

            authService.Setup(pr => pr.ComputeSha256Hash(password)).Returns(hashPassword);
            authService.Setup(pr => pr.GenerateJwtToken(user.Id, user.Role)).Returns("fakeJwtToken");

            var loginCommand = new LoginUserCommand("teste@email.com", password);
            var loginCommandHandler = new LoginUserCommandHandler(authService.Object, userRepository.Object);


            var result = await loginCommandHandler.Handle(loginCommand, new CancellationToken());


            Assert.True(result.IsSuccess);
            Assert.Equal("Login realizado com sucesso!", result.Message);
            Assert.Equal("teste@email.com", result.Data.Email);
            Assert.Equal("fakeJwtToken", result.Data.Token);

            userRepository.Verify(pr => pr.GetByEmailAndPasswordAsync("teste@email.com", hashPassword), Times.Once);
            authService.Verify(pr => pr.GenerateJwtToken(user.Id, user.Role), Times.Once);
        }

        [Fact]
        public async Task InvalidLoginCredentials_Executed_ReturnNotFound()
        {

            var authService = new Mock<IAuthService>();
            var userRepository = new Mock<IUserRepository>();

            var password = "12401240";
            var hashPassword = "a18a98148d47f2ffafc99a3adac3181169cc3a89c0e75305eaec5b98896ed304";

            authService.Setup(pr => pr.ComputeSha256Hash(password)).Returns(hashPassword); 

            var loginCommand = new LoginUserCommand("teste@email.com", password);
            var loginCommandHandler = new LoginUserCommandHandler(authService.Object, userRepository.Object);


            var result = await loginCommandHandler.Handle(loginCommand, CancellationToken.None);


            Assert.False(result.IsSuccess);
            Assert.False(result.IsFound);
            Assert.Equal("Usuário não encontrado!", result.Message);
            Assert.Null(result.Data);

            userRepository.Verify(pr => pr.GetByEmailAndPasswordAsync("teste@email.com", hashPassword), Times.Once);
            authService.Verify(pr => pr.GenerateJwtToken(It.IsAny<int>(), It.IsAny<EUserRole>()), Times.Never);
        }
    }
}
