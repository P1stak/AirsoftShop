using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _productsRepository;
        private ICartsRepository _cartsRepository;

        public ProductController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            _productsRepository = productsRepository;
            _cartsRepository = cartsRepository;
        }

        public IActionResult Index(int id)
        {
            var product = _productsRepository.TryGetById(id);
            return View(product);
        }
    }
}
