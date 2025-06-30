using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class OrderController : Controller
    {
        private ICartsRepository _cartRepository;
        private IOrdersRepository _ordersRepository;

        public OrderController(ICartsRepository cartRepository, IOrdersRepository ordersRepository)
        {
            _cartRepository = cartRepository;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            var user = _cartRepository.TryGetByUserId(Constants.UserId);
            return View(user);
        }
        public IActionResult Buy()
        {
            var existingCart = _cartRepository.TryGetByUserId(Constants.UserId);
            _ordersRepository.Add(existingCart);
            _cartRepository.Clear(Constants.UserId);
            return View(existingCart);
        }
    }
}
