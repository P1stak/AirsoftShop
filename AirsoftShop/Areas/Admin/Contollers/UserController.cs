using AirsoftShop.Areas.Admin.Models;
using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userAccount = _userManager.GetAll();
            return View(userAccount);
        }
        public IActionResult Detail(string userName)
        {
            var userAccounnt = _userManager.TryGetByName(userName);
            return View(userAccounnt);
        }
        public IActionResult ChangePassword(string userName)
        {
            var changePassword = new ChangePassword()
            {
                UserName = userName
            };
            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                _userManager.ChangePassword(changePassword.UserName, changePassword.Password);


                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));

        }
        public IActionResult Delete(string userName)
        {
            _userManager.Delete(userName);
            return RedirectToAction(nameof(Index));
        }
    }
}
