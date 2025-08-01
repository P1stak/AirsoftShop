using AirsoftShop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace AirsoftShop.Data.Repositories
{
    public class OrdersDbRepository : IOrdersDbRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            _databaseContext.Orders.Add(order);
            _databaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _databaseContext.Orders
                .Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .ToList();
        }

        public Order TryGetById(Guid orderId)
        {
            return _databaseContext.Orders
                .Include(x => x.User)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);

            if (order != null)
            {
                order.Status = newStatus;
                _databaseContext.SaveChanges();
            }
        }
    }
}
