using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly BookManagerDbContext _context;

        public UpdateBookCommandHandler(BookManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == request.Id);

            book.Update(request.Title, request.Quantity, request.Author, request.ISBN, request.Status, request.YearPublished);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}