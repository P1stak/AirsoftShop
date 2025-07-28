using OnlineShop.DB.Models;

namespace OnlineShop.DB
{
    public interface IProductsDbRepository
    {
        List<Product> GetAll();
        Product? TryGetById(Guid id);
        void Add(Product product);
        void Delete(Guid id);
        void Update(Product product);
    }
}