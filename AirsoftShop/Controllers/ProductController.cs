using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;

namespace AirsoftShop.Controllers
{
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
    }
}
