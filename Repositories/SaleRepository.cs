using ApiTeste.Context;
using ApiTeste.Models;

namespace ApiTeste.Repositories;

public class SaleRepository : IRepository<Sale>
{
    protected readonly SqlDbContext _context;

    public SaleRepository(SqlDbContext context)
    {
        _context = context;
    }

    public void Add(Sale entity)
    {
        _context.Sales?.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Sale entityToDelete)
    {
        throw new NotImplementedException();
    }

    public List<Sale>? GetAll()
    {
         return _context.Sales?.Select(x => x).ToList();
    }

    public Sale GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Sale entityToUpdate, Sale entity)
    {
        throw new NotImplementedException();
    }
}