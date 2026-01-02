using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService: IProductService
    {
        private readonly List<Product> _products = new();
        public IEnumerable<Product> GetAll() => _products;
        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Create(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }
    }
}
