using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;

namespace AirsoftShop.Data.Repositories
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> _orders = new List<Order>();

        public void Add(Order order)
        {
            _orders.Add(order);
        }
    }
}
