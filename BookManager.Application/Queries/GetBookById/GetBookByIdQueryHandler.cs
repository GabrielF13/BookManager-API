using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>
    {
        private readonly BookManagerDbContext _context;

        public GetBookByIdQueryHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<BookDetailsViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id);

            if (book == null)
                return null;

            var bookDetailsViewModel = new BookDetailsViewModel(book.Id, book.Title, book.Quantity, book.Author, book.ISBN, book.Status, book.YearPublished, book.CreatedAt);

            return bookDetailsViewModel;
        }
    }
}