using Microsoft.EntityFrameworkCore;
using MiniApi_AuthUser.Application.Service.Interface;
using MiniApi_AuthUser.Data.Context;
using MiniApi_AuthUser.Domain.Model.User;
using MiniApi_AuthUser.Domain.ViewModel.User;

namespace MiniApi_AuthUser.Application.Service.Implementation
{
    public class UserService(MiniApiDbContext context) : IUserService
    {
        public async Task<List<User>> GetAllUser()
      =>await context.Users.ToListAsync();

        public async Task InsertUserAsync(CreateUserViewModel Model)
        {
            User user = new User()
            {
                Age = Model.Age,
                CreateDate = DateTime.Now,
                Email = Model.Email,
                FullName = Model.FullName,
                IsActive = true,
                Mobile = Model.Mobile,
                UserName = Model.UserName,
            };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
