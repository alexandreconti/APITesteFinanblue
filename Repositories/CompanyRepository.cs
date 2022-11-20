using ApiTeste.Context;
using ApiTeste.Models;

namespace ApiTeste.Repositories;

public class CompanyRepository : IDisposable, IRepository<Company> 
{
    protected readonly SqlDbContext _context;
    public CompanyRepository(SqlDbContext context)
    {
        _context = context;
    }

    public void Add(Company company)
    {
        _context.Company.Add(company);
        _context.SaveChanges();
    }

    public void Delete(Company companyToDelete)
    {
        _context.Company.Remove(companyToDelete);
    }

    public void Dispose()
    {
        _context.SaveChanges();
        _context.Dispose();
    }

    public List<Company> GetAll()
    {
        return _context.Company.Select(x => x).ToList();
    }

    public Company GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Company companyToUpdate, Company company)
    {
        throw new NotImplementedException();
    }
}