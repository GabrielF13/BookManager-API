using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book> GetByIdAsync(int id);

        Task CreateAsync(Book book);
        
        Task SaveChangesAsync();
    }
}