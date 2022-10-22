using RedisExampleAPI.Models;

namespace RedisExampleAPI.Repositories;

public interface IProductRepository
{
    List<Product?>? GetAllAsync();
    Product? GetByIdAsync(string id);
    void CreateAsync(Product product);
}
