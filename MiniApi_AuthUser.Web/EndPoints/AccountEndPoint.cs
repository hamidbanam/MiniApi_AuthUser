using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MiniApi_AuthUser.Application.Service.Interface;
using MiniApi_AuthUser.Application.Tools;
using MiniApi_AuthUser.Domain.ViewModel.Account;

namespace MiniApi_AuthUser.Web.EndPoints
{
    public class AccountEndPoint
    {
        #region Login
        public async static Task<IResult> Login(
            [FromServices]IUserService userService,
            [FromServices]ITokenService tokenService,
            [FromBody]LoginViewModel model)
        {
            LoginResult result=await userService.LoginAsync(model);
            switch (result)
            {
                case LoginResult.Success:
                    var token=tokenService.GetToken();
                    return Results.Ok(ApiResponse.Success("ورود با موفقیت انجام شد",token));
                default:
                case LoginResult.NotFound:
                  return Results.NotFound(ApiResponse.Failed("کاربری یافت نشد"));
            }
          
        }
        #endregion
    }
}
