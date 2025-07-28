using AirsoftShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;

namespace AirsoftShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductsDbRepository _productsDbRepository;

        public HomeController(IProductsDbRepository productsDbRepository)
        {
            _productsDbRepository = productsDbRepository;
        }

        public IActionResult Index()
        {
            var products = _productsDbRepository.GetAll();
            return View(Mapping.ToProductViewModels(products));
        }
    }
}
