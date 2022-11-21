namespace ApiTeste.Models;

public class Sale
{
    public int Id { get; set; }

    public int amount { get; set; }

    public Product? product { get; set; }
}