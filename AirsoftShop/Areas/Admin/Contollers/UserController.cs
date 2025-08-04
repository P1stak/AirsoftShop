using AirsoftShop.Areas.Admin.Models;
using AirsoftShop.Helpers;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var model = users.Select(x => x.ToUserViewModel()).ToList();
            return View(model);
        }
        
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(RegisterViewModel register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError(string.Empty, "Имя пользователя и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {

                var user = new User
                {
                    Email = register.UserName,
                    UserName = register.UserName,
                    PhoneNumber = register.Phone
                };

                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Constants.UserRoleName);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

        public async Task<IActionResult> RemoveAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains(Constants.AdminRoleName))
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return View(user.ToUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditUserViewModel editUserViewModel, string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            user.PhoneNumber = editUserViewModel.Phone;
            user.UserName = editUserViewModel.Name;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DetailsAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var model = Mapping.ToUserViewModel(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            ViewBag.IsAdmin = userRoles.Contains(Constants.AdminRoleName);
            return View(model);
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name
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
                var user = _userManager.FindByNameAsync(changePassword.UserName).Result;

                var newHashPassword = _userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                _userManager.UpdateAsync(user).Wait();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }

        public async Task<IActionResult> EditRightsAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();
            var model = new EditRightsViewModel
            {
                UserName = user.UserName,
                UserRoles = userRoles.Select(role => new RoleViewModel { Name = role }).ToList(),
                AllRoles = roles.Select(role => new RoleViewModel { Name = role.Name }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRightsAsync(string name, Dictionary<string, bool> userRolesViewsModel)
        {
            if (ModelState.IsValid)
            {
                var userSelectedRoles = userRolesViewsModel.Select(role => role.Key);
                var user = await _userManager.FindByNameAsync(name);
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, userSelectedRoles);
                return Redirect($"/Admin/User/Details?name={name}");
            }
            return Redirect($"/Admin/User/EditRights?name={name}");
        }

    }
}
