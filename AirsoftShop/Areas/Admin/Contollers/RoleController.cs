using AirsoftShop.Areas.Admin.Models;
using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Areas.Admin.Contollers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesInMemoryRepository _rolesInMemoryRepository;

        public RoleController(IRolesInMemoryRepository rolesInMemoryRepository)
        {
            _rolesInMemoryRepository = rolesInMemoryRepository;
        }

        public IActionResult Index()
        {
            var roles = _rolesInMemoryRepository.GetAllRoles();
            return View(roles);
        }

        public IActionResult Delete(string roleName)
        {
            _rolesInMemoryRepository.Delete(roleName);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View(new Role());
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (_rolesInMemoryRepository.TryGetByRoleName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                _rolesInMemoryRepository.AddRole(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
    }
}
