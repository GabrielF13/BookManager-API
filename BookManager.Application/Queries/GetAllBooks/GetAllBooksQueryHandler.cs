using BookManager.Application.ViewModels;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly BookManagerDbContext _context;

        public GetAllBooksQueryHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books;

            var booksViewModels = await books
                .Select(b => new BookViewModel(b.Id, b.Title, b.Author, b.ISBN, b.YearPublished)).ToListAsync();

            return booksViewModels;
        }
    }
}