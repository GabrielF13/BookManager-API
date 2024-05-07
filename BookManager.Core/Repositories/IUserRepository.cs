using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int Id);
        Task CreateUserAsync(User user);
    }
}