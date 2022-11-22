using Microsoft.AspNetCore.Mvc;
using ApiTeste.Models;
using ApiTeste.Repositories;
using FluentValidation;

namespace ApiTeste.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly IValidator<Product> _validator;
    private readonly IRepository<Product> _productRepository;

    public ProductController(IValidator<Product> validator, IRepository<Product> productRepository)
    {
        _validator = validator;
        _productRepository = productRepository;
    }


    [HttpGet(Name = "GetAllProducts")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = _productRepository.GetAll();

        return Ok(await Task.FromResult(products));
    }

    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<IEnumerable<Product>>> AddProduct(Product product)
    {
        var validationResult = await _validator.ValidateAsync(product);
        if(validationResult.IsValid)
        {
            _productRepository.Add(product);
            return Ok(product);
        }
        else
        {
            return BadRequest(validationResult.Errors);
        }
    }
}