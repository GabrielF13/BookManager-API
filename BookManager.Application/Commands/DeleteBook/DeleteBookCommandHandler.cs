using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly BookManagerDbContext _context;

        public DeleteBookCommandHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}