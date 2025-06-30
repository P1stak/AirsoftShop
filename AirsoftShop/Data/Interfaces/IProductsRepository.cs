using AirsoftShop.Models;

namespace AirsoftShop.Data.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product? TryGetById(int id);
    }
}