using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;
using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;

namespace BookManager.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly BookManagerDbContext _context;

        public BookService(BookManagerDbContext context)
        {
            _context = context;
        }

        public int Create(NewBookInputModel inputModel)
        {
            var book = new Book(inputModel.Title, inputModel.IdLoan, inputModel.Author, inputModel.ISBN, inputModel.YearPublished);

            _context.Books.Add(book);
            //_context.SaveChanges();

            return book.Id;
        }

        public void CreateLoanBook(int idBok, CreateLoanBookInputModel inputModel)
        {
            var loan = new Loan(inputModel.IdBook, inputModel.IdUser, inputModel.LoanDurationInDays);

            var book = _context.Books.SingleOrDefault(book => book.Id == idBok);

            book.Borrowed();
            _context.Loans.Add(loan);

            //_context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            _context.Books.Remove(book);

            //_context.SaveChanges();
        }

        public void Unavailable(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            book.Cancel();
        }

        public List<BookViewModel> GetAll()
        {
            var books = _context.Books;

            var booksViewModels = books
                .Select(b => new BookViewModel(b.Id, b.Title, b.Author, b.ISBN, b.YearPublished)).ToList();

            return booksViewModels;
        }

        public BookDetailsViewModel GetById(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return null;

            var bookDetailsViewModel = new BookDetailsViewModel(book.Id, book.Title, book.IdLoan, book.Quantity, book.Author, book.ISBN, book.Status, book.YearPublished, book.CreatedAt);

            return bookDetailsViewModel;
        }

        public void Update(UpdateBookInputModel inputModel)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == inputModel.Id);

            book.Update(inputModel.Title, inputModel.Quantity, inputModel.Author, inputModel.ISBN, inputModel.Status, inputModel.YearPublished);

            //_context.SaveChanges();
        }

        public void BookReturned(int idBook, int user)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == idBook);
            //TODO search user for update to status

            book.Borrowed();

        }
    }
}