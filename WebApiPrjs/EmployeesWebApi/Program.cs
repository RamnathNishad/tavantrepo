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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Define security scheme for Bearer token authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer <your_token>' in the input field."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

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

//add the Global Error handle middleware
builder.Services.AddScoped<GlobalErrorHandler>();    

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

//use the global error handler middleware
app.UseMiddleware<GlobalErrorHandler>();
app.Run();
