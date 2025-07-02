using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;

namespace AirsoftShop.Data.Repositories
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> _orders = new List<Order>();
        private int nextId = 1;

        public void Add(Order order)
        {
            order.Id = nextId++;
            _orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return _orders;
        }
    }
}
