using BookManager.Core.Entities;
using BookManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BookManagerDbContext _context;

        public LoanRepository(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllLoanAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _context.Loans.SingleOrDefaultAsync(loan => loan.Id == id);
        }

        public async Task<Loan> GetLoanByUserIdAsync(int id)
        {
            return await _context.Loans.SingleOrDefaultAsync(loan => loan.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CreateLoanAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLoanAsync(Loan loan)
        {
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}