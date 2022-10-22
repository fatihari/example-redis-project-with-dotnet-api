namespace RedisExampleAPI.Models;

public class Product
{
    public string? Id { get; set; } = $"product:{Guid.NewGuid().ToString()}";
    public string? Name { get; set; }
    public decimal Price { get; set; }
}
