using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;

namespace AirsoftShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsDbRepository _productsDbRepository;
        private readonly ICartsDbRepository _cartsDbRepository;

        public CartController(ICartsDbRepository cartsDbRepository, IProductsDbRepository productsDbRepository)
        {
            _cartsDbRepository = cartsDbRepository;
            _productsDbRepository = productsDbRepository;
        }
        public IActionResult Index()
        {
            var cart = _cartsDbRepository.TryGetByUserId(Constants.UserId);
            return View(cart.ToCartViewModel());
        }
        public IActionResult Add(Guid productId)  // +
        {
            var product = _productsDbRepository.TryGetById(productId);
            _cartsDbRepository.Add(product, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DecreaseAmount(Guid productId) // -
        {
            var product = _productsDbRepository.TryGetById(productId);
            _cartsDbRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            _cartsDbRepository.Clear(Constants.UserId);
            return RedirectToAction(nameof(Index));
        }

    }
}
