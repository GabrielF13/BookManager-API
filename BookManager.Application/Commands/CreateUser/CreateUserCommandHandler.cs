using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using BookManager.Core.Services;
using MediatR;

namespace BookManager.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);



            await _repository.CreateUserAsync(user);

            return user.Id;
        }
    }
}