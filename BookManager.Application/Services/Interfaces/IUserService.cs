using BookManager.Application.InputModels;
using BookManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        int Create(CreateUserInputModel inputModel);
    }
}
