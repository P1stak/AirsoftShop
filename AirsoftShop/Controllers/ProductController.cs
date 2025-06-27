using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductsRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductsRepository();
        }

        public IActionResult Index(int id)
        {
            var product = _productRepository.TryGetById(id);
            return View(product);
        }
    }
}
