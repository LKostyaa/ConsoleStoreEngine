using Microsoft.AspNetCore.Mvc;
using StoreMarket.API.Models;
using StoreMarket.API.Services;

namespace StoreMarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Це означає, що адреса буде /api/products
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        // Конструктор: тут ми просимо програму дати нам доступ до Складу
        public ProductsController(ProductService service)
        {
            _service = service;
        }

        // GET: api/products (Отримати список)
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _service.GetAllProducts();
            return Ok(products);
        }

        // POST: api/products (Додати товар)
        [HttpPost]
        public IActionResult Add(Product product)
        {
            _service.AddProduct(product);
            return Ok(product);
        }
    }
}