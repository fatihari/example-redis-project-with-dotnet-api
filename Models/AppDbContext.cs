using Microsoft.EntityFrameworkCore;

namespace RedisExampleAPI.Models;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.
        //     Entity<Product>().
        //     HasData(
        //             new Product()
        //            {
        //                Id = 1, Name = "Kalem1", Price = 10
        //            },
        //            new Product()
        //            {
        //                Id = 2, Name = "Kalem2", Price = 10
        //
        //            },
        //            new Product()
        //            {
        //                Id = 3, Name = "Kalem2", Price = 10
        //
        //            });

        base.OnModelCreating(modelBuilder);
    }
}
