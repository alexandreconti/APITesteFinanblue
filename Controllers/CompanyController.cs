using Microsoft.AspNetCore.Mvc;
using ApiTeste.Models;
using ApiTeste.Repositories.IRepository;

namespace ApiTeste.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CompanyController : ControllerBase
{
private readonly IRepository<Company> _companyRepository;

    public CompanyController(IRepository<Company> companyRepository)
    {
        _companyRepository = companyRepository;
    }

    [HttpGet(Name = "GetAllCompanies")]
    public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
    {
        var companies = _companyRepository.GetAll();

        return Ok(companies);
    }

    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<IEnumerable<Company>>> AddCompany(Company company)
    {
        //_productRepository.Add(product);
        return Ok(company);
    }
}