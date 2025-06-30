using AirsoftShop.Models;

namespace AirsoftShop.Data.Interfaces
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart? TryGetByUserId(string userId);
    }
}