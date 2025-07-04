using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository _productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = _productsRepository.GetAll();
            return View(products);
        }
    }
}
