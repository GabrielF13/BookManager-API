using BookManager.Core.Entities;

namespace BookManager.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllLoanAsync();

        Task<Loan> GetLoanByIdAsync(int id);

        Task<Loan> GetLoanByUserIdAsync(int id);

        Task CreateLoanAsync(Loan loan);

        Task SaveChangesAsync();

        Task DeleteLoanAsync(Loan loan);
    }
}