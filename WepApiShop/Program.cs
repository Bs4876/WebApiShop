using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddScoped<IUsersServices, UsersServices>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
