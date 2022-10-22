using Microsoft.AspNetCore.Mvc;
using RedisExampleAPI.Models;
using RedisExampleAPI.Repositories;

namespace RedisExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(_productRepository.GetAllAsync());
        }

        [HttpGet("{id}", Name="GetProductById")]
        public ActionResult<Product> GetProductById(string id)
        {
            var product = _productRepository.GetByIdAsync(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productRepository.CreateAsync(product);

            return CreatedAtRoute(nameof(GetProductById), new
            {
                Id = product.Id
            }, product);
        }
    }


}
