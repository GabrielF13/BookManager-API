using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookManagerDbContext _context;

        public UserRepository(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
    }
}