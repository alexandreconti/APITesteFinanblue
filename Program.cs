using Microsoft.EntityFrameworkCore;
using ApiTeste.Models;
using ApiTeste.Context;
using ApiTeste.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(CompanyRepository));
builder.Services.AddDbContext<SqlDbContext>(opt =>
    opt.UseInMemoryDatabase("ApiTeste"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
