using MiniApi_AuthUser.Domain.Model.User;
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
        Task InsertUserAsync(CreateUserViewModel Model);
        Task<List<User>> GetAllUser();
    }
}
