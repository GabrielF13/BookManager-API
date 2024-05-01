using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;
using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly BookManagerDbContext _context;

        public LoanService(BookManagerDbContext context)
        {
            _context = context;
        }

        public int CreateLoanBook(CreateLoanBookInputModel inputModel)
        {
            var loan = new Loan(inputModel.IdUser, inputModel.IdBook, inputModel.LoanDurationInDays);

            var book = _context.Books.SingleOrDefault(book => book.Id == inputModel.IdBook);

            book.Borrowed();

            loan.SetExpectedReturnDate(inputModel.LoanDurationInDays);

            _context.Loans.Add(loan);

            _context.SaveChanges();

            return loan.Id;
        }

        public void UpdateLoan(int id, UpdateLoanInputModel inputModel)
        {
            var loan = _context.Loans.SingleOrDefault(loan => loan.Id == id);

            loan.Update(inputModel.Status, inputModel.LoanDurationInDays);

            loan.SetExpectedReturnDate(inputModel.LoanDurationInDays);

            _context.SaveChanges();
        }

        public void DeleteLoan(int id)
        {
            var loan = _context.Loans.SingleOrDefault(loan => loan.Id == id);

            _context.Loans.Remove(loan);

            _context.SaveChanges();
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

        public void SetExpectedReturnDate(int id, int loanDurationInDays)
        {
            var loan = _context.Loans.SingleOrDefault(loan => loan.Id == id);

            loan.SetExpectedReturnDate(loanDurationInDays);

            _context.SaveChanges();
        }
    }
}