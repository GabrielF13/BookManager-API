using BookManager.Application.ViewModels;

namespace BookManager.Application.Services.Interfaces
{
    public interface ILoanService
    {
        List<LoanViewModel> GetAll();

        LoanViewModel GetById(int id);

        List<LoanViewModel> GetByUserId(int userId);
    }
}