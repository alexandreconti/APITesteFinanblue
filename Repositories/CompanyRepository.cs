using ApiTeste.Context;
using ApiTeste.Models;
using ApiTeste.Repositories.Interfaces;

namespace ApiTeste.Repositories;

public class CompanyRepository : IRepository<Company>
{
    protected readonly SqlDbContext _context;
    public CompanyRepository(SqlDbContext context) 
        => _context = context;


    public void Add(Company company)
    {
        _context.Companies?.Add(company);
        _context.SaveChanges();
    }

    public void Delete(Company companyToDelete)
    {
        _context.Companies?.Remove(companyToDelete);
    }

    public List<Company>? GetAll()
    {
        return _context.Companies?.Select(x => x).ToList();
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