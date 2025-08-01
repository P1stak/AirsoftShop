using OnlineShop.DB.Models;

namespace OnlineShop.DB.Data.Interfacees
{
    public interface IFavoriteDbRepository
    {
        void Add(string userId, Product product);
        void Clear(string userId);
        List<Product> GetAll(string userId);
        void Remove(string userId, Guid productId);
    }
}