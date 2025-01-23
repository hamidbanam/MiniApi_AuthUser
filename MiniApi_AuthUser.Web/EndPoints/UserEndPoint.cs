using Microsoft.AspNetCore.Mvc;
using MiniApi_AuthUser.Application.Service.Interface;
using MiniApi_AuthUser.Application.Tools;
using MiniApi_AuthUser.Domain.ViewModel.User;

namespace MiniApi_AuthUser.Web.EndPoints
{
    public class UserEndPoint
    {
        #region User List
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async static Task<IResult> UserList([FromServices] IUserService userService)
        {
            var user = await userService.GetAllUser();
            return Results.Ok(ApiResponse.Success("اطلاعات با موفقیت بازیابی شد", user));
        }
        #endregion

        #region Create user
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async static Task<IResult> CreateUser(
          [FromServices] IUserService userService,
          [FromBody] CreateUserViewModel model)
        {
            CreateUserResult result = await userService.InsertUserAsync(model);
            switch (result)
            {
                case CreateUserResult.Success:
                    return Results.Ok(ApiResponse.Success("کاربر با موفقیت ثبت شد",result));
            }
            return Results.BadRequest(ApiResponse.Failed("خطایی رخ اده است ، دوباره امتحان کنید"));
        }
        #endregion

        #region UpdateUser
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async static Task<IResult> UpdateUser(
            [FromServices] IUserService userService,
            [FromBody] UpdateUserViewModel model)
        {
            UpdateUserResult result = await userService.UpdateUserAsync(model);
            switch (result)
            {
                case UpdateUserResult.Success:
                    return Results.Ok(ApiResponse.Success("بروزرسانی با موفقیت انجام شد", result));
                default:
                case UpdateUserResult.NotFound:
                    return Results.NotFound(ApiResponse.Failed("کاربری یافت نشد"));
                case UpdateUserResult.EmailInvalid:
                    return Results.BadRequest(ApiResponse.Failed("ایمیل تکراری است"));
            }
        }
        #endregion
    }
}
