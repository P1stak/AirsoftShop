using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository _productsRepository;
        private IOrdersRepository _ordersRepository;
        private IRolesInMemoryRepository _rolesInMemoryRepository;

        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesInMemoryRepository rolesInMemoryRepository)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
            _rolesInMemoryRepository = rolesInMemoryRepository;
        }

        public IActionResult Orders()
        {
            var order = _ordersRepository.GetAll();
            return View(order);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = _ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            _ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");

        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var roles = _rolesInMemoryRepository.GetAllRoles();
            return View(roles);
        }
        public IActionResult RemoveRole(string roleName)
        {
            _rolesInMemoryRepository.Delete(roleName);
            return RedirectToAction("Roles");
        }
        public IActionResult AddRole()
        {
            return View(new Role());
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (_rolesInMemoryRepository.TryGetByRoleName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                _rolesInMemoryRepository.AddRole(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
        public IActionResult Products()
        {
            var products = _productsRepository.GetAll();
            return View(products);
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productsRepository.Add(product);
            return RedirectToAction("Products");
        }
        public IActionResult EditProduct(int productId)
        {
            var product = _productsRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productsRepository.Update(product);
            return RedirectToAction("Products");
        }
        public IActionResult DeleteProduct(int productId)
        {
            var product = _productsRepository.TryGetById(productId);
            if (product != null)
            {
                _productsRepository.GetAll().Remove(product);
            }
            return RedirectToAction("Products");
        }
    }
}
