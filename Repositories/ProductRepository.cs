using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RedisExampleAPI.Models;
using StackExchange.Redis;

namespace RedisExampleAPI.Repositories;

public class ProductRepository : IProductRepository
{
    // private readonly AppDbContext _context;
    private readonly IConnectionMultiplexer _redis;
    public ProductRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public List<Product?>? GetAllAsync()
    {
        var db = _redis.GetDatabase();
        // var completeSet = db.SetMembers("ProductSet");
        var completeHash = db.HashGetAll("hashProduct");
        if (completeHash.Length > 0)
        {
            //array(sets) to list
            var obj = Array.ConvertAll(completeHash, val => JsonSerializer.Deserialize<Product>(val.Value)).ToList();
            return obj;
        }

        return null;
    }

    public Product? GetByIdAsync(string id)
    {
        var db = _redis.GetDatabase();
        // var product = db.StringGet(id);
        var product = db.HashGet("hashProduct", id);

        if (!string.IsNullOrEmpty(product))
        {
            return JsonSerializer.Deserialize<Product>(product);
        }

        return null;
    }

    public void CreateAsync(Product product)
    {
        if (product == null)
        {
            throw new ArgumentOutOfRangeException(nameof(product));
        }

        var db = _redis.GetDatabase();
        var serialProduct = JsonSerializer.Serialize(product);

        // db.StringSet(product.Id, serialProduct); //key, value
        // db.SetAdd("ProductSet", serialProduct); //ProductSet array'ine serialProduct'u atar.

        db.HashSet("hashProduct", new HashEntry[]
        {
            new HashEntry(product.Id, serialProduct)
        });
    }
}
