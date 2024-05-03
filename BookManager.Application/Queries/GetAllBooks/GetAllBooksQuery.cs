using BookManager.Application.ViewModels;
using MediatR;

namespace BookManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
    }
}