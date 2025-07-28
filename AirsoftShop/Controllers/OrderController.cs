using AirsoftShop.Data.Interfaces;
using AirsoftShop.Helpers;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;

namespace AirsoftShop.Controllers
{
    public class OrderController : Controller
    {
        private ICartsDbRepository _cartsDbRepository;
        private IOrdersRepository _ordersRepository;
        public OrderController(ICartsDbRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            _cartsDbRepository = cartsRepository;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var user = _cartsDbRepository.TryGetByUserId(Constants.UserId);
            return View(user);
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo user)
        {

            var existingCart = _cartsDbRepository.TryGetByUserId(Constants.UserId);

            if (!ModelState.IsValid)
            {
                return View("Index", existingCart);
            }

            var existingCartViewModel = Mapping.ToCartViewModel(existingCart);

            var order = new Order
            {
                User = user,
                Items = existingCartViewModel.Items
            };
            _ordersRepository.Add(order);
            _cartsDbRepository.Clear(Constants.UserId);


            ViewBag.CustomerName = user.Name;
            
            return View("Buy");
        }
    }
}
