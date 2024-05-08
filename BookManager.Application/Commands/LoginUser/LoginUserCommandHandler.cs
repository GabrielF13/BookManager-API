using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using BookManager.Core.Services;
using MediatR;

namespace BookManager.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return loginUserViewModel;
        }
    }
}