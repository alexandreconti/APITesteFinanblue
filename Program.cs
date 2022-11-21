using Microsoft.EntityFrameworkCore;
using ApiTeste.Models;
using ApiTeste.Context;
using ApiTeste.Repositories;
using ApiTeste.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<Company>), typeof(CompanyRepository));
builder.Services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
builder.Services.AddScoped(typeof(IRepository<Sale>), typeof(SaleRepository));
builder.Services.AddScoped(typeof(IValidator<Company>), typeof(CompanyValidator));
builder.Services.AddScoped(typeof(IValidator<Product>), typeof(ProductValidator));
builder.Services.AddScoped(typeof(IValidator<Sale>), typeof(SaleValidator));
builder.Services.AddDbContext<SqlDbContext>(opt =>
    opt.UseInMemoryDatabase("ApiTeste"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
