using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;

namespace BookManager.Application.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly BookManagerDbContext _context;

        public LoanService(BookManagerDbContext context)
        {
            _context = context;
        }

        public List<LoanViewModel> GetAll()
        {
            var loans = _context.Loans;

            var loansViewModels = loans.Select(loan => new LoanViewModel(loan.Id, loan.DateLoan, loan.Status, loan.IdUser, loan.IdBook, loan.LoanDurationInDays, loan.ReturnDate)).ToList();

            return loansViewModels;
        }

        public LoanViewModel GetById(int id)
        {
            var loan = _context.Loans.SingleOrDefault(loan => loan.Id == id);

            var loanViewModel = new LoanViewModel(loan.Id, loan.DateLoan, loan.Status, loan.IdUser, loan.IdBook, loan.LoanDurationInDays, loan.ReturnDate);

            return loanViewModel;
        }

        public List<LoanViewModel> GetByUserId(int userId)
        {
            var loans = _context.Loans.Where(loan => loan.IdUser == userId).ToList();

            var LoanViewModel = loans.Select(loan => new LoanViewModel(loan.Id, loan.DateLoan, loan.Status, loan.IdUser, loan.IdBook, loan.LoanDurationInDays, loan.ReturnDate)).ToList();

            return LoanViewModel;
        }
    }
}