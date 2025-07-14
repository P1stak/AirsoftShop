using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IActionResult Index(int id)
        {
            var product = _productsRepository.TryGetById(id);
            return View(product);
        }
    }
}
