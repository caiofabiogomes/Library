using Library.Application.Abstractions;
using Library.Application.ViewModels;
using Library.Core.IRepositories;
using Library.Infra.Auth;
using MediatR;

namespace Library.Application.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginUserViewModel>>
    {
        private IAuthService _authService;
        private IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<Result<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return Result<LoginUserViewModel>.NotFound("Usuário não encontrado!");


            var token = _authService.GenerateJwtToken(user.Id, user.Role);

            var viewModel = new LoginUserViewModel(user.Email, token);

            return Result<LoginUserViewModel>.Success(viewModel, "Login realizado com sucesso!");
        }
    }
}
