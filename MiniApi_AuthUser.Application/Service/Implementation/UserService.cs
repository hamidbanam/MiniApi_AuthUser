using Microsoft.EntityFrameworkCore;
using MiniApi_AuthUser.Application.Security;
using MiniApi_AuthUser.Application.Service.Interface;
using MiniApi_AuthUser.Data.Context;
using MiniApi_AuthUser.Domain.Model.User;
using MiniApi_AuthUser.Domain.ViewModel.Account;
using MiniApi_AuthUser.Domain.ViewModel.User;

namespace MiniApi_AuthUser.Application.Service.Implementation
{
    public class UserService(MiniApiDbContext context) : IUserService
    {
        public async Task<List<User>> GetAllUser()
      => await context.Users.ToListAsync();

        public async Task<CreateUserResult> InsertUserAsync(CreateUserViewModel model)
        {
            User user = new User()
            {
                Age = model.Age,
                CreateDate = DateTime.Now,
                Email = model.Email,
                FullName = model.FullName,
                IsActive = true,
                Mobile = model.Mobile,
                UserName = model.UserName,
                Password = SecretHash.Hash(model.Password),
            };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return CreateUserResult.Success;
        }

        public async Task<LoginResult> LoginAsync(LoginViewModel model)
        {
            model.Email = model.Email.ToLower();
            User? user = await context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);
            if (user!=null)
            {
                if (!SecretHash.Verify(model.Password, user.Password))
                {
                    return LoginResult.NotFound;
                }
                return LoginResult.Success;
            }
            return LoginResult.NotFound;
        }

        public async Task<UpdateUserResult> UpdateUserAsync(UpdateUserViewModel model)
        {
            model.Email = model.Email.ToLower();
            User? user = await context.Users.SingleOrDefaultAsync(u => u.UserId == model.UserId);
            if (user == null)
            {
                return UpdateUserResult.NotFound;
            }
            if (model.Email != user.Email)
            {
                if (context.Users.Any(u => u.Email == model.Email))
                {
                    return UpdateUserResult.EmailInvalid;
                }
            }

            if (!string.IsNullOrWhiteSpace(model.UserName)) user.UserName = model.UserName;
            if (!string.IsNullOrWhiteSpace(model.FullName)) user.FullName = model.FullName;
            if (model.Age != null && model.Age != 0) user.Age = model.Age;
            if (!string.IsNullOrWhiteSpace(model.Email)) user.Email = model.Email;
            if (!string.IsNullOrWhiteSpace(model.Mobile)) user.Mobile = model.Mobile;
            if (!string.IsNullOrWhiteSpace(model.Password)) user.Password = SecretHash.Hash(model.Password);

            context.Users.Update(user);
            await context.SaveChangesAsync();
            return UpdateUserResult.Success;

        }
    }
}
