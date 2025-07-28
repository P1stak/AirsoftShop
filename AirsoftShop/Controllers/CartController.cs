using AirsoftShop.Data.Interfaces;
using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;

namespace AirsoftShop.Controllers
{
    public class CartController : Controller
    {
        private IProductsDbRepository _productsDbRepository;
        private ICartsDbRepository _cartsDbRepository;

        public CartController(ICartsDbRepository cartsDbRepository, IProductsDbRepository productsDbRepository)
        {
            _cartsDbRepository = cartsDbRepository;
            _productsDbRepository = productsDbRepository;
        }
        public IActionResult Index()
        {
            var cart = _cartsDbRepository.TryGetByUserId(Constants.UserId);
            return View(Mapping.ToCartViewModel(cart));
        }
        public IActionResult Add(Guid productId)  // +
        {
            var product = _productsDbRepository.TryGetById(productId);
            _cartsDbRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseAmount(Guid productId) // -
        {
            var product = _productsDbRepository.TryGetById(productId);
            _cartsDbRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            _cartsDbRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }

    }
}
