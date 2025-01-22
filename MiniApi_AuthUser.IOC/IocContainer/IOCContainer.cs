using Microsoft.Extensions.DependencyInjection;
using MiniApi_AuthUser.Application.Service.Implementation;
using MiniApi_AuthUser.Application.Service.Interface;

namespace MiniApi_AuthUser.IOC.IocContainer
{
    public static class IOCContainer
    {
        public static void RegisterService(this IServiceCollection service)
        {
            service.AddScoped<IUserService,UserService>();
            service.AddScoped<ITokenService,TokenService>();
        }
    }
}
