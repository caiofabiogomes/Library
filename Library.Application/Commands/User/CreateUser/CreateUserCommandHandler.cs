using Library.Application.Abstractions;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.Core.IRepositories;
using Library.Infra.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IUserRepository userRepository,IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<Result<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new Library.Core.Entities.User(request.Name, request.Email,passwordHash, request.Role);

            await _userRepository.AddAsync(user);
            
            return Result<Unit>.Success(Unit.Value,"Usuário criado com sucesso!");
        }
    }
}
