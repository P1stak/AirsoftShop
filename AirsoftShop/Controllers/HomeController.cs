using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirsoftShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductsRepository _productRepository;
        private ICartsRepository _cartsRepository;
        private IOrdersRepository _ordersRepository;

        public HomeController(IProductsRepository productRepository, ICartsRepository artsRepository, IOrdersRepository ordersRepository)
        {
            _productRepository = productRepository;
            _cartsRepository = artsRepository;
            _ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var product = _productRepository.GetAll();

            var cart = _cartsRepository.TryGetByUserId(Constants.UserId);
            ViewBag.CartItemCount = cart?.Amount;

            return View(product);
        }
        public IActionResult UserLogin()
        {
            return View();
        }
        public IActionResult UserRegistration()
        {
            return View();
        }
        public IActionResult Admin()
        {
            var product = _productRepository.GetAll();
            return View(product);
        }
















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
