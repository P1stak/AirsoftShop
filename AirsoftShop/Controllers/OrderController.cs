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
        public IActionResult Buy(Order order)
        {
            var existingCart = _cartsRepository.TryGetByUserId(Constants.UserId);
            _ordersRepository.Add(existingCart);
            _cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
