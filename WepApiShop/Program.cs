using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddScoped<IUsersServices, UsersServices>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddDbContext<ShopContext>(option=>option.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=330745571_MyDB;Integrated Security=True;Encrypt=False"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
