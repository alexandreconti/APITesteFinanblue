namespace ApiTeste.Models;

public class Sale
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public virtual Product? Product { get; set; }
}