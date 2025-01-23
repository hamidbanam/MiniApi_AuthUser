using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApi_AuthUser.Domain.ViewModel.Account
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public enum LoginResult
    {
        Success,
        NotFound,
    }
}
