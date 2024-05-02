using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;

namespace BookManager.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly BookManagerDbContext _dbContext;

        public UserService(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email, user.BirthDate, user.CreatedAt, user.Active);
        }
    }
}