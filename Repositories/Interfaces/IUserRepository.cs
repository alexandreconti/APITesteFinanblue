using ApiTeste.Models;

namespace ApiTeste.Repositories.Interfaces;

public interface IUserRepository
{
	User Get(string username, string password);
}