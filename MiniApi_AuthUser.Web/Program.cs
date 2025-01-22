using Microsoft.EntityFrameworkCore;
using MiniApi_AuthUser.Data.Context;
using MiniApi_AuthUser.IOC.IocContainer;

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

#region Swagger
builder.Services.AddSwaggerGen();
#endregion
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.RegisterApis();

app.UseHttpsRedirection();



app.Run();


