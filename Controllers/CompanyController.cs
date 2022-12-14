using Microsoft.AspNetCore.Mvc;
using ApiTeste.Models;
using ApiTeste.Repositories;
using FluentValidation;
using ApiTeste.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ApiTeste.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CompanyController : ControllerBase
{
private readonly IValidator<Company> _validator;
private readonly IRepository<Company> _companyRepository;

    public CompanyController(IValidator<Company> validator, IRepository<Company> companyRepository)
    {
        _validator = validator;
        _companyRepository = companyRepository;
    }

    [HttpGet(Name = "GetAllCompanies")]
    [Authorize(Roles = "manager")]
    // salvar
    public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
    {
        var companies = _companyRepository.GetAll();

        return Ok(await Task.FromResult(companies));
    }

    [HttpPost(Name = "CreateCompanies")]
    public async Task<ActionResult<IEnumerable<Company>>> AddCompany(Company company)
    {
        var validationResult = await _validator.ValidateAsync(company);
        if(validationResult.IsValid)
        {
            _companyRepository.Add(company);
            return Ok(company);
        }
        else
        {
            return BadRequest(validationResult.Errors);
        }
    }
}