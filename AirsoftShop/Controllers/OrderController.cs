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
        public IActionResult Buy(UserDeliveryInfo user)
        {

            var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);

            if (!ModelState.IsValid)
            {
                return View("Index", existingCart);
            }
            var order = new Order
            { 
                User = user,
                Items = existingCart.Items
            };
            _ordersRepository.Add(order);
            _cartsRepository.Clear(Constants.UserId);


            ViewBag.CustomerName = user.Name;
            return View("Buy");
        }
    }
}
