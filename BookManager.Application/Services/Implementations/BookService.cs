using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;

namespace BookManager.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        public int Create(NewBookInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void CreateLoanBook(CreateLoanBookInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookDetailsViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateBookInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
