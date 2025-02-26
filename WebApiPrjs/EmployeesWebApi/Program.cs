using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure dependency inject for DbContext
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conStr"));
});
//configure dependencu injection for DataAccessLayer
builder.Services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>();

var secretKey = "abcdefghijklmnopqrstuvwxyz123456";
var byteKey=Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options=>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
    options=>options.TokenValidationParameters=new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer="tavant",
        ValidAudience="tavant",
        IssuerSigningKey=new SymmetricSecurityKey(byteKey)
    }
    );

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
