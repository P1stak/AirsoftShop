using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Register));

            var userAccount = _userManager.TryGetByName(login.Email);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не cуществует");
                return RedirectToAction(nameof(Register));
            }

            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Не правильный пароль");
                return RedirectToAction(nameof(Register));
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register registration)
        {
            if (registration.Email == registration.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                _userManager.Add(new UserAccount
                {
                    Email = registration.Email,
                    Phone = registration.Phone,
                    Password = registration.Password,
                    UserFullName = registration.UserFullName
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return RedirectToAction(nameof(Register));
        }
    }
}
