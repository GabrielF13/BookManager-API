using BookManager.Core.Repositories;
using BookManager.Infrastructure.Persistence;
using MediatR;

namespace BookManager.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            book.Cancel();

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}