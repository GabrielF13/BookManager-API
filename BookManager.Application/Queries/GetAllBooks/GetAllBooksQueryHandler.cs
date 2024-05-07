using BookManager.Application.ViewModels;
using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly IBookRepository _repository;

        public GetAllBooksQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAll();

            var booksViewModels = books
                .Select(b => new BookViewModel(b.Id, b.Title, b.Author, b.ISBN, b.YearPublished)).ToList();

            return booksViewModels;
        }
    }
}