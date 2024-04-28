using BookManager.Application.InputModels;
using BookManager.Application.Services.Interfaces;
using BookManager.Application.ViewModels;
using BookManager.Core.Entities;
using BookManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        readonly private BookManagerDbContext _dbContext;
        public UserService(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);
            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email,user.BirthDate, user.CreatedAt, user.Active);
        }
    }
}
