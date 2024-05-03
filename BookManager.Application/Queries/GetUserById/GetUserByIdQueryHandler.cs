using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly BookManagerDbContext _context;

        public GetUserByIdQueryHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel(user.FullName, user.Email, user.BirthDate, user.CreatedAt, user.Active);

            return userViewModel;
        }
    }
}