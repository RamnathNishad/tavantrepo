using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddXmlSerializerFormatters(); 

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

var secretKey = builder.Configuration["jwt:secretKey"];
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

        ValidIssuer= builder.Configuration["jwt:issuer"],
        ValidAudience= builder.Configuration["jwt:audience"],
        IssuerSigningKey=new SymmetricSecurityKey(byteKey),
        
    }
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Admin");
    });
});

//add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("clients-allowed", policy =>
    {
        policy.WithOrigins("http://localhost:5136")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

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

app.UseCors("clients-allowed");

app.Run();
