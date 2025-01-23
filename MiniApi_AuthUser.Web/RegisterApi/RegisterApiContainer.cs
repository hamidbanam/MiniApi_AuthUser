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

            userGroup.MapGet("/", UserEndPoint.UserList);
            userGroup.MapPost("/create-user", UserEndPoint.CreateUser);
            userGroup.MapPut("/update-user", UserEndPoint.UpdateUser);


            #endregion

            #region Account
            var accountGroup = app.MapGroup("api/").WithTags("Account");

            accountGroup.MapPost("/login", AccountEndPoint.Login);
            #endregion
            return app;
        }
    }
}
