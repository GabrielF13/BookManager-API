using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;
using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private readonly BookManagerDbContext _context;

        public LoanService(BookManagerDbContext context)
        {
            _context = context;
        }

        public void CreateLoanBook(int idBok, CreateLoanBookInputModel inputModel)
        {
            var loan = new Loan(inputModel.IdBook, inputModel.IdUser, inputModel.LoanDurationInDays);

            var book = _context.Books.SingleOrDefault(book => book.Id == idBok);

            book.Borrowed();
            _context.Loans.Add(loan);

            //_context.SaveChanges();
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

        public LoanViewModel GetByUserId(int userId)
        {
            var loan = _context.Loans.SingleOrDefault(loan => loan.IdUser == userId);

            var loanViewModel = new LoanViewModel(loan.Id, loan.DateLoan, loan.Status, loan.IdUser, loan.IdBook, loan.LoanDurationInDays, loan.ReturnDate);

            return loanViewModel;
        }

        public void SetExpectedReturnDate(int id, int loanDurationInDays)
        {
            var loan = _context.Loans.SingleOrDefault(loan => loan.Id == id);

            loan.SetExpectedReturnDate(loanDurationInDays);
        }
    }
}