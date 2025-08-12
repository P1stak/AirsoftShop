using AirsoftShop.Areas.Admin.Models;
using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;

namespace AirsoftShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();

            var roleViewModels = roles.Select(role => new RoleViewModel { Name = role.Name }).ToList();

            return View(roleViewModels);
        }

        public IActionResult Delete(string roleName)
        {
            var role = _roleManager.FindByNameAsync(roleName).Result;

            if (role != null)
            {
                _roleManager.DeleteAsync(role).Wait();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RoleViewModel role)
        {
            var result = _roleManager.CreateAsync(new IdentityRole(role.Name)).Result;

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(role);
        }

        public IActionResult Edit(string roleName)
        {
            var role = _roleManager.FindByIdAsync(roleName).Result;
            return View(role.ToRoleViewModel());
        }
    }
}