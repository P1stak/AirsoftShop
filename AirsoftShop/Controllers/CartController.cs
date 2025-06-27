using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class CartController : Controller
    {
        private ProductsRepository _productRepository;

        public CartController(ProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = _productRepository.TryGetById(productId);

            CartsRepository.Add(product, Constants.UserId);

            return RedirectToAction("Index");

        }
    }
}
