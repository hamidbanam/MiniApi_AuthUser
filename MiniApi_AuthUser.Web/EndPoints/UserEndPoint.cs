using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MiniApi_AuthUser.Application.Service.Interface;
using MiniApi_AuthUser.Application.Tools;
using MiniApi_AuthUser.Domain.Model.User;
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
            return Results.Ok(ApiResponse.Success("اطلاعات با موفقیت بازیابی شد",user));
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
            if (model == null)
                return Results.BadRequest(ApiResponse.Success("کلیه اطلاعات را وارد نمایید"));
            await userService.InsertUserAsync(model);
            return Results.Ok(ApiResponse.Success("کاربر با موفقیت ثبت شد"));
        }
        #endregion
    }
}
