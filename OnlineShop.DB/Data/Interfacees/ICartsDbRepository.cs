using OnlineShop.DB.Models;

namespace OnlineShop.DB.Data.Interfacees
{
    public interface ICartsDbRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void DecreaseAmount(Guid productId, string userId);
        Cart? TryGetByUserId(string userId);
    }
}