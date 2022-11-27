using ApiTeste.Context;
using ApiTeste.Models;
using ApiTeste.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTeste.Repositories;

public class UserRepository : IUserRepository
{
    public User Get(string username, string password)
    {
        var users = new List<User>();
        users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
        users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" });

        return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).First();
    }
}