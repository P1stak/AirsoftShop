using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Data.Interfacees;

namespace AirsoftShop.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteDbRepository _favoriteDbRepository;
        private readonly IProductsDbRepository _productsDbRepository;

        public FavoriteController(IFavoriteDbRepository favoriteDbRepository, IProductsDbRepository productsDbRepository)
        {
            _favoriteDbRepository = favoriteDbRepository;
            _productsDbRepository = productsDbRepository;
        }

        public IActionResult Index()
        {
            var products = _favoriteDbRepository.GetAll(Constants.UserId);
            return View(products.ToProductViewModels());
        }
        public IActionResult Add(Guid productId)
        {
            var product = _productsDbRepository.TryGetById(productId);
            _favoriteDbRepository.Add(Constants.UserId, product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid productId)
        {
            _favoriteDbRepository.Remove(Constants.UserId, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
