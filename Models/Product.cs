namespace ApiTeste.Models;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public ICollection<Sale>? sales { get; set; }
}