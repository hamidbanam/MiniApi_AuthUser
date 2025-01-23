using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniApi_AuthUser.Data.Context;
using MiniApi_AuthUser.IOC.IocContainer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
#region Connection database
var connectionString = builder.Configuration.GetConnectionString("MiniApiConnection");
builder.Services.AddDbContext<MiniApiDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

#region Config service
builder.Services.RegisterService();

#endregion

#region Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer= "https://localhost:7013",
        ValidAudience= "https://localhost:7013",
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kwOoQl4re*EniutHkn4*B9td4ulize@tatf6v1ljkldd1715ba111bdb55282621221")),
        ValidateIssuer=true,
        ValidateAudience=false,
    };
});
builder.Services.AddAuthorization();
#endregion

#region Swagger
builder.Services.AddSwaggerGen();
#endregion
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterApis();

app.Run();


