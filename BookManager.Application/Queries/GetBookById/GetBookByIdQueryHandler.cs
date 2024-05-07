using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailsViewModel>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDetailsViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            if (book == null)
                return null;

            var bookDetailsViewModel = new BookDetailsViewModel(book.Id, book.Title, book.Quantity, book.Author, book.ISBN, book.Status, book.YearPublished, book.CreatedAt);

            return bookDetailsViewModel;
        }
    }
}