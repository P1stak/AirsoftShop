using AirsoftShop.Data.Interfaces;
using AirsoftShop.Helpers;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Data.Interfacees;
using OnlineShop.DB.Models;

namespace AirsoftShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsDbRepository _cartsDbRepository;
        private readonly IOrdersDbRepository _ordersRepository;
        public OrderController(ICartsDbRepository cartsRepository, IOrdersDbRepository ordersRepository)
        {
            _cartsDbRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var user = _cartsDbRepository.TryGetByUserId(Constants.UserId);
            return View(user.ToCartViewModel());

        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            var existingCart = _cartsDbRepository.TryGetByUserId(Constants.UserId);

            var order = new Order
            {
                User = user.ToUser(),
                Status = OrderStatus.Created,
                CreateDateTime = DateTime.UtcNow,
                Items = existingCart.Items
               
            };
            _ordersRepository.Add(order);

            _cartsDbRepository.Clear(Constants.UserId);
            ViewBag.CustomerName = user.Name;
            
            return View(nameof(Buy));
        }
    }
}
