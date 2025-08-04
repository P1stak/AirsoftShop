using OnlineShop.DB.Models;

namespace OnlineShop.DB.Data.Interfacees
{
    public interface IProductsDbRepository
    {
        List<Product> GetAll();
        Product? TryGetById(Guid id);
        void Add(Product product);
        void Delete(Guid id);
        void Update(Product product);
        public IEnumerable<Product> SearchByName(string name);
    }
}