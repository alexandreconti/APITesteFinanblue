using ApiTeste.Context;
using ApiTeste.Models;

namespace ApiTeste.Repositories;

public class ProductRepository : IRepository<Product>
{
    protected readonly SqlDbContext _context;

    public ProductRepository(SqlDbContext context)
    {
        _context = context;
    }

    public void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product entityToDelete)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
        throw new NotImplementedException();
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