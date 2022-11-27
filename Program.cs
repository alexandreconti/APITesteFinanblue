using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiTeste.Models;
using ApiTeste.Context;
using ApiTeste.Repositories;
using ApiTeste.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiTeste.Services;
using ApiTeste.Repositories.Interfaces;
using ApiTeste.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region services
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<Company>), typeof(CompanyRepository));
builder.Services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
builder.Services.AddScoped(typeof(IRepository<Sale>), typeof(SaleRepository));
builder.Services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddTransient(typeof(ITokenService), typeof(TokenService));
builder.Services.AddScoped(typeof(IValidator<Company>), typeof(CompanyValidator));
builder.Services.AddScoped(typeof(IValidator<Product>), typeof(ProductValidator));
builder.Services.AddScoped(typeof(IValidator<Sale>), typeof(SaleValidator));
builder.Services.AddDbContext<SqlDbContext>(opt =>
    opt.UseInMemoryDatabase("ApiTeste"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e")
            ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
