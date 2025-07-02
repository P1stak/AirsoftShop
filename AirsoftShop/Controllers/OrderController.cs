using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class OrderController : Controller
    {
        private ICartsRepository _cartsRepository;
        private IOrdersRepository _ordersRepository;
        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            _cartsRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var user = _cartsRepository.TryGetByUserId(Constants.UserId);
            return View(user);
        }

        [HttpPost]
        public IActionResult Buy(Order orderData)
        {
            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);

            if (cart == null || cart.Items.Count == 0)
            {
                return RedirectToAction("Index");
            }

            var order = new Order
            {
                Id = orderData.Id,
                FullName = orderData.FullName,
                Address = orderData.Address,
                Phone = orderData.Phone,
                OrderDate = orderData.OrderDate,
                Cost = orderData.Cost,
                Items = cart.Items.Select(item => new CartItem
                {
                    Id = item.Id,
                    Product = item.Product,
                    Amount = item.Amount
                }).ToList()
            };

            _ordersRepository.Add(order);
            _cartsRepository.Clear(Constants.UserId);

            return RedirectToAction("Confirmation", new { name = order.FullName });
        }

        public IActionResult Confirmation(string name)
        {
            ViewBag.CustomerName = name;
            return View();
        }
    }
}
