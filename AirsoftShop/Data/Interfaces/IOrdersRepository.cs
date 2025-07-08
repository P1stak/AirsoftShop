using AirsoftShop.Models;

namespace AirsoftShop.Data.Interfaces
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
    }
}