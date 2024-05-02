using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;
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

            var bookDetailsViewModel = new BookDetailsViewModel(book.Id, book.Title, book.Quantity, book.Author, book.ISBN, book.Status, book.YearPublished, book.CreatedAt);

            return bookDetailsViewModel;
        }
    }
}