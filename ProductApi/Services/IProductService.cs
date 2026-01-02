using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Create(Product product);
    }
}
