using BookManager.Core.Repositories;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _repository;

        public UpdateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            book.Update(request.Title, request.Quantity, request.Author, request.ISBN, request.Status, request.YearPublished);

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}