using Microsoft.EntityFrameworkCore;
using ApiTeste.Models;

namespace ApiTeste.Context;

public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Company { get; set; }
}