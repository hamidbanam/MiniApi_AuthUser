using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApi_AuthUser.Application.Service.Interface
{
    public interface ITokenService
    {
        string GetToken();
    }
}
