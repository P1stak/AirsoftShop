using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class AccountController : Controller
    {
        private IProductsRepository _productsRepository;

        public AccountController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register registration)
        {
            if (registration == null)
            {
                return NotFound();
            }
            if (registration.Password != registration.ConfirmPassword)
            {
                return BadRequest("Пароли не совпадают!");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
