using Microsoft.EntityFrameworkCore;
using ApiTeste.Models;

namespace ApiTeste.Context;

public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Sale> Sales { get; set; }
}