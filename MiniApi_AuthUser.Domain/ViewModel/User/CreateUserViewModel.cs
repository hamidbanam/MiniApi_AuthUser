using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApi_AuthUser.Domain.ViewModel.User
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }

    public enum CreateUserResult
    {
        Success,
    }
}
