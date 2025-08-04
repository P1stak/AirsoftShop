using OnlineShop.DB.Models;

namespace AirsoftShop.Data.Interfaces
{
    public interface IOrdersDbRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(Guid orderId);
        void UpdateStatus(Guid orderId, OrderStatus newStatus);
        public void Remove(Guid orderId);
    }
}