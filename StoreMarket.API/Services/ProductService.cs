using StoreMarket.API.Models;

namespace StoreMarket.API.Services
{
    public class ProductService
    {
        // Наш імпровізований склад (список товарів)
        private static List<Product> _products = new List<Product>
        {
            new Food("Apple", 15.50m, 100, DateTime.Now.AddDays(7)),
            new Electronics("Smartphone", 15000, 5, DateTime.Now.AddMonths(-2)),
            new Clothing("T-Shirt", 500, 20, "L")
        };

        // Отримати всі товари
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        // Отримати один товар по ID
        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        // Додати новий товар
        public void AddProduct(Product product)
        {
            int newId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            product.Id = newId;
            _products.Add(product);
        }
    }
}