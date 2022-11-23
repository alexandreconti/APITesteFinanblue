using ApiTeste.Context;
using ApiTeste.Models;
using ApiTeste.Repositories.Interfaces;

namespace ApiTeste.Repositories;

public class ProductRepository : IRepository<Product>
{
    protected readonly SqlDbContext _context;

    public ProductRepository(SqlDbContext context)
        => _context = context;

    public void Add(Product entity)
    {
        _context.Products?.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Product entityToDelete)
    {
        throw new NotImplementedException();
    }

    public List<Product>? GetAll()
    {
        return _context.Products?.Select(x => x).ToList();
    }

    public Product GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entityToUpdate, Product entity)
    {
        throw new NotImplementedException();
    }
}