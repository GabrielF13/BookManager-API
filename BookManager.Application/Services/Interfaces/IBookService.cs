using BookManager.Application.InputModels;
using BookManager.Application.ViewModels;

namespace BookManager.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll();

        BookDetailsViewModel GetById(int id);

        int Create(CreateBookInputModel inputModel);

        void Update(int id, UpdateBookInputModel inputModel);

        void Delete(int id);

        void Unavailable(int id);

        void CreateLoanBook(int idBook, CreateLoanBookInputModel inputModel);

        void BookReturned(int idBook, int user);
    }
}