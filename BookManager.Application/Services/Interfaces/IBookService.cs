using BookManager.Application.ViewModels;

namespace BookManager.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll();

        BookDetailsViewModel GetById(int id);
    }
}