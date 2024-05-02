using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly BookManagerDbContext _context;

        public CreateBookCommandHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Author, request.ISBN, request.YearPublished, request.Quantity);

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }
    }
}