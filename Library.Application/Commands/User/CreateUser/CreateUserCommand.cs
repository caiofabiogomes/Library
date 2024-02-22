using Library.Application.Abstractions;
using Library.Core.Enums;
using MediatR;

namespace Library.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<Result<Unit>>
    {
        public CreateUserCommand(string name, string email, string password, EUserRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public EUserRole Role { get; private set; }

    }
}
