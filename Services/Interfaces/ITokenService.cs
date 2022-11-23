using ApiTeste.Models;

namespace ApiTeste.Services.Interfaces;

public interface ITokenService
{
	string GenerateToken(User user);
}