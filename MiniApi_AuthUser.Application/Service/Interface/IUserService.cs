using MiniApi_AuthUser.Domain.Model.User;
using MiniApi_AuthUser.Domain.ViewModel.Account;
using MiniApi_AuthUser.Domain.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApi_AuthUser.Application.Service.Interface
{
    public interface IUserService
    {
        Task<CreateUserResult> InsertUserAsync(CreateUserViewModel model);
        Task<List<User>> GetAllUser();
        Task<UpdateUserResult> UpdateUserAsync(UpdateUserViewModel model);
        Task<LoginResult> LoginAsync(LoginViewModel model);
    }
}
