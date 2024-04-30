using BookManager.Application.InputModels;
using BookManager.Application.ViewModels;

namespace BookManager.Application.Services.Interfaces
{
    public interface ILoanService
    {
        List<LoanViewModel> GetAll();

        LoanViewModel GetById(int id);

        LoanViewModel GetByUserId(int userId);

        //void Add(LoanInputModel inputModel);

        int CreateLoanBook(CreateLoanBookInputModel inputModel);

        void SetExpectedReturnDate(int id, int loanDurationInDays);

        void UpdateLoan(int id, UpdateLoanInputModel inputModel);

        void DeleteLoan(int id);
    }
}