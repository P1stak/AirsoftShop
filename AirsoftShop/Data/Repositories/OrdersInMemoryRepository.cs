using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;

namespace AirsoftShop.Data.Repositories
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Cart> orders = new List<Cart>();
        public void Add(Cart cart)
        {
            orders.Add(cart);
        }
    }
}
