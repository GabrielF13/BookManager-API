using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly BookManagerDbContext _context;

        public CreateUserCommandHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}