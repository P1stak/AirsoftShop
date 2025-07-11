using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class AccountController : Controller
    {
        private IProductsRepository _productsRepository;
        private ILogger<AccountController> _logger;

        public AccountController(IProductsRepository productsRepository, ILogger<AccountController> logger)
        {
            _productsRepository = productsRepository;
            _logger = logger;
            _logger.LogInformation("AccountController controller called");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register registration)
        {
            _logger.LogInformation("Login get method Starting.");

            if (registration.Email.Contains(registration.Password))
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Register");
        }
    }
}
