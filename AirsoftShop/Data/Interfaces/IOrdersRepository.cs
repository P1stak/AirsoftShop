using AirsoftShop.Models;

namespace AirsoftShop.Data.Interfaces
{
    public interface IOrdersRepository
    {
        void Add(Order order);
    }
}