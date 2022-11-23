using Microsoft.AspNetCore.Mvc;
using ApiTeste.Models;
using ApiTeste.Repositories;
using FluentValidation;
using ApiTeste.Services;
using ApiTeste.Repositories.Interfaces;
using ApiTeste.Services.Interfaces;

namespace ApiTeste.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IValidator<Sale> _validator;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public UserController(IValidator<Sale> validator, IUserRepository userRepository, ITokenService tokenService)
    {
        _validator = validator;
        _userRepository = userRepository;
		_tokenService = tokenService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
    {
        // Recupera o usuário
        var user = _userRepository.Get(model.Username, model.Password);

        // Verifica se o usuário existe
        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        // Gera o Token
        var token = _tokenService.GenerateToken(user);

        // Oculta a senha
        user.Password = "";

        // Retorna os dados
        return new
        {
            user = user,
            token = token
        };
    }
}