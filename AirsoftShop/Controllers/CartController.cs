using AirsoftShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirsoftShop.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository _productRepository;
        private ICartsRepository _cartRepository;

        public CartController(IProductsRepository productRepository, ICartsRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }
        public IActionResult Index()
        {
            var cart = _cartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)  // +
        {
            var product = _productRepository.TryGetById(productId);
            _cartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseAmount(int productId) // -
        {
            var product = _productRepository.TryGetById(productId);
            _cartRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            _cartRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }

    }
}
