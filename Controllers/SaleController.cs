using Microsoft.AspNetCore.Mvc;
using ApiTeste.Models;
using ApiTeste.Repositories;
using FluentValidation;

namespace ApiTeste.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SaleController : ControllerBase
{
    private readonly IValidator<Sale> _validator;
    private readonly IRepository<Sale> _saleRepository;

    public SaleController(IValidator<Sale> validator, IRepository<Sale> saleRepository)
    {
        _validator = validator;
        _saleRepository = saleRepository;
    }

        [HttpGet(Name = "GetAllSales")]
    public async Task<ActionResult<IEnumerable<Sale>>> GetAllSales()
    {
        var sales = _saleRepository.GetAll();

        return Ok(await Task.FromResult(sales));
    }

    [HttpPost(Name = "CreateSale")]
    public async Task<ActionResult<IEnumerable<Sale>>> AddSale(Sale sale)
    {
        var validationResult = await _validator.ValidateAsync(sale);
        if(validationResult.IsValid)
        {
            _saleRepository.Add(sale);
            return Ok(sale);
        }
        else
        {
            return BadRequest(validationResult.Errors);
        }
    }
}