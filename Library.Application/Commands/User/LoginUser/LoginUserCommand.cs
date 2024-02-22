using Library.Application.Abstractions;
using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Commands.User.LoginUser
{
    public class LoginUserCommand : IRequest<Result<LoginUserViewModel>>
    {
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
