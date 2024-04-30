using BookManager.Application.InputModels;
using BookManager.Application.ViewModels;

namespace BookManager.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);

        int Create(CreateUserInputModel inputModel);
    }
}