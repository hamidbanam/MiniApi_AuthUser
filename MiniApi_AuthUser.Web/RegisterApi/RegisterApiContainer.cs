using MiniApi_AuthUser.Web.EndPoints;

namespace MiniApi_AuthUser.IOC.IocContainer
{
    public static class RegisterApiContainer
    {
        public static WebApplication RegisterApis(this WebApplication app)
        {
            #region User
            var userGroup = app.MapGroup("/api/users")
                .WithTags("User");

            userGroup.MapPost("/create-user", UserEndPoint.CreateUser);

            userGroup.MapGet("/",UserEndPoint.UserList);
            #endregion
            return app;
        }
    }
}
