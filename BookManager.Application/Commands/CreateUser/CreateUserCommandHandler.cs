using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate);

            await _repository.CreateUserAsync(user);

            return user.Id;
        }
    }
}