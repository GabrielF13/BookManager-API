using BookManager.Application.InputModels;
using BookManager.Application.ViewModels;
using BookManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll();

        BookDetailsViewModel GetById(int id);

        int Create(NewBookInputModel inputModel);

        void Update(UpdateBookInputModel inputModel);

        void Delete(int id);

        void CreateLoanBook(CreateLoanBookInputModel inputModel);
    }
}
