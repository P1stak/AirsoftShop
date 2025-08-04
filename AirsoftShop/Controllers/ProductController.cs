using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;

namespace AirsoftShop.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductsDbRepository _productsDbRepository;

        public ProductController(IProductsDbRepository productsDbRepository)
        {
            _productsDbRepository = productsDbRepository;
        }

        public IActionResult Index(Guid productId)
        {
            var product = _productsDbRepository.TryGetById(productId);
            return View(product.ToProductViewModel());
        }
        public IActionResult SearchProduct(string productName)
        {
            var product = _productsDbRepository.SearchByName(productName);
            return View(product);
        }
    }
}
